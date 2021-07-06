using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(double2x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(double2x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(double2x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}

		public void DrawComponent(double3x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(double3x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(double3x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}

		public void DrawComponent(double4x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(double4x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(double4x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}
	}
}
