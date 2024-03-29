﻿using UImGuiManager.MenuItem;
using Unity.Entities;
using UnityEngine;

namespace UImGuiManager.EntitiesInspector
{

	[CreateAssetMenu(fileName = "ImGuiMenuSliderIntECS", menuName = "ImGui/Sample ECS/ImGuiMenuSliderIntECS", order = 1)]
	public class UImGuiMenuSliderIntECS : UImGuiMenuSliderIntBase<World>
	{
		public override int Read()
		{
			return 0;
		}

		public override void Write(int value)
		{
			UnityEngine.Debug.Log(Context.Name + " " + value);
		}
	}
}
