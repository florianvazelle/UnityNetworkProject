using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Networking.Transport;
using Unity.NetCode;

public struct NetCubeGhostSerializerCollection : IGhostSerializerCollection
{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
    public string[] CreateSerializerNameList()
    {
        var arr = new string[]
        {
            "CubeGhostSerializer",
            "SphereGhostSerializer",
            "Tree_1GhostSerializer",
        };
        return arr;
    }

    public int Length => 3;
#endif
    public static int FindGhostType<T>()
        where T : struct, ISnapshotData<T>
    {
        if (typeof(T) == typeof(CubeSnapshotData))
            return 0;
        if (typeof(T) == typeof(SphereSnapshotData))
            return 1;
        if (typeof(T) == typeof(Tree_1SnapshotData))
            return 2;
        return -1;
    }

    public void BeginSerialize(ComponentSystemBase system)
    {
        m_CubeGhostSerializer.BeginSerialize(system);
        m_SphereGhostSerializer.BeginSerialize(system);
        m_Tree_1GhostSerializer.BeginSerialize(system);
    }

    public int CalculateImportance(int serializer, ArchetypeChunk chunk)
    {
        switch (serializer)
        {
            case 0:
                return m_CubeGhostSerializer.CalculateImportance(chunk);
            case 1:
                return m_SphereGhostSerializer.CalculateImportance(chunk);
            case 2:
                return m_Tree_1GhostSerializer.CalculateImportance(chunk);
        }

        throw new ArgumentException("Invalid serializer type");
    }

    public int GetSnapshotSize(int serializer)
    {
        switch (serializer)
        {
            case 0:
                return m_CubeGhostSerializer.SnapshotSize;
            case 1:
                return m_SphereGhostSerializer.SnapshotSize;
            case 2:
                return m_Tree_1GhostSerializer.SnapshotSize;
        }

        throw new ArgumentException("Invalid serializer type");
    }

    public int Serialize(ref DataStreamWriter dataStream, SerializeData data)
    {
        switch (data.ghostType)
        {
            case 0:
            {
                return GhostSendSystem<NetCubeGhostSerializerCollection>.InvokeSerialize<CubeGhostSerializer, CubeSnapshotData>(m_CubeGhostSerializer, ref dataStream, data);
            }
            case 1:
            {
                return GhostSendSystem<NetCubeGhostSerializerCollection>.InvokeSerialize<SphereGhostSerializer, SphereSnapshotData>(m_SphereGhostSerializer, ref dataStream, data);
            }
            case 2:
            {
                return GhostSendSystem<NetCubeGhostSerializerCollection>.InvokeSerialize<Tree_1GhostSerializer, Tree_1SnapshotData>(m_Tree_1GhostSerializer, ref dataStream, data);
            }
            default:
                throw new ArgumentException("Invalid serializer type");
        }
    }
    private CubeGhostSerializer m_CubeGhostSerializer;
    private SphereGhostSerializer m_SphereGhostSerializer;
    private Tree_1GhostSerializer m_Tree_1GhostSerializer;
}

public struct EnableNetCubeGhostSendSystemComponent : IComponentData
{}
public class NetCubeGhostSendSystem : GhostSendSystem<NetCubeGhostSerializerCollection>
{
    protected override void OnCreate()
    {
        base.OnCreate();
        RequireSingletonForUpdate<EnableNetCubeGhostSendSystemComponent>();
    }

    public override bool IsEnabled()
    {
        return HasSingleton<EnableNetCubeGhostSendSystemComponent>();
    }
}
