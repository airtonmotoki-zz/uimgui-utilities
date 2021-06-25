using ImGuiManager.Core;
using Unity.Entities;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiWindowECS", menuName = "ImGui/SampleECS/ImGuiWindowECS", order = 1)]
	public class ImGuiWindowECS : ImGuiWindowBase<World>
	{
		public override void OnLayoutWindow()
		{
			UnityEngine.Debug.Log(Context.Name + " " + "ImGuiWindowECS");
		}
	}
}
