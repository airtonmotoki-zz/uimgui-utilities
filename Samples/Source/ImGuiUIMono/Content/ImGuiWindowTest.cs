using ImGuiManager.Core;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiWindowTest", menuName = "ImGui/Sample/ImGuiWindowTest", order = 1)]
	public class ImGuiWindowTest : ImGuiWindowBase<Empty>
	{
		public override void OnLayoutWindow()
		{
			UnityEngine.Debug.Log("ImGuiWindowTest");
		}
	}
}
