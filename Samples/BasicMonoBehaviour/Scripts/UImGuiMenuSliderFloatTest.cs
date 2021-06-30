using UImGuiManager.Core;
using UImGuiManager.MenuItem;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderFloatTest", menuName = "ImGui/SampleMonoBehaviour/ImGuiMenuSliderFloatTest", order = 1)]
	public class UImGuiMenuSliderFloatTest : UImGuiMenuSliderFloatBase<Empty>
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
