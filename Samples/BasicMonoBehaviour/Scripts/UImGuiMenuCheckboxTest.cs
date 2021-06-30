using UImGuiManager.Core;
using UImGuiManager.MenuItem;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuCheckboxTest", menuName = "ImGui/SampleMonoBehaviour/ImGuiMenuCheckboxTest", order = 1)]
	public class UImGuiMenuCheckboxTest : UImGuiMenuCheckboxBase<Empty>
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
