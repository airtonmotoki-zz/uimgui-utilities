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
		public override void OnLayoutWindow()
		{
			var entityManager = Context.EntityManager;

			var allEntities = entityManager.GetAllEntities(Allocator.Temp);

			for (var index = 0; index < allEntities.Length; index++)
			{
				var entity = allEntities[index];
				ImGui.Text(entityManager.GetName(entity));
			}
			allEntities.Dispose();
		}
	}
}
