using UImGuiManager.Core;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "ImGuiWindowTest", menuName = "ImGui/Sample MonoBehaviour/ImGuiWindowTest", order = 1)]
	public class UImGuiWindowTest : UImGuiWindowBase<Empty>
	{
		public override void OnLayoutWindow()
		{
			UnityEngine.Debug.Log("ImGuiWindowTest");
		}
	}
}
