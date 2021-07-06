using UImGuiManager.Core;
using Unity.Entities;

namespace UImGuiManager.EntitiesInspector
{
	public class UImGuiManagerECSInspector : UImGuiManagerBase<World>
	{
		public void Start()
		{
			Initialize(World.DefaultGameObjectInjectionWorld);
			Enable();
		}
	}
}
