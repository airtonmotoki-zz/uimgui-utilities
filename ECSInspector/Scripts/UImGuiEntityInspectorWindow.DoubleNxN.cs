using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(double2x2 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
		}

		public void DrawComponent(double2x3 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
		}

		public void DrawComponent(double2x4 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
			DrawComponent(obj.c3);
		}

		public void DrawComponent(double3x2 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
		}

		public void DrawComponent(double3x3 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
		}

		public void DrawComponent(double3x4 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
			DrawComponent(obj.c3);
		}

		public void DrawComponent(double4x2 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
		}

		public void DrawComponent(double4x3 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
		}

		public void DrawComponent(double4x4 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
			DrawComponent(obj.c3);
		}
	}
}
