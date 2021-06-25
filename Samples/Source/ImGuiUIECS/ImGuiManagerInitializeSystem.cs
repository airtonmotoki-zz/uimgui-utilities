//using Unity.Entities;

//public class ImGuiManagerEnableSystem : SystemBase
//{
//	private struct ImGuiEnable : IComponentData { }

//	protected override void OnUpdate()
//	{
//		throw new System.NotImplementedException();
//	}
//}

//public class ImGuiManagerInitializeSystem : SystemBase
//{
//	private struct ImGuiInitialized : IComponentData { }

//	private EntityQuery _query;

//	protected override void OnCreate()
//	{
//		base.OnCreate();

//		_query = GetEntityQuery(ComponentType.ReadOnly<ShowDebugBar>());
//	}

//	protected override void OnUpdate()
//	{
//		Entities
//			.WithNone<ImGuiInitialized>()
//			.ForEach((Entity entity, ImGuiManagerECS imGuiManagerECS) =>
//			{
//				imGuiManagerECS.Initialize(World);
//				EntityManager.AddComponent<ImGuiInitialized>(entity);
//			})
//			.WithStructuralChanges()
//			.Run();

//		if (_query.CalculateEntityCount() > 0)
//		{
//			Entities
//				.WithAll<ImGuiInitialized>()
//				.WithNone<ImGuiEnable>()
//				.ForEach((Entity entity, ImGuiManagerECS imGuiManagerECS) =>
//				{
//					imGuiManagerECS.Enable();
//					EntityManager.AddComponent<ImGuiEnable>(entity);
//				})
//				.WithStructuralChanges()
//				.Run();
//		}
//		else
//		{
//			Entities
//				.WithAll<ImGuiInitialized, ImGuiEnable>()
//				.ForEach((Entity entity, ImGuiManagerECS imGuiManagerECS) =>
//				{
//					imGuiManagerECS.Disable();
//					EntityManager.RemoveComponent<ImGuiEnable>(entity);
//				})
//				.WithStructuralChanges()
//				.Run();
//		}
//	}

//	protected override void OnDestroy()
//	{
//		base.OnDestroy();

//		Entities
//			.WithAll<ImGuiInitialized, ImGuiEnable>()
//			.ForEach((Entity entity, ImGuiManagerECS imGuiManagerECS) =>
//			{
//				imGuiManagerECS.Disable();
//			})
//			.WithStructuralChanges()
//			.Run();
//	}
//}
