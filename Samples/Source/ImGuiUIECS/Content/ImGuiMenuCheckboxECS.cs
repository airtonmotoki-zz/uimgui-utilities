using ImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuCheckboxECS", menuName = "ImGui/SampleECS/ImGuiMenuCheckboxECS", order = 1)]
	public class ImGuiMenuCheckboxECS : ImGuiMenuCheckboxBase<World>
	{
		public override bool Read()
		{
			return false;
		}

		public override void Write(bool value)
		{
			UnityEngine.Debug.Log(Context.Name + " " + value);
		}
	}
}
