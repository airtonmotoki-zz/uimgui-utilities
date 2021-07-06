using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(float2x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(float2x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(float2x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}

		public void DrawComponent(float3x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(float3x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(float3x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}

		public void DrawComponent(float4x2 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
		}

		public void DrawComponent(float4x3 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
		}

		public void DrawComponent(float4x4 obj, string prefix)
		{
			DrawComponent(obj.c0, prefix);
			DrawComponent(obj.c1, prefix);
			DrawComponent(obj.c2, prefix);
			DrawComponent(obj.c3, prefix);
		}
	}
}
