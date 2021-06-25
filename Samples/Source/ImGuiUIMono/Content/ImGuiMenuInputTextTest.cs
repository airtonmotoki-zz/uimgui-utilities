using ImGuiManager.Core;
using ImGuiManager.MenuItem;
using UnityEngine;

namespace ImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuInputTextTest", menuName = "ImGui/Sample/ImGuiMenuInputTextTest", order = 1)]
	public class ImGuiMenuInputTextTest : ImGuiMenuInputTextBase<Empty>
	{
		public override string Read()
		{
			return "";
		}

		public override void Write(string value)
		{
			UnityEngine.Debug.Log(value);
		}
	}
}
