using ImGuiNET;
using System;
using System.Collections;
using UImGuiManager.Core;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "EntityInspectorWindow", menuName = "ImGui/Entities Inspector/Entity Inspector Window", order = 2)]
	public partial class UImGuiEntityInspectorWindow : UImGuiWindowBase<World>
	{
		public static Entity SelectedEntity;

		private string _filterValue = "";

		private ImGuiTreeNodeFlags DefaultNode = default;
		private ImGuiTreeNodeFlags DefaultLeaf = ImGuiTreeNodeFlags.Leaf;

		public override void OnLayoutWindow()
		{
			if (SelectedEntity == Entity.Null)
			{
				ImGui.Text("No entity selected.");
				return;
			}

			var entityManager = Context.EntityManager;

			#region Header
			{
				ImGui.Text(entityManager.GetName(SelectedEntity));
				ImGui.Text($"Index {SelectedEntity.Index}");
				ImGui.Text($"Version {SelectedEntity.Version}");
				ImGui.Separator();
			}
			#endregion

			#region Search
			{
				ImGui.InputText("Filter Component", ref _filterValue, 512);
			}
			#endregion

			#region Flags
			{
				var allFlags = GetAllFlags(entityManager, SelectedEntity, Allocator.Temp);
				if (ImGui.TreeNodeEx("Flags", DefaultNode))
				{
					for (var flagIndex = 0; flagIndex < allFlags.Length; flagIndex++)
					{
						var flagName = allFlags[flagIndex].ToString();
						if (string.IsNullOrEmpty(_filterValue) || flagName.Contains(_filterValue))
						{
							if (ImGui.TreeNodeEx($"{flagName}", DefaultLeaf))
							{
								ImGui.TreePop();
							}
						}
					}
					ImGui.TreePop();
				}
				ImGui.Separator();
				allFlags.Dispose();
			}
			#endregion

			#region Components
			{
				var allComponents = GetAllNonFlags(entityManager, SelectedEntity, Allocator.Temp);
				for (var componentIndex = 0; componentIndex < allComponents.Length; componentIndex++)
				{
					var componentType = allComponents[componentIndex];
					var componentName = componentType.ToString();
					if (string.IsNullOrEmpty(_filterValue) || componentName.Contains(_filterValue))
					{
						if (ImGui.TreeNodeEx(componentName, DefaultNode))
						{
							var result = GetComponent(entityManager, componentType, SelectedEntity);

							DrawFields(result);

							ImGui.TreePop();
						}
					}
				}
				allComponents.Dispose();
			}
			#endregion
		}

		private void DrawFields(object obj, string labelPrefix = "", string labelPosfix = "")
		{
			var type = obj.GetType();
			var array = obj as IEnumerable;
			
			if (type.IsPrimitive)
			{
				if (ImGui.TreeNodeEx($"{labelPrefix}{labelPosfix}{obj.ToString()}", DefaultLeaf))
				{
					ImGui.TreePop();
				}
			}
			else if (array != null)
			{
				object nativeArrayCast = null;
				var genericType = type.GetGenericTypeDefinition();

				if (genericType.Equals(typeof(DynamicBuffer<>)))
				{
					var toNativeArrayMethod = type.GetMethod("AsNativeArray");
					nativeArrayCast = toNativeArrayMethod.Invoke(obj, new object[] { });
					array = nativeArrayCast as IEnumerable;
				}

				var index = 0;
				foreach (var element in array)
				{
					DrawFields(element, labelPosfix: $"[{index}]: ");
					index++;
				}
			}
			else
			{
				var fields = type.GetFields();

				for (var fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
				{
					var field = fields[fieldIndex];
					var fieldName = labelPrefix + field.Name + labelPosfix;
					var fieldValue = field.GetValue(obj);

					var methodInfo = GetType().GetMethod(nameof(DrawComponent), new Type[] { fieldValue.GetType() });

					// Draw primitives
					if (field.FieldType.IsPrimitive)
					{
						if (ImGui.TreeNodeEx(fieldName, DefaultLeaf))
						{
							if (ImGui.TreeNodeEx(fieldValue.ToString(), DefaultNode | DefaultLeaf))
							{
								ImGui.TreePop();
							}
							ImGui.TreePop();
						}
					}

					// Draw array
					else if (field.FieldType.IsArray)
					{
						var dataArray = (Array)fieldValue;
						if (ImGui.TreeNodeEx($"{fieldName} [{dataArray.Length}]", DefaultNode))
						{
							for (var index = 0; index < dataArray.Length; index++)
							{
								DrawFields(dataArray.GetValue(index), labelPosfix: $"[{index}]: ");
							}
							ImGui.TreePop();
						}
					}

					// Draw field using custom methods
					else if (methodInfo != null)
					{
						if (ImGui.TreeNodeEx(fieldName, DefaultLeaf))
						{
							methodInfo.Invoke(this, new object[] { fieldValue });
							ImGui.TreePop();
						}
					}

					// Draw complex field
					else if (ImGui.TreeNodeEx(fieldName, DefaultNode))
					{
						DrawFields(fieldValue);
						ImGui.TreePop();
					}
				}
			}
		}

		public static bool IsFlag(ComponentType component)
		{
			return !component.IsSharedComponent && !component.IsBuffer && !component.IsManagedComponent && component.IsZeroSized;
		}

		public static NativeList<ComponentType> GetAllFlags(EntityManager entityManager, Entity entity, Allocator allocator)
		{
			var list = new NativeList<ComponentType>(allocator);
			var components = entityManager.GetComponentTypes(entity);

			for (var index = 0; index < components.Length; index++)
			{
				var component = components[index];
				if (IsFlag(component))
				{
					list.Add(component);
				}
			}

			return list;
		}

		public static NativeList<ComponentType> GetAllNonFlags(EntityManager entityManager, Entity entity, Allocator allocator)
		{
			var list = new NativeList<ComponentType>(allocator);
			var components = entityManager.GetComponentTypes(entity);

			for (var index = 0; index < components.Length; index++)
			{
				var component = components[index];
				if (!IsFlag(component))
				{
					list.Add(component);
				}
			}

			return list;
		}

		public static object GetComponent(EntityManager entityManager, ComponentType component, Entity entity)
		{
			var entityManagerType = entityManager.GetType();

			var methodName = "";
			if (component.IsSharedComponent)
			{
				methodName = nameof(entityManager.GetSharedComponentData);
			}
			else if (component.IsBuffer)
			{
				methodName = nameof(entityManager.GetBuffer);
			}
			else if (component.IsManagedComponent)
			{
				methodName = nameof(entityManager.GetComponentObject);
			}
			else if (!component.IsZeroSized)
			{
				methodName = nameof(entityManager.GetComponentData);
			}
			else
			{
				return component;
			}
			var genericMethod = entityManagerType.GetMethod(methodName, new Type[] { typeof(Entity) });
			var methodInfo = genericMethod.MakeGenericMethod(component.GetManagedType());

			var obj = methodInfo.Invoke(entityManager, new object[] { entity });

			var type = obj.GetType();
			UnityEngine.Debug.Log(type);

			return obj;
		}

		public void DrawComponent(int2 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(int3 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(int4 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(uint2 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(uint3 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(uint4 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(float2 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(float3 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(float4 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(quaternion obj)
		{
			DrawComponent(obj.value);
		}

		public void DrawComponent(double2 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(double3 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(double4 obj)
		{
			if (ImGui.TreeNodeEx($"x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}", DefaultLeaf))
			{
				ImGui.TreePop();
			}
		}
	}
}
