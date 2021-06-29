using UImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderAngleECS", menuName = "ImGui/SampleECS/ImGuiMenuSliderAngleECS", order = 1)]
	public class UImGuiMenuSliderAngleECS : UImGuiMenuSliderAngleBase<World>
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
