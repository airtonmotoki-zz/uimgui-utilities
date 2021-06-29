using ImGuiNET;
using UImGui;
using UnityEngine;


namespace UImGuiManager.Core
{
	public abstract class UImGuiWindowBase<TContext> : UImGuiMenuItemBase<TContext>
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private ImGuiWindowFlags _flags;

		private bool _open;

		public override bool IsWindow() => true;

		public override void OnLayoutMenu()
		{
			if (ImGui.MenuItem(_name))
			{
				_open = true;
			}
		}

		public override void OnLayout(UImGui.UImGui uImGui)
		{
			if (_open && ImGui.Begin(_name, ref _open, _flags))
			{
				OnLayoutWindow();
				ImGui.End();
			}
		}

		public abstract void OnLayoutWindow();

		public override void RegisterWindow()
		{
			UImGuiUtility.Layout += OnLayout;
		}

		public override void UnregisterWindow()
		{
			UImGuiUtility.Layout -= OnLayout;
		}
	}
}
