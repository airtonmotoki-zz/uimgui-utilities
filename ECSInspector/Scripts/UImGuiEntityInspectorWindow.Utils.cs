using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using Unity.Mathematics;

namespace UImGuiManager.EntitiesInspector
{
	public partial class UImGuiEntityInspectorWindow
	{
		private static bool IsFlag(ComponentType component)
		{
			return !component.IsSharedComponent && !component.IsBuffer && !component.IsManagedComponent && component.IsZeroSized;
		}

		public static List<ComponentType> GetAllFlags(EntityManager entityManager, Entity entity)
		{
			var components = entityManager.GetComponentTypes(entity);

			return components
				.ToList()
				.FindAll(x => IsFlag(x));
		}

		public static List<ComponentType> GetAllNonFlags(EntityManager entityManager, Entity entity)
		{
			var components = entityManager.GetComponentTypes(entity);

			return components
				.ToList()
				.FindAll(x => !IsFlag(x));
		}

		public static object GetComponent(EntityManager entityManager, ComponentType component, Entity entity)
		{
			var entityManagerType = entityManager.GetType();

			var methodName = "";
			if (component.IsSharedComponent)
			{
				methodName = nameof(entityManager.GetSharedComponentData);
			}
			else if (component.IsBuffer)
			{
				methodName = nameof(entityManager.GetBuffer);
			}
			else if (component.IsManagedComponent)
			{
				methodName = nameof(entityManager.GetComponentObject);
			}
			else if (!component.IsZeroSized)
			{
				methodName = nameof(entityManager.GetComponentData);
			}
			else
			{
				return component;
			}
			var genericMethod = entityManagerType.GetMethod(methodName, new Type[] { typeof(Entity) });
			var methodInfo = genericMethod.MakeGenericMethod(component.GetManagedType());

			var obj = methodInfo.Invoke(entityManager, new object[] { entity });

			var type = obj.GetType();

			return obj;
		}
	}
}