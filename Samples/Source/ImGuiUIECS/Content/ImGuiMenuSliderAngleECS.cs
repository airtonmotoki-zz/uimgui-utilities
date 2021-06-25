using ImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderAngleECS", menuName = "ImGui/SampleECS/ImGuiMenuSliderAngleECS", order = 1)]
	public class ImGuiMenuSliderAngleECS : ImGuiMenuSliderAngleBase<World>
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
