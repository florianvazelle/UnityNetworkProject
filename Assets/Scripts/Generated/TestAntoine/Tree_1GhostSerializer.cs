using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Collections;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Rendering;

public struct Tree_1GhostSerializer : IGhostSerializer<Tree_1SnapshotData>
{
    private ComponentType componentTypeLocalToWorld;
    private ComponentType componentTypeNonUniformScale;
    private ComponentType componentTypeRotation;
    private ComponentType componentTypeTranslation;
    private ComponentType componentTypeLinkedEntityGroup;
    // FIXME: These disable safety since all serializers have an instance of the same type - causing aliasing. Should be fixed in a cleaner way
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkComponentType<Rotation> ghostRotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkComponentType<Translation> ghostTranslationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkBufferType<LinkedEntityGroup> ghostLinkedEntityGroupType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Rotation> ghostChild0RotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Translation> ghostChild0TranslationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Rotation> ghostChild1RotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Translation> ghostChild1TranslationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Rotation> ghostChild2RotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Translation> ghostChild2TranslationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Rotation> ghostChild3RotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Translation> ghostChild3TranslationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Rotation> ghostChild4RotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ComponentDataFromEntity<Translation> ghostChild4TranslationType;


    public int CalculateImportance(ArchetypeChunk chunk)
    {
        return 1;
    }

    public int SnapshotSize => UnsafeUtility.SizeOf<Tree_1SnapshotData>();
    public void BeginSerialize(ComponentSystemBase system)
    {
        componentTypeLocalToWorld = ComponentType.ReadWrite<LocalToWorld>();
        componentTypeNonUniformScale = ComponentType.ReadWrite<NonUniformScale>();
        componentTypeRotation = ComponentType.ReadWrite<Rotation>();
        componentTypeTranslation = ComponentType.ReadWrite<Translation>();
        componentTypeLinkedEntityGroup = ComponentType.ReadWrite<LinkedEntityGroup>();
        ghostRotationType = system.GetArchetypeChunkComponentType<Rotation>(true);
        ghostTranslationType = system.GetArchetypeChunkComponentType<Translation>(true);
        ghostLinkedEntityGroupType = system.GetArchetypeChunkBufferType<LinkedEntityGroup>(true);
        ghostChild0RotationType = system.GetComponentDataFromEntity<Rotation>(true);
        ghostChild0TranslationType = system.GetComponentDataFromEntity<Translation>(true);
        ghostChild1RotationType = system.GetComponentDataFromEntity<Rotation>(true);
        ghostChild1TranslationType = system.GetComponentDataFromEntity<Translation>(true);
        ghostChild2RotationType = system.GetComponentDataFromEntity<Rotation>(true);
        ghostChild2TranslationType = system.GetComponentDataFromEntity<Translation>(true);
        ghostChild3RotationType = system.GetComponentDataFromEntity<Rotation>(true);
        ghostChild3TranslationType = system.GetComponentDataFromEntity<Translation>(true);
        ghostChild4RotationType = system.GetComponentDataFromEntity<Rotation>(true);
        ghostChild4TranslationType = system.GetComponentDataFromEntity<Translation>(true);
    }

    public void CopyToSnapshot(ArchetypeChunk chunk, int ent, uint tick, ref Tree_1SnapshotData snapshot, GhostSerializerState serializerState)
    {
        snapshot.tick = tick;
        var chunkDataRotation = chunk.GetNativeArray(ghostRotationType);
        var chunkDataTranslation = chunk.GetNativeArray(ghostTranslationType);
        var chunkDataLinkedEntityGroup = chunk.GetBufferAccessor(ghostLinkedEntityGroupType);
        snapshot.SetRotationValue(chunkDataRotation[ent].Value, serializerState);
        snapshot.SetTranslationValue(chunkDataTranslation[ent].Value, serializerState);
        snapshot.SetChild0RotationValue(ghostChild0RotationType[chunkDataLinkedEntityGroup[ent][1].Value].Value, serializerState);
        snapshot.SetChild0TranslationValue(ghostChild0TranslationType[chunkDataLinkedEntityGroup[ent][1].Value].Value, serializerState);
        snapshot.SetChild1RotationValue(ghostChild1RotationType[chunkDataLinkedEntityGroup[ent][2].Value].Value, serializerState);
        snapshot.SetChild1TranslationValue(ghostChild1TranslationType[chunkDataLinkedEntityGroup[ent][2].Value].Value, serializerState);
        snapshot.SetChild2RotationValue(ghostChild2RotationType[chunkDataLinkedEntityGroup[ent][3].Value].Value, serializerState);
        snapshot.SetChild2TranslationValue(ghostChild2TranslationType[chunkDataLinkedEntityGroup[ent][3].Value].Value, serializerState);
        snapshot.SetChild3RotationValue(ghostChild3RotationType[chunkDataLinkedEntityGroup[ent][4].Value].Value, serializerState);
        snapshot.SetChild3TranslationValue(ghostChild3TranslationType[chunkDataLinkedEntityGroup[ent][4].Value].Value, serializerState);
        snapshot.SetChild4RotationValue(ghostChild4RotationType[chunkDataLinkedEntityGroup[ent][5].Value].Value, serializerState);
        snapshot.SetChild4TranslationValue(ghostChild4TranslationType[chunkDataLinkedEntityGroup[ent][5].Value].Value, serializerState);
    }
}
