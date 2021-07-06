using UImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "ImGuiMenuCheckboxECS", menuName = "ImGui/SampleECS/ImGuiMenuCheckboxECS", order = 1)]
	public class UImGuiMenuCheckboxECS : UImGuiMenuCheckboxBase<World>
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
