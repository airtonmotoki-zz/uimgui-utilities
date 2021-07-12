using ImGuiNET;
using System.Collections.Generic;
using UImGuiManager.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "EntitiesWindow", menuName = "ImGui/Entities Inspector/Entities Window", order = 1)]
	public class UImGuiEntitiesWindow : UImGuiWindowBase<World>
	{
		#region Entity Table Data
		private struct EntityTableEntry
		{
			public Entity Entity;
			public string Name;
		}

		private class EntityIndexAscendingComparer : IComparer<EntityTableEntry>
		{
			public int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return x.Entity.Index.CompareTo(y.Entity.Index);
			}
		}

		private class EntityIndexDescendingComparer : IComparer<EntityTableEntry>
		{
			public int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return y.Entity.Index.CompareTo(x.Entity.Index);
			}
		}

		private class EntityVersionAscendingComparer : IComparer<EntityTableEntry>
		{
			public int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return x.Entity.Version.CompareTo(y.Entity.Version);
			}
		}

		private class EntityVersionDescendingComparer : IComparer<EntityTableEntry>
		{
			public int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return y.Entity.Version.CompareTo(x.Entity.Version);
			}
		}

		private class EntityNameAscendingComparer : IComparer<EntityTableEntry>
		{
			public int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return x.Name.CompareTo(y.Name);
			}
		}

		private class EntityNameDescendingComparer : IComparer<EntityTableEntry>
		{
			public int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return y.Name.CompareTo(x.Name);
			}
		}

		private struct TableColumn
		{
			public string Name;
			public ImGuiTableColumnFlags Flags;
			public IComparer<EntityTableEntry> AscendingComparer;
			public IComparer<EntityTableEntry> DescendingComparer;
		}
		#endregion

		private static TableColumn[] _columns = new TableColumn[]
		{
			new TableColumn
			{
				Name = "Index",
				Flags = ImGuiTableColumnFlags.DefaultSort | ImGuiTableColumnFlags.NoHide,
				AscendingComparer = new EntityIndexAscendingComparer(),
				DescendingComparer = new EntityIndexDescendingComparer()
			},
			new TableColumn
			{
				Name = "Version",
				Flags = default,
				AscendingComparer = new EntityVersionAscendingComparer(),
				DescendingComparer = new EntityVersionDescendingComparer()
			},
			new TableColumn
			{
				Name = "Name",
				Flags = ImGuiTableColumnFlags.NoHide,
				AscendingComparer = new EntityNameAscendingComparer(),
				DescendingComparer = new EntityNameDescendingComparer()
			}
		};

		private ImGuiTableFlags TableFlags =
			ImGuiTableFlags.Borders |
			ImGuiTableFlags.Sortable |
			ImGuiTableFlags.ScrollY |
			ImGuiTableFlags.Resizable |
			ImGuiTableFlags.Hideable;

		private string _filterValue = "";

		private int _lastEntityManagerVersion = -1;

		private List<EntityTableEntry> _allEntitiesTableEntry;

		public override void OnLayoutWindow()
		{
			var entityManager = Context.EntityManager;

			if (_lastEntityManagerVersion < entityManager.Version || _allEntitiesTableEntry == null)
			{
				var allEntities = entityManager.GetAllEntities(Allocator.Temp);
				_allEntitiesTableEntry = new List<EntityTableEntry>();
				for (var index = 0; index < allEntities.Length; index++)
				{
					var entity = allEntities[index];
					_allEntitiesTableEntry.Add(new EntityTableEntry
					{
						Entity = entity,
						Name = entityManager.GetName(entity)
					});
				}
				_lastEntityManagerVersion = entityManager.Version;
			}

			#region Search
			{
				ImGui.InputText("Filter", ref _filterValue, 512);
			}
			#endregion

			if (ImGui.BeginTable("entities_list", _columns.Length, TableFlags))
			{
				// Draw Columns
				for (var columnIndex = 0; columnIndex < _columns.Length; columnIndex++)
				{
					var column = _columns[columnIndex];
					ImGui.TableSetupColumn(column.Name, column.Flags);
				}

				ImGui.TableHeadersRow();

				// Sort Table Data
				var sortSpecsPtr = ImGui.TableGetSortSpecs();

				if (sortSpecsPtr.SpecsDirty)
				{
					var sortSpecs = sortSpecsPtr.Specs;
					var columnSort = sortSpecs.ColumnIndex;
					var direction = sortSpecs.SortDirection;

					switch (direction)
					{
						case ImGuiSortDirection.Ascending:
							_allEntitiesTableEntry.Sort(_columns[columnSort].AscendingComparer);
							break;
						case ImGuiSortDirection.Descending:
							_allEntitiesTableEntry.Sort(_columns[columnSort].DescendingComparer);
							break;
					}

					sortSpecsPtr.SpecsDirty = false;
				}

				for (var index = 0; index < _allEntitiesTableEntry.Count; index++)
				{
					var entity = _allEntitiesTableEntry[index].Entity;
					var entityName = _allEntitiesTableEntry[index].Name.ToString();

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
		}
	}
}
