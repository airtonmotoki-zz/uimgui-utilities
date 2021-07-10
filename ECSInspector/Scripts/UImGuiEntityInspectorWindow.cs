using ImGuiNET;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

		private readonly ImGuiTreeNodeFlags DefaultNode = ImGuiTreeNodeFlags.None;
		private readonly ImGuiTreeNodeFlags DefaultLeaf = ImGuiTreeNodeFlags.Leaf;

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
				ImGui.InputText("Filter", ref _filterValue, 512);
			}
			#endregion

			#region Flags
			{
				if (ImGui.TreeNodeEx("Flags", DefaultNode))
				{
					var allFlags = GetAllFlags(entityManager, SelectedEntity);
					for (int flagIndex = 0; flagIndex < allFlags.Count; flagIndex++)
					{
						var flagName = allFlags[flagIndex].ToString();
						if (string.IsNullOrEmpty(_filterValue) || flagName.Contains(_filterValue))
						{
							DrawComponent(flagName);
						}
					}
					ImGui.TreePop();
				}
				ImGui.Separator();
			}
			#endregion

			#region Components
			{
				var allComponents = GetAllNonFlags(entityManager, SelectedEntity);
				for (int componentIndex = 0; componentIndex < allComponents.Count; componentIndex++)
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
			}
			#endregion
		}

		private void DrawFields(object obj, string labelPrefix = "", string labelPosfix = "")
		{
			var type = obj.GetType();
			var array = obj as IEnumerable;
			
			if (type.IsPrimitive)
			{
				if (ImGui.TreeNodeEx($"{labelPrefix}{labelPosfix}{obj}", DefaultLeaf))
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
							DrawComponent(fieldValue.ToString(), DefaultNode | DefaultLeaf);
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
	}
}
