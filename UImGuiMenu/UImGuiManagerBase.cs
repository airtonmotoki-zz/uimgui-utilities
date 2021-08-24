using ImGuiNET;
using System.Collections.Generic;
using UImGui;
using UnityEngine;

namespace UImGuiManager.Core
{
	[RequireComponent(typeof(UImGui.UImGui))]
	[System.Serializable]
	public abstract class UImGuiManagerBase<TContext> : MonoBehaviour
	{
		[SerializeField]
		private string _settings = "imgui.ini";

		[SerializeField]
		private float _settingsAutoSaveTimer = 2f;

		[SerializeField]
		private UImGuiMenuBarBase<TContext> _imGuiMenuBar;

		[SerializeField]
		private List<UImGuiWindowBase<TContext>> _otherWindowsList;

		private bool _loadSettings;
		private bool _saveSettings;
		private float _settingsAutoSaveCurrentTime;

		public void Initialize(TContext context)
		{
			_loadSettings = true;
			_imGuiMenuBar?.Initialize(context);
			for (var index = 0; index < _otherWindowsList.Count; index++)
			{
				_otherWindowsList[index].Initialize(context);
			}
		}

		public void Enable()
		{
			UImGuiUtility.Layout += OnLayout;
		}

		private void OnLayout(UImGui.UImGui uImGui)
		{
			// Load settigns
			if (_loadSettings)
			{
				_loadSettings = false;
				ImGui.LoadIniSettingsFromDisk(_settings);
				RegisterWindow();
			}

			// Draw layout
			_imGuiMenuBar?.OnLayoutMenu();

			// Save settings
			if (_saveSettings)
			{
				_saveSettings = false;
				ImGui.SaveIniSettingsToDisk(_settings);
				_settingsAutoSaveCurrentTime++;
			}
		}

		private void Update()
		{
			// Control auto save timer
			_settingsAutoSaveCurrentTime -= Time.deltaTime;
			if (_settingsAutoSaveCurrentTime < 0)
			{
				_saveSettings = true;
				_settingsAutoSaveCurrentTime = _settingsAutoSaveTimer;
			}
		}

		public void Disable()
		{
			UImGuiUtility.Layout -= OnLayout;
		}

		public void RegisterWindow()
		{
			_imGuiMenuBar?.RegisterWindow();
			for (var index = 0; index < _otherWindowsList.Count; index++)
			{
				_otherWindowsList[index].RegisterWindow();
			}
		}

		public void UnregisterWindow()
		{
			_imGuiMenuBar?.UnregisterWindow();
			for (var index = 0; index < _otherWindowsList.Count; index++)
			{
				_otherWindowsList[index].UnregisterWindow();
			}
		}
	}
}
