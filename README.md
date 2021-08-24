# UImGui Utilities

Package with [UImGui](https://github.com/psydack/uimgui) features.

## Installation

Add on manifest 

```bash
{
  "dependencies": {
    "com.psydack.uimgui": "https://github.com/psydack/uimgui.git",
    "com.airtonmotoki.uimgui-utilities": "https://github.com/airtonmotoki/uimgui-utilities.git",
  }
}
```

## Samples

Import Samples on Package Manager.

## Basic Components

### Menu Manager: 

UImGuiManagerBase<T> is a MonoBehaviour and T is the menu context type. When the menu manager is added to the GameObject, the UImGui will also be added, don't forget to set the values for:
 * Shaders
 * Style
 * Cursor Shape

The default value can be found in UImGui/Resources folder.

```csharp
using UImGuiManager.Core;

public class MenuManager : UImGuiManagerBase<Empty>
{
	public void Start()
	{
		Initialize(default);
		Enable();
	}
}
```

### Menu

UImGuiMenu<T> is a ScriptableObject and T is the menu context type. Is the same type defined in UImGuiManagerBase<T>

```csharp
using UImGuiManager.Core;
using UnityEngine;

[CreateAssetMenu(fileName = "Menu", menuName = "UImGui/MyMenu/Menu", order = 1)]
public class Menu : UImGuiMenu<Empty>
{
	
}
```

### Menu Item

Menu Item Type:
 * UImGuiMenuCheckboxBase<T>
 * UImGuiMenuInputTextBase<T>
 * UImGuiMenuSliderAngleBase<T>
 * UImGuiMenuSliderFloatBase<T>
 * UImGuiMenuSliderIntBase<T>
 * UImGuiMenuSliderVector4Base<T>

All Menu Item Types are ScriptableObject and and T is the menu context type

```csharp
using UImGuiManager.Core;
using UImGuiManager.MenuItem;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuCheckBox", menuName = "UImGui/MyMenu/CheckBox", order = 1)]
public class MenuCheckbox : UImGuiMenuCheckboxBase<Empty>
{
	public bool Value = false;

	public override bool Read()
	{
		return Value;
	}

	public override void Write(bool value)
	{
		Value = value;
		UnityEngine.Debug.Log(value);
		// Code
	}
}
```


### UImGui Window

UImGuiWindowBase<T>, T is menu context type.

```csharp
using UImGuiManager.Core;
using UnityEngine;

[CreateAssetMenu(fileName = "TestWindow", menuName = "UImGui/MyMenu/TestWindow", order = 1)]
public class TestWindow : UImGuiWindowBase<Empty>
{
	public override void OnLayoutWindow()
	{
		// Draw UImGui window here
	}
}
```

## UImGui Unity DOTs Inspector

Create menu manager for Unity.Entities.World context

Add UImguiEntitiesMenuBar

## License
[MIT](https://github.com/airtonmotoki/uimgui-utilities/blob/main/LICENSE)