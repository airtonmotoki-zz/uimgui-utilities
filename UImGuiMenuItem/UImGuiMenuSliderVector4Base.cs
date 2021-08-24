using UImGuiManager.Core;
using ImGuiNET;
using UnityEngine;

namespace UImGuiManager.MenuItem
{
	public abstract class UImGuiMenuSliderVector4Base<TContext> : UImGuiMenuItemBase<TContext>
	{
		[SerializeField]
		private string _label;
		[SerializeField]
		private float _min;
		[SerializeField]
		private float _max;

		private Vector4 _value;

		public override bool IsWindow() => false;

		public override void OnLayoutMenu()
		{
			_value = Read();

			if (ImGui.SliderFloat4(_label, ref _value, _min, _max))
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

		public abstract void Write(Vector4 value);

		public abstract Vector4 Read();
	}
}
