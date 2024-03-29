﻿using ImGuiNET;
using System.Collections.Generic;
using UnityEngine;

namespace UImGuiManager.Core
{
	public abstract class UImGuiMenuBarBase<TContext> : ScriptableObject
	{
		[SerializeField]
		private List<UImGuiMenu<TContext>> _imGuiMenuBarContent;

		public void Initialize(TContext context)
		{
			for (var indexMenu = 0; indexMenu < _imGuiMenuBarContent.Count; indexMenu++)
			{
				_imGuiMenuBarContent[indexMenu].Initialize(context);
			}
		}

		public void OnLayoutMenu()
		{
			if (ImGui.BeginMainMenuBar())
			{
				if (ImGui.BeginMenuBar())
				{
					for (var indexMenu = 0; indexMenu < _imGuiMenuBarContent.Count; indexMenu++)
					{
						_imGuiMenuBarContent[indexMenu].OnLayoutMenu();
					}
					ImGui.EndMenuBar();
				}
				ImGui.End();
			}
		}

		public void RegisterWindow()
		{
			for (var indexMenu = 0; indexMenu < _imGuiMenuBarContent.Count; indexMenu++)
			{
				_imGuiMenuBarContent[indexMenu].RegisterWindow();
			}
		}

		public void UnregisterWindow()
		{
			for (var indexMenu = 0; indexMenu < _imGuiMenuBarContent.Count; indexMenu++)
			{
				_imGuiMenuBarContent[indexMenu].UnregisterWindow();
			}
		}
	}
}
