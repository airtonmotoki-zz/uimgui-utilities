using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(int2x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(int2x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(int2x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}

		public void DrawComponent(int3x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(int3x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(int3x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}

		public void DrawComponent(int4x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(int4x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(int4x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}
	}
}
