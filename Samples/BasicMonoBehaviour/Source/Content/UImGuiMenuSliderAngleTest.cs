using UImGuiManager.Core;
using UImGuiManager.MenuItem;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderAngleTest", menuName = "ImGui/Sample/ImGuiMenuSliderAngleTest", order = 1)]
	public class UImGuiMenuSliderAngleTest : UImGuiMenuSliderAngleBase<Empty>
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
