using UImGuiManager.Core;
using UImGuiManager.MenuItem;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderIntTest", menuName = "ImGui/Sample MonoBehaviour/ImGuiMenuSliderIntTest", order = 1)]
	public class UImGuiMenuSliderIntTest : UImGuiMenuSliderIntBase<Empty>
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
