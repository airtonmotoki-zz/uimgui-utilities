using ImGuiNET;
using UImGuiManager.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "EntitiesWindow", menuName = "ImGui/SampleECSInspector/Entities Window", order = 1)]
	public class UImGuiEntitiesWindow : UImGuiWindowBase<World>
	{
		public static Entity SelectedEntity;

		public override void OnLayoutWindow()
		{
			var entityManager = Context.EntityManager;

			var allEntities = entityManager.GetAllEntities(Allocator.Temp);

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

					ImGui.TableNextRow();

					if (ImGui.TableSetColumnIndex(0))
					{
						if (ImGui.Selectable(entity.Index.ToString(), (SelectedEntity == entity), ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowItemOverlap))
						{
							SelectedEntity = entity;
							UnityEngine.Debug.Log(entityManager.GetName(entity));
						}
					}

					if (ImGui.TableSetColumnIndex(1))
					{
						ImGui.Text(entity.Version.ToString());
					}

					if (ImGui.TableSetColumnIndex(2))
					{
						ImGui.Text(entityManager.GetName(entity));
					}
				}

				ImGui.EndTable();
			}

			allEntities.Dispose();
		}
	}
}
