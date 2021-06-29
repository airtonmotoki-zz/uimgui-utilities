using UImGuiManager.Core;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiWindowTest", menuName = "ImGui/Sample/ImGuiWindowTest", order = 1)]
	public class UImGuiWindowTest : UImGuiWindowBase<Empty>
	{
		public override void OnLayoutWindow()
		{
			UnityEngine.Debug.Log("ImGuiWindowTest");
		}
	}
}
