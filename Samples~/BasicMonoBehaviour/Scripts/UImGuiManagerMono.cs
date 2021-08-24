using UImGuiManager.Core;

namespace UImGuiManager.EntitiesInspector
{
	public class UImGuiManagerMono : UImGuiManagerBase<Empty>
	{
		public void Start()
		{
			Initialize(default);
			Enable();
		}
	}
}
