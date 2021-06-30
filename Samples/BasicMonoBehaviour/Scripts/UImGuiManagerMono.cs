using UImGuiManager.Core;

namespace UImGuiManager.Samples
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
