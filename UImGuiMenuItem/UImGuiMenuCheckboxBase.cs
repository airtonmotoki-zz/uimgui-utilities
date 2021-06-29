using UImGuiManager.Core;
using ImGuiNET;
using UnityEngine;

namespace UImGuiManager.MenuItem
{
	public abstract class UImGuiMenuCheckboxBase<TContext> : UImGuiMenuItemBase<TContext>
	{
		[SerializeField]
		private string _label;

		private bool _value;

		public override bool IsWindow() => false;

		public override void OnLayoutMenu()
		{
			_value = Read();
			if (ImGui.Checkbox(_label, ref _value))
			{
				Write(_value);
			}
		}

		public override void OnLayout(UImGui.UImGui uImGui)
		{
			throw new System.NotImplementedException();
		}

		public override void RegisterWindow()
		{
			throw new System.NotImplementedException();
		}

		public override void UnregisterWindow()
		{
			throw new System.NotImplementedException();
		}

		public abstract void Write(bool value);

		public abstract bool Read();
	}
}
