using ImGuiManager.Core;
using ImGuiManager.MenuItem;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderAngleTest", menuName = "ImGui/Sample/ImGuiMenuSliderAngleTest", order = 1)]
	public class ImGuiMenuSliderAngleTest : ImGuiMenuSliderAngleBase<Empty>
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
