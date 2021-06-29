using UImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.Samples
{
	[CreateAssetMenu(fileName = "ImGuiMenuInputTextECS", menuName = "ImGui/SampleECS/ImGuiMenuInputTextECS", order = 1)]
	public class UImGuiMenuInputTextECS : UImGuiMenuInputTextBase<World>
	{
		public override string Read()
		{
			return "";
		}

		public override void Write(string value)
		{
			UnityEngine.Debug.Log(Context.Name + " " + value);
		}
	}
}
