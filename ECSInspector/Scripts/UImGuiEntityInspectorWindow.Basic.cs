using ImGuiNET;
using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		public void DrawComponent(string label, ImGuiTreeNodeFlags treeNodeFlag = ImGuiTreeNodeFlags.None)
		{
			if(ImGui.TreeNodeEx(label, treeNodeFlag))
			{
				ImGui.TreePop();
			}
		}

		public void DrawComponent(int2 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(int3 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(int4 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(uint2 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(uint3 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(uint4 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(float2 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(float3 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(float4 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(quaternion obj)
		{
			DrawComponent(obj.value);
		}

		public void DrawComponent(double2 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(double3 obj)
		{
			DrawComponent(obj.ToString());
		}

		public void DrawComponent(double4 obj)
		{
			DrawComponent(obj.ToString());
		}
	}
}