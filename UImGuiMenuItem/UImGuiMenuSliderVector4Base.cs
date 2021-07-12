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

			// TODO: Fix when update UImGui to 4.0.0.
			System.Numerics.Vector4 _tempValue = new System.Numerics.Vector4(_value.x, _value.y, _value.z, _value.w);
			if (ImGui.SliderFloat4(_label, ref _tempValue, _min, _max))
			{
				_value = new Vector4(_tempValue.X, _tempValue.Y, _tempValue.Z, _tempValue.W);
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
