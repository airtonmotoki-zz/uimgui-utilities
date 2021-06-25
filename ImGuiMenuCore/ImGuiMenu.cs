using ImGuiNET;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImGuiManager.Core
{
	[Serializable]
	public class ImGuiMenu<TContext>
	{
		[SerializeField]
		private string _name;
		[SerializeField]
		private List<ImGuiMenuItemBase<TContext>> _imGuiMenuItemBase;

		public void Initialize(TContext context)
		{
			for (var index = 0; index < _imGuiMenuItemBase.Count; index++)
			{
				_imGuiMenuItemBase[index].Initialize(context);
			}
		}

		public void OnLayoutMenu()
		{
			if (ImGui.BeginMenu(_name))
			{
				for (var index = 0; index < _imGuiMenuItemBase.Count; index++)
				{
					_imGuiMenuItemBase[index].OnLayoutMenu();
				}
				ImGui.EndMenu();
			}
		}

		public void RegisterWindow()
		{
			for (var index = 0; index < _imGuiMenuItemBase.Count; index++)
			{
				if (_imGuiMenuItemBase[index].IsWindow())
				{
					_imGuiMenuItemBase[index].RegisterWindow();
				}
			}
		}

		public void UnregisterWindow()
		{
			for (var index = 0; index < _imGuiMenuItemBase.Count; index++)
			{
				if (_imGuiMenuItemBase[index].IsWindow())
				{
					_imGuiMenuItemBase[index].UnregisterWindow();
				}
			}
		}
	}
}
