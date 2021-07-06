using UImGuiManager.Core;
using UImGuiManager.MenuItem;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "ImGuiMenuInputTextTest", menuName = "ImGui/SampleMonoBehaviour/ImGuiMenuInputTextTest", order = 1)]
	public class UImGuiMenuInputTextTest : UImGuiMenuInputTextBase<Empty>
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
