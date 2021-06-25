using ImGuiManager.Core;
using ImGuiManager.MenuItem;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderIntTest", menuName = "ImGui/Sample/ImGuiMenuSliderIntTest", order = 1)]
	public class ImGuiMenuSliderIntTest : ImGuiMenuSliderIntBase<Empty>
	{
		public override int Read()
		{
			return 0;
		}

		public override void Write(int value)
		{
			UnityEngine.Debug.Log(value);
		}
	}
}
