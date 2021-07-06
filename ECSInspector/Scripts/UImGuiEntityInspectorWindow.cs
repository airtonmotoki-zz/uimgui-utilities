using ImGuiNET;
using System;
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

		[SerializeField]
		private string space = "\t";

		public override void OnLayoutWindow()
		{
			var entityManager = Context.EntityManager;

			if (SelectedEntity != Entity.Null)
			{
				// Header
				ImGui.Text(entityManager.GetName(SelectedEntity));
				ImGui.Text($"Index {SelectedEntity.Index}");
				ImGui.Text($"Version {SelectedEntity.Version}");
				ImGui.Separator();

				// Tags
				var allTags = GetAllTags(entityManager, SelectedEntity, Allocator.Temp);
				if (allTags.Length > 0)
				{
					ImGui.Text("Tags");
					for (var tagIndex = 0; tagIndex < allTags.Length; tagIndex++)
					{
						ImGui.Text($"{space}{allTags[tagIndex]}");
					}
				}
				allTags.Dispose();

				ImGui.Separator();

				// Component selector
				var allComponents = GetAllNonTags(entityManager, SelectedEntity, Allocator.Temp);
				for(var componentIndex = 0; componentIndex < allComponents.Length; componentIndex++)
				{
					if (ImGui.TreeNode(allComponents[componentIndex].ToString()))
					{
						var componentType = allComponents[componentIndex];
						var result = GetComponent(entityManager, componentType, SelectedEntity);

						DrawFields(result);

						ImGui.TreePop();
					}
				}

				allComponents.Dispose();
			}
			else
			{
				ImGui.Text("No entity selected.");
			}
		}

		private void DrawFields(object obj, string prefix = "")
		{
			var fields = obj.GetType().GetFields();

			for (var fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
			{
				var field = fields[fieldIndex];
				var fieldName = field.Name;
				var fieldValue = field.GetValue(obj);
				ImGui.Text($"{prefix}{fieldName}");

				var methodInfo = GetType().GetMethod(nameof(DrawComponent), new Type[] { fieldValue.GetType(), typeof(string) });

				if (methodInfo == null)
				{
					ImGui.Text($"{prefix}{space}{fieldValue}");
				}
				else
				{
					methodInfo.Invoke(this, new object[] { fieldValue, prefix + space });
				}
			}
		}

		public static bool IsTag(ComponentType component)
		{
			return !component.IsSharedComponent && !component.IsBuffer && !component.IsManagedComponent && component.IsZeroSized;
		}

		public static NativeList<ComponentType> GetAllTags(EntityManager entityManager, Entity entity, Allocator allocator)
		{
			var list = new NativeList<ComponentType>(allocator);
			var components = entityManager.GetComponentTypes(entity);

			for (var index = 0; index < components.Length; index++)
			{
				var component = components[index];
				if (IsTag(component))
				{
					list.Add(component);
				}
			}

			return list;
		}

		public static NativeList<ComponentType> GetAllNonTags(EntityManager entityManager, Entity entity, Allocator allocator)
		{
			var list = new NativeList<ComponentType>(allocator);
			var components = entityManager.GetComponentTypes(entity);

			for (var index = 0; index < components.Length; index++)
			{
				var component = components[index];
				if (!IsTag(component))
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

			return methodInfo.Invoke(entityManager, new object[] { entity });
		}

		public void DrawComponent(int2 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y}");
		}

		public void DrawComponent(int3 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z}");
		}

		public void DrawComponent(int4 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}");
		}

		public void DrawComponent(uint2 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y}");
		}

		public void DrawComponent(uint3 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z}");
		}

		public void DrawComponent(uint4 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}");
		}

		public void DrawComponent(float2 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y}");
		}

		public void DrawComponent(float3 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z}");
		}

		public void DrawComponent(float4 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}");
		}

		public void DrawComponent(quaternion obj, string prefix)
		{
			DrawComponent(obj.value, prefix);
		}

		public void DrawComponent(double2 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y}");
		}

		public void DrawComponent(double3 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z}");
		}

		public void DrawComponent(double4 obj, string prefix)
		{
			ImGui.Text($"{prefix}x:{obj.x} y:{obj.y} z:{obj.z} w:{obj.w}");
		}
	}
}
