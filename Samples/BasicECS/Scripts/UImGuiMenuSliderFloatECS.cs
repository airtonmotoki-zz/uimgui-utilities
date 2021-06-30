using UImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderFloatECS", menuName = "ImGui/SampleECS/ImGuiMenuSliderFloatECS", order = 1)]
	public class UImGuiMenuSliderFloatECS : UImGuiMenuSliderFloatBase<World>
	{
		public override float Read()
		{
			return 0f;
		}

		public override void Write(float value)
		{
			UnityEngine.Debug.Log(Context.Name + " " + value);
		}
	}
}
