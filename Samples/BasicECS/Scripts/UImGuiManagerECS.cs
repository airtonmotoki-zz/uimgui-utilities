using UImGuiManager.Core;
using Unity.Entities;

namespace UImGuiManager.Samples
{
	public class UImGuiManagerECS : UImGuiManagerBase<World>
	{
		public void Start()
		{
			Initialize(World.DefaultGameObjectInjectionWorld);
			Enable();
		}
	}
}
