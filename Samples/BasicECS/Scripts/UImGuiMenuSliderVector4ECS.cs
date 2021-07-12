using UImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{
	[CreateAssetMenu(fileName = "ImGuiMenuSliderVector4ECS", menuName = "ImGui/Sample ECS/ImGuiMenuSliderVector4ECS", order = 1)]
	public class UImGuiMenuSliderVector4ECS : UImGuiMenuSliderVector4Base<World>
	{
		public override Vector4 Read()
		{
			return Vector4.zero;
		}

		public override void Write(Vector4 value)
		{
			UnityEngine.Debug.Log(Context.Name + " " + value);
		}
	}
}
