using UImGuiManager.Core;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "ImGuiWindowECS", menuName = "ImGui/Sample ECS/ImGuiWindowECS", order = 1)]
	public class UImGuiWindowECS : UImGuiWindowBase<World>
	{
		public override void OnLayoutWindow()
		{
			UnityEngine.Debug.Log(Context.Name + " " + "ImGuiWindowECS");
		}
	}
}
