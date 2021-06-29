using UImGuiManager.Core;
using ImGuiNET;
using UnityEngine;


namespace UImGuiManager.MenuItem
{
	public abstract class UImGuiMenuSliderIntBase<TContext> : UImGuiMenuItemBase<TContext>
	{
		[SerializeField]
		private string _label;
		[SerializeField]
		private int _min;
		[SerializeField]
		private int _max;

		private int _value;

		public override bool IsWindow() => false;

		public override void OnLayoutMenu()
		{
			_value = Read();
			if (ImGui.SliderInt(_label, ref _value, _min, _max))
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

		public abstract void Write(int value);

		public abstract int Read();
	}
}
