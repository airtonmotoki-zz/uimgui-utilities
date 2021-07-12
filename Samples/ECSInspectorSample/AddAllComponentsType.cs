using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct StructWithInt
{
	public int Value;
}

// Flags

public struct Flag1 : IComponentData { }
public struct Flag2 : IComponentData { }
public struct Flag3 : IComponentData { }
public struct Flag4 : IComponentData { }
public struct Flag5 : IComponentData { }

// struct IComponentData

public struct ComponentDataWithInt : IComponentData
{
	public int Value;
}

public struct ComponentDataWithFixedString32 : IComponentData
{
	public FixedString32 Value;
}

public struct ComponentDataWithfloat3 : IComponentData
{
	public float3 Value;
}

public struct ComponentDataWithStruct : IComponentData
{
	public StructWithInt Value;
}

// class IComponentData

public class ComponentDataWithArray : IComponentData
{
	public int[] Values;
}

public class ComponentDataWithNativeArray : IComponentData
{
	public NativeArray<int> Values;
}

// IBufferElementData

public struct BufferElementDataWithInt : IBufferElementData
{
	public int Value;
}

public struct BufferElementDataWithFixedString32 : IBufferElementData
{
	public FixedString32 Value;
}

public struct BufferElementDataWithfloat3 : IBufferElementData
{
	public float3 Value;
}
public struct BufferElementDataWithStruct : IBufferElementData
{
	public StructWithInt Value;
}

public class AddAllComponentsType : MonoBehaviour, IConvertGameObjectToEntity
{
	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		dstManager.AddComponent<Flag1>(entity);
		dstManager.AddComponent<Flag2>(entity);
		dstManager.AddComponent<Flag3>(entity);
		dstManager.AddComponent<Flag4>(entity);
		dstManager.AddComponent<Flag5>(entity);

		dstManager.AddComponentData(entity, new ComponentDataWithInt
		{
			Value = 1
		});
		dstManager.AddComponentData(entity, new ComponentDataWithFixedString32
		{
			Value = "SampleValue"
		});
		dstManager.AddComponentData(entity, new ComponentDataWithfloat3
		{
			Value = new float3(3, 4, 5)
		});
		dstManager.AddComponentData(entity, new ComponentDataWithStruct
		{
			Value = new StructWithInt
			{
				Value = 2
			}
		});

		dstManager.AddComponentObject(entity, new ComponentDataWithArray
		{
			Values = new int[] { 101, 102, 103, 104, 105 }
		});

		var data = new NativeArray<int>(10, Allocator.Persistent);
		for(var index = 0; index < data.Length; index++)
		{
			data[index] = index * 3;
		}

		dstManager.AddComponentData(entity, new ComponentDataWithNativeArray
		{
			Values = data
		});

		var bufferInt = dstManager.AddBuffer<BufferElementDataWithInt>(entity);
		bufferInt.Add(new BufferElementDataWithInt { Value = 10 });
		bufferInt.Add(new BufferElementDataWithInt { Value = 11 });
		bufferInt.Add(new BufferElementDataWithInt { Value = 12 });
		bufferInt.Add(new BufferElementDataWithInt { Value = 13 });

		var bufferFixedString = dstManager.AddBuffer<BufferElementDataWithFixedString32>(entity);
		bufferFixedString.Add(new BufferElementDataWithFixedString32 { Value = "14" });
		bufferFixedString.Add(new BufferElementDataWithFixedString32 { Value = "15" });
		bufferFixedString.Add(new BufferElementDataWithFixedString32 { Value = "16" });
		bufferFixedString.Add(new BufferElementDataWithFixedString32 { Value = "17" });

		var bufferFloat3 = dstManager.AddBuffer<BufferElementDataWithfloat3>(entity);
		bufferFloat3.Add(new BufferElementDataWithfloat3 { Value = new float3(18) });
		bufferFloat3.Add(new BufferElementDataWithfloat3 { Value = new float3(19) });
		bufferFloat3.Add(new BufferElementDataWithfloat3 { Value = new float3(20) });
		bufferFloat3.Add(new BufferElementDataWithfloat3 { Value = new float3(21) });

		var bufferStruct = dstManager.AddBuffer<BufferElementDataWithStruct>(entity);
		bufferStruct.Add(new BufferElementDataWithStruct { Value = new StructWithInt { Value = 22 } });
		bufferStruct.Add(new BufferElementDataWithStruct { Value = new StructWithInt { Value = 23 } });
		bufferStruct.Add(new BufferElementDataWithStruct { Value = new StructWithInt { Value = 24 } });
		bufferStruct.Add(new BufferElementDataWithStruct { Value = new StructWithInt { Value = 25 } });
	}
}

public class DisposeComponentDataWithNativeArraySystem : SystemBase
{
	protected override void OnUpdate()
	{
		
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();

		Entities.ForEach((ComponentDataWithNativeArray componentDataWithNativeArray) =>
		{
			componentDataWithNativeArray.Values.Dispose();
		}).WithoutBurst().Run();
	}
}
