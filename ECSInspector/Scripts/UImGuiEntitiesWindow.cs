using ImGuiNET;
using UImGuiManager.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "EntitiesWindow", menuName = "ImGui/Entities Inspector/Entities Window", order = 1)]
	public class UImGuiEntitiesWindow : UImGuiWindowBase<World>
	{
		private string _filterValue = "";

		public override void OnLayoutWindow()
		{
			var entityManager = Context.EntityManager;

			var allEntities = entityManager.GetAllEntities(Allocator.Temp);

			#region Search
			{
				ImGui.InputText("Filter", ref _filterValue, 512);
			}
			#endregion

			ImGuiTableFlags flags = ImGuiTableFlags.Borders | ImGuiTableFlags.Sortable | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Resizable | ImGuiTableFlags.Hideable;
			if (ImGui.BeginTable("entities_list", 3, flags))
			{
				ImGui.TableSetupColumn("Index", ImGuiTableColumnFlags.DefaultSort | ImGuiTableColumnFlags.NoHide);
				ImGui.TableSetupColumn("Version");
				ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.NoHide);

				ImGui.TableHeadersRow();

				for (var index = 0; index < allEntities.Length; index++)
				{
					var entity = allEntities[index];
					var entityName = entityManager.GetName(entity);

					if (string.IsNullOrEmpty(_filterValue) || entityName.Contains(_filterValue) || entity.Index.ToString().Contains(_filterValue))
					{
						ImGui.TableNextRow();

						if (ImGui.TableSetColumnIndex(0))
						{
							if (ImGui.Selectable(entity.Index.ToString(), (UImGuiEntityInspectorWindow.SelectedEntity == entity), ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowItemOverlap))
							{
								UImGuiEntityInspectorWindow.SelectedEntity = entity;
							}
						}

						if (ImGui.TableSetColumnIndex(1))
						{
							ImGui.Text(entity.Version.ToString());
						}

						if (ImGui.TableSetColumnIndex(2))
						{
							ImGui.Text(entityName);
						}

					}
				}

				ImGui.EndTable();
			}

			allEntities.Dispose();
		}
	}
}
