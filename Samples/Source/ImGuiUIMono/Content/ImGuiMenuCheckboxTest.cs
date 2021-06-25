using ImGuiManager.Core;
using ImGuiManager.MenuItem;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuCheckboxTest", menuName = "ImGui/Sample/ImGuiMenuCheckboxTest", order = 1)]
	public class ImGuiMenuCheckboxTest : ImGuiMenuCheckboxBase<Empty>
	{
		public override bool Read()
		{
			return false;
		}

		public override void Write(bool value)
		{
			UnityEngine.Debug.Log(value);
		}
	}
}
