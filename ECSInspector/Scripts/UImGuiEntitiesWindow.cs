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
		private struct EntityTableEntry
		{
			public Entity Entity;
			public string Name;
		}

		private abstract class ColumnComparer<T> : IComparer<T>
		{
			public abstract int Compare(T x, T y);
		}

		private class EntityIndexComparer : ColumnComparer<EntityTableEntry>
		{
			public override int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				if (x.Entity.Index < y.Entity.Index) return -1;
				if (x.Entity.Index == y.Entity.Index) return 0;
				return 1;
			}
		}
		private class EntityVersionComparer : ColumnComparer<EntityTableEntry>
		{
			public override int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return x.Entity.Version.CompareTo(y.Entity.Version);
			}
		}
		private class EntityNameComparer : ColumnComparer<EntityTableEntry>
		{
			public override int Compare(EntityTableEntry x, EntityTableEntry y)
			{
				return x.Name.CompareTo(y.Name);
			}
		}

		private struct TableColumn
		{
			public string Name;
			public ImGuiTableColumnFlags Flags;
			public ColumnComparer<EntityTableEntry> Comparer;
		}

		private TableColumn[] _columns = new TableColumn[]
		{
			new TableColumn
			{
				Name = "Index",
				Flags = ImGuiTableColumnFlags.DefaultSort | ImGuiTableColumnFlags.NoHide,
				Comparer = new EntityIndexComparer()
			},
			new TableColumn
			{
				Name = "Version",
				Flags = default,
				Comparer = new EntityVersionComparer()
			},
			new TableColumn
			{
				Name = "Name",
				Flags = ImGuiTableColumnFlags.NoHide,
				Comparer = new EntityNameComparer()
			}
		};

		private string _filterValue = "";

		private ImGuiTableFlags TableFlags =
			ImGuiTableFlags.Borders |
			ImGuiTableFlags.Sortable |
			ImGuiTableFlags.ScrollY |
			ImGuiTableFlags.Resizable |
			ImGuiTableFlags.Hideable;

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
				for (var columnIndex = 0; columnIndex < _columns.Length; columnIndex++)
				{
					var column = _columns[columnIndex];
					ImGui.TableSetupColumn(column.Name, column.Flags);
				}

				ImGui.TableHeadersRow();

				var sortSpecsPtr = ImGui.TableGetSortSpecs();

				if (sortSpecsPtr.SpecsDirty)
				{
					var sortSpecs = sortSpecsPtr.Specs;
					var columnSort = sortSpecs.ColumnIndex;

					_allEntitiesTableEntry.Sort(_columns[columnSort].Comparer);

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
