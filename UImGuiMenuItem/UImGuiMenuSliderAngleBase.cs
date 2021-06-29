using UImGuiManager.Core;
using ImGuiNET;
using UnityEngine;


namespace UImGuiManager.MenuItem
{
	public abstract class UImGuiMenuSliderAngleBase<TContext> : UImGuiMenuItemBase<TContext>
	{
		[SerializeField]
		private string _label;
		[SerializeField]
		private float _minDegrees;
		[SerializeField]
		private float _maxDegrees;
		
		private float _value;

		public override bool IsWindow() => false;

		public override void OnLayoutMenu()
		{
			_value = Read();
			if (ImGui.SliderAngle(_label, ref _value, _minDegrees, _maxDegrees))
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

		public abstract void Write(float value);

		public abstract float Read();
	}
}
