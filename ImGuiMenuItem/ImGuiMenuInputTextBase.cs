using ImGuiManager.Core;
using ImGuiNET;
using UnityEngine;


namespace ImGuiManager.MenuItem
{
	public abstract class ImGuiMenuInputTextBase<TContext> : ImGuiMenuItemBase<TContext>
	{
		[SerializeField]
		private string _label;
		[SerializeField]
		private uint _lenght;
		[SerializeField]
		private ImGuiInputTextFlags _flags;

		private string _value;

		[SerializeField]
		private string _buttonLabel;

		public override bool IsWindow() => false;

		public override void OnLayoutMenu()
		{
			_value = Read();
			var result = ImGui.InputText(_label, ref _value, _lenght, _flags);
			if ((!string.IsNullOrEmpty(_buttonLabel) && ImGui.Button(_buttonLabel)) || result)
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

		public abstract void Write(string value);

		public abstract string Read();
	}
}
