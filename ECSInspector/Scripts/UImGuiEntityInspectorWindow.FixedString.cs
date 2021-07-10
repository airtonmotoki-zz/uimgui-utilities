using ImGuiNET;
using Unity.Collections;
using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(FixedString32 obj)
		{
			DrawComponent(obj.ToString());
		}
		public void DrawComponent(FixedString64 obj)
		{
			DrawComponent(obj.ToString());
		}
		public void DrawComponent(FixedString128 obj)
		{
			DrawComponent(obj.ToString());
		}
		public void DrawComponent(FixedString512 obj)
		{
			DrawComponent(obj.ToString());
		}
		public void DrawComponent(FixedString4096 obj)
		{
			DrawComponent(obj.ToString());
		}
	}
}
