using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(int2x2 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
		}

		public void DrawComponent(int2x3 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
		}

		public void DrawComponent(int2x4 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
			DrawComponent(obj.c3);
		}

		public void DrawComponent(int3x2 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
		}

		public void DrawComponent(int3x3 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
		}

		public void DrawComponent(int3x4 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
			DrawComponent(obj.c3);
		}

		public void DrawComponent(int4x2 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
		}

		public void DrawComponent(int4x3 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
		}

		public void DrawComponent(int4x4 obj)
		{
			DrawComponent(obj.c0);
			DrawComponent(obj.c1);
			DrawComponent(obj.c2);
			DrawComponent(obj.c3);
		}
	}
}
