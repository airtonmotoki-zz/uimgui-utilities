using ImGuiManager.Core;
using ImGuiManager.MenuItem;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderFloatTest", menuName = "ImGui/Sample/ImGuiMenuSliderFloatTest", order = 1)]
	public class ImGuiMenuSliderFloatTest : ImGuiMenuSliderFloatBase<Empty>
	{
		public override float Read()
		{
			return 0f;
		}

		public override void Write(float value)
		{
			UnityEngine.Debug.Log(value);
		}
	}
}
