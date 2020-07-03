using Unity.Networking.Transport;
using Unity.NetCode;
using Unity.Mathematics;

public struct Tree_1SnapshotData : ISnapshotData<Tree_1SnapshotData>
{
    public uint tick;
    private int RotationValueX;
    private int RotationValueY;
    private int RotationValueZ;
    private int RotationValueW;
    private int TranslationValueX;
    private int TranslationValueY;
    private int TranslationValueZ;
    private int Child0RotationValueX;
    private int Child0RotationValueY;
    private int Child0RotationValueZ;
    private int Child0RotationValueW;
    private int Child0TranslationValueX;
    private int Child0TranslationValueY;
    private int Child0TranslationValueZ;
    private int Child1RotationValueX;
    private int Child1RotationValueY;
    private int Child1RotationValueZ;
    private int Child1RotationValueW;
    private int Child1TranslationValueX;
    private int Child1TranslationValueY;
    private int Child1TranslationValueZ;
    private int Child2RotationValueX;
    private int Child2RotationValueY;
    private int Child2RotationValueZ;
    private int Child2RotationValueW;
    private int Child2TranslationValueX;
    private int Child2TranslationValueY;
    private int Child2TranslationValueZ;
    private int Child3RotationValueX;
    private int Child3RotationValueY;
    private int Child3RotationValueZ;
    private int Child3RotationValueW;
    private int Child3TranslationValueX;
    private int Child3TranslationValueY;
    private int Child3TranslationValueZ;
    private int Child4RotationValueX;
    private int Child4RotationValueY;
    private int Child4RotationValueZ;
    private int Child4RotationValueW;
    private int Child4TranslationValueX;
    private int Child4TranslationValueY;
    private int Child4TranslationValueZ;
    uint changeMask0;

    public uint Tick => tick;
    public quaternion GetRotationValue(GhostDeserializerState deserializerState)
    {
        return GetRotationValue();
    }
    public quaternion GetRotationValue()
    {
        return new quaternion(RotationValueX * 0.001f, RotationValueY * 0.001f, RotationValueZ * 0.001f, RotationValueW * 0.001f);
    }
    public void SetRotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetRotationValue(q);
    }
    public void SetRotationValue(quaternion q)
    {
        RotationValueX = (int)(q.value.x * 1000);
        RotationValueY = (int)(q.value.y * 1000);
        RotationValueZ = (int)(q.value.z * 1000);
        RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetTranslationValue(GhostDeserializerState deserializerState)
    {
        return GetTranslationValue();
    }
    public float3 GetTranslationValue()
    {
        return new float3(TranslationValueX * 0.01f, TranslationValueY * 0.01f, TranslationValueZ * 0.01f);
    }
    public void SetTranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetTranslationValue(val);
    }
    public void SetTranslationValue(float3 val)
    {
        TranslationValueX = (int)(val.x * 100);
        TranslationValueY = (int)(val.y * 100);
        TranslationValueZ = (int)(val.z * 100);
    }
    public quaternion GetChild0RotationValue(GhostDeserializerState deserializerState)
    {
        return GetChild0RotationValue();
    }
    public quaternion GetChild0RotationValue()
    {
        return new quaternion(Child0RotationValueX * 0.001f, Child0RotationValueY * 0.001f, Child0RotationValueZ * 0.001f, Child0RotationValueW * 0.001f);
    }
    public void SetChild0RotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetChild0RotationValue(q);
    }
    public void SetChild0RotationValue(quaternion q)
    {
        Child0RotationValueX = (int)(q.value.x * 1000);
        Child0RotationValueY = (int)(q.value.y * 1000);
        Child0RotationValueZ = (int)(q.value.z * 1000);
        Child0RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetChild0TranslationValue(GhostDeserializerState deserializerState)
    {
        return GetChild0TranslationValue();
    }
    public float3 GetChild0TranslationValue()
    {
        return new float3(Child0TranslationValueX * 0.01f, Child0TranslationValueY * 0.01f, Child0TranslationValueZ * 0.01f);
    }
    public void SetChild0TranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetChild0TranslationValue(val);
    }
    public void SetChild0TranslationValue(float3 val)
    {
        Child0TranslationValueX = (int)(val.x * 100);
        Child0TranslationValueY = (int)(val.y * 100);
        Child0TranslationValueZ = (int)(val.z * 100);
    }
    public quaternion GetChild1RotationValue(GhostDeserializerState deserializerState)
    {
        return GetChild1RotationValue();
    }
    public quaternion GetChild1RotationValue()
    {
        return new quaternion(Child1RotationValueX * 0.001f, Child1RotationValueY * 0.001f, Child1RotationValueZ * 0.001f, Child1RotationValueW * 0.001f);
    }
    public void SetChild1RotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetChild1RotationValue(q);
    }
    public void SetChild1RotationValue(quaternion q)
    {
        Child1RotationValueX = (int)(q.value.x * 1000);
        Child1RotationValueY = (int)(q.value.y * 1000);
        Child1RotationValueZ = (int)(q.value.z * 1000);
        Child1RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetChild1TranslationValue(GhostDeserializerState deserializerState)
    {
        return GetChild1TranslationValue();
    }
    public float3 GetChild1TranslationValue()
    {
        return new float3(Child1TranslationValueX * 0.01f, Child1TranslationValueY * 0.01f, Child1TranslationValueZ * 0.01f);
    }
    public void SetChild1TranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetChild1TranslationValue(val);
    }
    public void SetChild1TranslationValue(float3 val)
    {
        Child1TranslationValueX = (int)(val.x * 100);
        Child1TranslationValueY = (int)(val.y * 100);
        Child1TranslationValueZ = (int)(val.z * 100);
    }
    public quaternion GetChild2RotationValue(GhostDeserializerState deserializerState)
    {
        return GetChild2RotationValue();
    }
    public quaternion GetChild2RotationValue()
    {
        return new quaternion(Child2RotationValueX * 0.001f, Child2RotationValueY * 0.001f, Child2RotationValueZ * 0.001f, Child2RotationValueW * 0.001f);
    }
    public void SetChild2RotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetChild2RotationValue(q);
    }
    public void SetChild2RotationValue(quaternion q)
    {
        Child2RotationValueX = (int)(q.value.x * 1000);
        Child2RotationValueY = (int)(q.value.y * 1000);
        Child2RotationValueZ = (int)(q.value.z * 1000);
        Child2RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetChild2TranslationValue(GhostDeserializerState deserializerState)
    {
        return GetChild2TranslationValue();
    }
    public float3 GetChild2TranslationValue()
    {
        return new float3(Child2TranslationValueX * 0.01f, Child2TranslationValueY * 0.01f, Child2TranslationValueZ * 0.01f);
    }
    public void SetChild2TranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetChild2TranslationValue(val);
    }
    public void SetChild2TranslationValue(float3 val)
    {
        Child2TranslationValueX = (int)(val.x * 100);
        Child2TranslationValueY = (int)(val.y * 100);
        Child2TranslationValueZ = (int)(val.z * 100);
    }
    public quaternion GetChild3RotationValue(GhostDeserializerState deserializerState)
    {
        return GetChild3RotationValue();
    }
    public quaternion GetChild3RotationValue()
    {
        return new quaternion(Child3RotationValueX * 0.001f, Child3RotationValueY * 0.001f, Child3RotationValueZ * 0.001f, Child3RotationValueW * 0.001f);
    }
    public void SetChild3RotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetChild3RotationValue(q);
    }
    public void SetChild3RotationValue(quaternion q)
    {
        Child3RotationValueX = (int)(q.value.x * 1000);
        Child3RotationValueY = (int)(q.value.y * 1000);
        Child3RotationValueZ = (int)(q.value.z * 1000);
        Child3RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetChild3TranslationValue(GhostDeserializerState deserializerState)
    {
        return GetChild3TranslationValue();
    }
    public float3 GetChild3TranslationValue()
    {
        return new float3(Child3TranslationValueX * 0.01f, Child3TranslationValueY * 0.01f, Child3TranslationValueZ * 0.01f);
    }
    public void SetChild3TranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetChild3TranslationValue(val);
    }
    public void SetChild3TranslationValue(float3 val)
    {
        Child3TranslationValueX = (int)(val.x * 100);
        Child3TranslationValueY = (int)(val.y * 100);
        Child3TranslationValueZ = (int)(val.z * 100);
    }
    public quaternion GetChild4RotationValue(GhostDeserializerState deserializerState)
    {
        return GetChild4RotationValue();
    }
    public quaternion GetChild4RotationValue()
    {
        return new quaternion(Child4RotationValueX * 0.001f, Child4RotationValueY * 0.001f, Child4RotationValueZ * 0.001f, Child4RotationValueW * 0.001f);
    }
    public void SetChild4RotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetChild4RotationValue(q);
    }
    public void SetChild4RotationValue(quaternion q)
    {
        Child4RotationValueX = (int)(q.value.x * 1000);
        Child4RotationValueY = (int)(q.value.y * 1000);
        Child4RotationValueZ = (int)(q.value.z * 1000);
        Child4RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetChild4TranslationValue(GhostDeserializerState deserializerState)
    {
        return GetChild4TranslationValue();
    }
    public float3 GetChild4TranslationValue()
    {
        return new float3(Child4TranslationValueX * 0.01f, Child4TranslationValueY * 0.01f, Child4TranslationValueZ * 0.01f);
    }
    public void SetChild4TranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetChild4TranslationValue(val);
    }
    public void SetChild4TranslationValue(float3 val)
    {
        Child4TranslationValueX = (int)(val.x * 100);
        Child4TranslationValueY = (int)(val.y * 100);
        Child4TranslationValueZ = (int)(val.z * 100);
    }

    public void PredictDelta(uint tick, ref Tree_1SnapshotData baseline1, ref Tree_1SnapshotData baseline2)
    {
        var predictor = new GhostDeltaPredictor(tick, this.tick, baseline1.tick, baseline2.tick);
        RotationValueX = predictor.PredictInt(RotationValueX, baseline1.RotationValueX, baseline2.RotationValueX);
        RotationValueY = predictor.PredictInt(RotationValueY, baseline1.RotationValueY, baseline2.RotationValueY);
        RotationValueZ = predictor.PredictInt(RotationValueZ, baseline1.RotationValueZ, baseline2.RotationValueZ);
        RotationValueW = predictor.PredictInt(RotationValueW, baseline1.RotationValueW, baseline2.RotationValueW);
        TranslationValueX = predictor.PredictInt(TranslationValueX, baseline1.TranslationValueX, baseline2.TranslationValueX);
        TranslationValueY = predictor.PredictInt(TranslationValueY, baseline1.TranslationValueY, baseline2.TranslationValueY);
        TranslationValueZ = predictor.PredictInt(TranslationValueZ, baseline1.TranslationValueZ, baseline2.TranslationValueZ);
        Child0RotationValueX = predictor.PredictInt(Child0RotationValueX, baseline1.Child0RotationValueX, baseline2.Child0RotationValueX);
        Child0RotationValueY = predictor.PredictInt(Child0RotationValueY, baseline1.Child0RotationValueY, baseline2.Child0RotationValueY);
        Child0RotationValueZ = predictor.PredictInt(Child0RotationValueZ, baseline1.Child0RotationValueZ, baseline2.Child0RotationValueZ);
        Child0RotationValueW = predictor.PredictInt(Child0RotationValueW, baseline1.Child0RotationValueW, baseline2.Child0RotationValueW);
        Child0TranslationValueX = predictor.PredictInt(Child0TranslationValueX, baseline1.Child0TranslationValueX, baseline2.Child0TranslationValueX);
        Child0TranslationValueY = predictor.PredictInt(Child0TranslationValueY, baseline1.Child0TranslationValueY, baseline2.Child0TranslationValueY);
        Child0TranslationValueZ = predictor.PredictInt(Child0TranslationValueZ, baseline1.Child0TranslationValueZ, baseline2.Child0TranslationValueZ);
        Child1RotationValueX = predictor.PredictInt(Child1RotationValueX, baseline1.Child1RotationValueX, baseline2.Child1RotationValueX);
        Child1RotationValueY = predictor.PredictInt(Child1RotationValueY, baseline1.Child1RotationValueY, baseline2.Child1RotationValueY);
        Child1RotationValueZ = predictor.PredictInt(Child1RotationValueZ, baseline1.Child1RotationValueZ, baseline2.Child1RotationValueZ);
        Child1RotationValueW = predictor.PredictInt(Child1RotationValueW, baseline1.Child1RotationValueW, baseline2.Child1RotationValueW);
        Child1TranslationValueX = predictor.PredictInt(Child1TranslationValueX, baseline1.Child1TranslationValueX, baseline2.Child1TranslationValueX);
        Child1TranslationValueY = predictor.PredictInt(Child1TranslationValueY, baseline1.Child1TranslationValueY, baseline2.Child1TranslationValueY);
        Child1TranslationValueZ = predictor.PredictInt(Child1TranslationValueZ, baseline1.Child1TranslationValueZ, baseline2.Child1TranslationValueZ);
        Child2RotationValueX = predictor.PredictInt(Child2RotationValueX, baseline1.Child2RotationValueX, baseline2.Child2RotationValueX);
        Child2RotationValueY = predictor.PredictInt(Child2RotationValueY, baseline1.Child2RotationValueY, baseline2.Child2RotationValueY);
        Child2RotationValueZ = predictor.PredictInt(Child2RotationValueZ, baseline1.Child2RotationValueZ, baseline2.Child2RotationValueZ);
        Child2RotationValueW = predictor.PredictInt(Child2RotationValueW, baseline1.Child2RotationValueW, baseline2.Child2RotationValueW);
        Child2TranslationValueX = predictor.PredictInt(Child2TranslationValueX, baseline1.Child2TranslationValueX, baseline2.Child2TranslationValueX);
        Child2TranslationValueY = predictor.PredictInt(Child2TranslationValueY, baseline1.Child2TranslationValueY, baseline2.Child2TranslationValueY);
        Child2TranslationValueZ = predictor.PredictInt(Child2TranslationValueZ, baseline1.Child2TranslationValueZ, baseline2.Child2TranslationValueZ);
        Child3RotationValueX = predictor.PredictInt(Child3RotationValueX, baseline1.Child3RotationValueX, baseline2.Child3RotationValueX);
        Child3RotationValueY = predictor.PredictInt(Child3RotationValueY, baseline1.Child3RotationValueY, baseline2.Child3RotationValueY);
        Child3RotationValueZ = predictor.PredictInt(Child3RotationValueZ, baseline1.Child3RotationValueZ, baseline2.Child3RotationValueZ);
        Child3RotationValueW = predictor.PredictInt(Child3RotationValueW, baseline1.Child3RotationValueW, baseline2.Child3RotationValueW);
        Child3TranslationValueX = predictor.PredictInt(Child3TranslationValueX, baseline1.Child3TranslationValueX, baseline2.Child3TranslationValueX);
        Child3TranslationValueY = predictor.PredictInt(Child3TranslationValueY, baseline1.Child3TranslationValueY, baseline2.Child3TranslationValueY);
        Child3TranslationValueZ = predictor.PredictInt(Child3TranslationValueZ, baseline1.Child3TranslationValueZ, baseline2.Child3TranslationValueZ);
        Child4RotationValueX = predictor.PredictInt(Child4RotationValueX, baseline1.Child4RotationValueX, baseline2.Child4RotationValueX);
        Child4RotationValueY = predictor.PredictInt(Child4RotationValueY, baseline1.Child4RotationValueY, baseline2.Child4RotationValueY);
        Child4RotationValueZ = predictor.PredictInt(Child4RotationValueZ, baseline1.Child4RotationValueZ, baseline2.Child4RotationValueZ);
        Child4RotationValueW = predictor.PredictInt(Child4RotationValueW, baseline1.Child4RotationValueW, baseline2.Child4RotationValueW);
        Child4TranslationValueX = predictor.PredictInt(Child4TranslationValueX, baseline1.Child4TranslationValueX, baseline2.Child4TranslationValueX);
        Child4TranslationValueY = predictor.PredictInt(Child4TranslationValueY, baseline1.Child4TranslationValueY, baseline2.Child4TranslationValueY);
        Child4TranslationValueZ = predictor.PredictInt(Child4TranslationValueZ, baseline1.Child4TranslationValueZ, baseline2.Child4TranslationValueZ);
    }

    public void Serialize(int networkId, ref Tree_1SnapshotData baseline, ref DataStreamWriter writer, NetworkCompressionModel compressionModel)
    {
        changeMask0 = (RotationValueX != baseline.RotationValueX ||
                                          RotationValueY != baseline.RotationValueY ||
                                          RotationValueZ != baseline.RotationValueZ ||
                                          RotationValueW != baseline.RotationValueW) ? 1u : 0;
        changeMask0 |= (TranslationValueX != baseline.TranslationValueX ||
                                           TranslationValueY != baseline.TranslationValueY ||
                                           TranslationValueZ != baseline.TranslationValueZ) ? (1u<<1) : 0;
        changeMask0 |= (Child0RotationValueX != baseline.Child0RotationValueX ||
                                           Child0RotationValueY != baseline.Child0RotationValueY ||
                                           Child0RotationValueZ != baseline.Child0RotationValueZ ||
                                           Child0RotationValueW != baseline.Child0RotationValueW) ? (1u<<2) : 0;
        changeMask0 |= (Child0TranslationValueX != baseline.Child0TranslationValueX ||
                                           Child0TranslationValueY != baseline.Child0TranslationValueY ||
                                           Child0TranslationValueZ != baseline.Child0TranslationValueZ) ? (1u<<3) : 0;
        changeMask0 |= (Child1RotationValueX != baseline.Child1RotationValueX ||
                                           Child1RotationValueY != baseline.Child1RotationValueY ||
                                           Child1RotationValueZ != baseline.Child1RotationValueZ ||
                                           Child1RotationValueW != baseline.Child1RotationValueW) ? (1u<<4) : 0;
        changeMask0 |= (Child1TranslationValueX != baseline.Child1TranslationValueX ||
                                           Child1TranslationValueY != baseline.Child1TranslationValueY ||
                                           Child1TranslationValueZ != baseline.Child1TranslationValueZ) ? (1u<<5) : 0;
        changeMask0 |= (Child2RotationValueX != baseline.Child2RotationValueX ||
                                           Child2RotationValueY != baseline.Child2RotationValueY ||
                                           Child2RotationValueZ != baseline.Child2RotationValueZ ||
                                           Child2RotationValueW != baseline.Child2RotationValueW) ? (1u<<6) : 0;
        changeMask0 |= (Child2TranslationValueX != baseline.Child2TranslationValueX ||
                                           Child2TranslationValueY != baseline.Child2TranslationValueY ||
                                           Child2TranslationValueZ != baseline.Child2TranslationValueZ) ? (1u<<7) : 0;
        changeMask0 |= (Child3RotationValueX != baseline.Child3RotationValueX ||
                                           Child3RotationValueY != baseline.Child3RotationValueY ||
                                           Child3RotationValueZ != baseline.Child3RotationValueZ ||
                                           Child3RotationValueW != baseline.Child3RotationValueW) ? (1u<<8) : 0;
        changeMask0 |= (Child3TranslationValueX != baseline.Child3TranslationValueX ||
                                           Child3TranslationValueY != baseline.Child3TranslationValueY ||
                                           Child3TranslationValueZ != baseline.Child3TranslationValueZ) ? (1u<<9) : 0;
        changeMask0 |= (Child4RotationValueX != baseline.Child4RotationValueX ||
                                           Child4RotationValueY != baseline.Child4RotationValueY ||
                                           Child4RotationValueZ != baseline.Child4RotationValueZ ||
                                           Child4RotationValueW != baseline.Child4RotationValueW) ? (1u<<10) : 0;
        changeMask0 |= (Child4TranslationValueX != baseline.Child4TranslationValueX ||
                                           Child4TranslationValueY != baseline.Child4TranslationValueY ||
                                           Child4TranslationValueZ != baseline.Child4TranslationValueZ) ? (1u<<11) : 0;
        writer.WritePackedUIntDelta(changeMask0, baseline.changeMask0, compressionModel);
        if ((changeMask0 & (1 << 0)) != 0)
        {
            writer.WritePackedIntDelta(RotationValueX, baseline.RotationValueX, compressionModel);
            writer.WritePackedIntDelta(RotationValueY, baseline.RotationValueY, compressionModel);
            writer.WritePackedIntDelta(RotationValueZ, baseline.RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(RotationValueW, baseline.RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 1)) != 0)
        {
            writer.WritePackedIntDelta(TranslationValueX, baseline.TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(TranslationValueY, baseline.TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(TranslationValueZ, baseline.TranslationValueZ, compressionModel);
        }
        if ((changeMask0 & (1 << 2)) != 0)
        {
            writer.WritePackedIntDelta(Child0RotationValueX, baseline.Child0RotationValueX, compressionModel);
            writer.WritePackedIntDelta(Child0RotationValueY, baseline.Child0RotationValueY, compressionModel);
            writer.WritePackedIntDelta(Child0RotationValueZ, baseline.Child0RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(Child0RotationValueW, baseline.Child0RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 3)) != 0)
        {
            writer.WritePackedIntDelta(Child0TranslationValueX, baseline.Child0TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(Child0TranslationValueY, baseline.Child0TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(Child0TranslationValueZ, baseline.Child0TranslationValueZ, compressionModel);
        }
        if ((changeMask0 & (1 << 4)) != 0)
        {
            writer.WritePackedIntDelta(Child1RotationValueX, baseline.Child1RotationValueX, compressionModel);
            writer.WritePackedIntDelta(Child1RotationValueY, baseline.Child1RotationValueY, compressionModel);
            writer.WritePackedIntDelta(Child1RotationValueZ, baseline.Child1RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(Child1RotationValueW, baseline.Child1RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 5)) != 0)
        {
            writer.WritePackedIntDelta(Child1TranslationValueX, baseline.Child1TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(Child1TranslationValueY, baseline.Child1TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(Child1TranslationValueZ, baseline.Child1TranslationValueZ, compressionModel);
        }
        if ((changeMask0 & (1 << 6)) != 0)
        {
            writer.WritePackedIntDelta(Child2RotationValueX, baseline.Child2RotationValueX, compressionModel);
            writer.WritePackedIntDelta(Child2RotationValueY, baseline.Child2RotationValueY, compressionModel);
            writer.WritePackedIntDelta(Child2RotationValueZ, baseline.Child2RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(Child2RotationValueW, baseline.Child2RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 7)) != 0)
        {
            writer.WritePackedIntDelta(Child2TranslationValueX, baseline.Child2TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(Child2TranslationValueY, baseline.Child2TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(Child2TranslationValueZ, baseline.Child2TranslationValueZ, compressionModel);
        }
        if ((changeMask0 & (1 << 8)) != 0)
        {
            writer.WritePackedIntDelta(Child3RotationValueX, baseline.Child3RotationValueX, compressionModel);
            writer.WritePackedIntDelta(Child3RotationValueY, baseline.Child3RotationValueY, compressionModel);
            writer.WritePackedIntDelta(Child3RotationValueZ, baseline.Child3RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(Child3RotationValueW, baseline.Child3RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 9)) != 0)
        {
            writer.WritePackedIntDelta(Child3TranslationValueX, baseline.Child3TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(Child3TranslationValueY, baseline.Child3TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(Child3TranslationValueZ, baseline.Child3TranslationValueZ, compressionModel);
        }
        if ((changeMask0 & (1 << 10)) != 0)
        {
            writer.WritePackedIntDelta(Child4RotationValueX, baseline.Child4RotationValueX, compressionModel);
            writer.WritePackedIntDelta(Child4RotationValueY, baseline.Child4RotationValueY, compressionModel);
            writer.WritePackedIntDelta(Child4RotationValueZ, baseline.Child4RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(Child4RotationValueW, baseline.Child4RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 11)) != 0)
        {
            writer.WritePackedIntDelta(Child4TranslationValueX, baseline.Child4TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(Child4TranslationValueY, baseline.Child4TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(Child4TranslationValueZ, baseline.Child4TranslationValueZ, compressionModel);
        }
    }

    public void Deserialize(uint tick, ref Tree_1SnapshotData baseline, ref DataStreamReader reader,
        NetworkCompressionModel compressionModel)
    {
        this.tick = tick;
        changeMask0 = reader.ReadPackedUIntDelta(baseline.changeMask0, compressionModel);
        if ((changeMask0 & (1 << 0)) != 0)
        {
            RotationValueX = reader.ReadPackedIntDelta(baseline.RotationValueX, compressionModel);
            RotationValueY = reader.ReadPackedIntDelta(baseline.RotationValueY, compressionModel);
            RotationValueZ = reader.ReadPackedIntDelta(baseline.RotationValueZ, compressionModel);
            RotationValueW = reader.ReadPackedIntDelta(baseline.RotationValueW, compressionModel);
        }
        else
        {
            RotationValueX = baseline.RotationValueX;
            RotationValueY = baseline.RotationValueY;
            RotationValueZ = baseline.RotationValueZ;
            RotationValueW = baseline.RotationValueW;
        }
        if ((changeMask0 & (1 << 1)) != 0)
        {
            TranslationValueX = reader.ReadPackedIntDelta(baseline.TranslationValueX, compressionModel);
            TranslationValueY = reader.ReadPackedIntDelta(baseline.TranslationValueY, compressionModel);
            TranslationValueZ = reader.ReadPackedIntDelta(baseline.TranslationValueZ, compressionModel);
        }
        else
        {
            TranslationValueX = baseline.TranslationValueX;
            TranslationValueY = baseline.TranslationValueY;
            TranslationValueZ = baseline.TranslationValueZ;
        }
        if ((changeMask0 & (1 << 2)) != 0)
        {
            Child0RotationValueX = reader.ReadPackedIntDelta(baseline.Child0RotationValueX, compressionModel);
            Child0RotationValueY = reader.ReadPackedIntDelta(baseline.Child0RotationValueY, compressionModel);
            Child0RotationValueZ = reader.ReadPackedIntDelta(baseline.Child0RotationValueZ, compressionModel);
            Child0RotationValueW = reader.ReadPackedIntDelta(baseline.Child0RotationValueW, compressionModel);
        }
        else
        {
            Child0RotationValueX = baseline.Child0RotationValueX;
            Child0RotationValueY = baseline.Child0RotationValueY;
            Child0RotationValueZ = baseline.Child0RotationValueZ;
            Child0RotationValueW = baseline.Child0RotationValueW;
        }
        if ((changeMask0 & (1 << 3)) != 0)
        {
            Child0TranslationValueX = reader.ReadPackedIntDelta(baseline.Child0TranslationValueX, compressionModel);
            Child0TranslationValueY = reader.ReadPackedIntDelta(baseline.Child0TranslationValueY, compressionModel);
            Child0TranslationValueZ = reader.ReadPackedIntDelta(baseline.Child0TranslationValueZ, compressionModel);
        }
        else
        {
            Child0TranslationValueX = baseline.Child0TranslationValueX;
            Child0TranslationValueY = baseline.Child0TranslationValueY;
            Child0TranslationValueZ = baseline.Child0TranslationValueZ;
        }
        if ((changeMask0 & (1 << 4)) != 0)
        {
            Child1RotationValueX = reader.ReadPackedIntDelta(baseline.Child1RotationValueX, compressionModel);
            Child1RotationValueY = reader.ReadPackedIntDelta(baseline.Child1RotationValueY, compressionModel);
            Child1RotationValueZ = reader.ReadPackedIntDelta(baseline.Child1RotationValueZ, compressionModel);
            Child1RotationValueW = reader.ReadPackedIntDelta(baseline.Child1RotationValueW, compressionModel);
        }
        else
        {
            Child1RotationValueX = baseline.Child1RotationValueX;
            Child1RotationValueY = baseline.Child1RotationValueY;
            Child1RotationValueZ = baseline.Child1RotationValueZ;
            Child1RotationValueW = baseline.Child1RotationValueW;
        }
        if ((changeMask0 & (1 << 5)) != 0)
        {
            Child1TranslationValueX = reader.ReadPackedIntDelta(baseline.Child1TranslationValueX, compressionModel);
            Child1TranslationValueY = reader.ReadPackedIntDelta(baseline.Child1TranslationValueY, compressionModel);
            Child1TranslationValueZ = reader.ReadPackedIntDelta(baseline.Child1TranslationValueZ, compressionModel);
        }
        else
        {
            Child1TranslationValueX = baseline.Child1TranslationValueX;
            Child1TranslationValueY = baseline.Child1TranslationValueY;
            Child1TranslationValueZ = baseline.Child1TranslationValueZ;
        }
        if ((changeMask0 & (1 << 6)) != 0)
        {
            Child2RotationValueX = reader.ReadPackedIntDelta(baseline.Child2RotationValueX, compressionModel);
            Child2RotationValueY = reader.ReadPackedIntDelta(baseline.Child2RotationValueY, compressionModel);
            Child2RotationValueZ = reader.ReadPackedIntDelta(baseline.Child2RotationValueZ, compressionModel);
            Child2RotationValueW = reader.ReadPackedIntDelta(baseline.Child2RotationValueW, compressionModel);
        }
        else
        {
            Child2RotationValueX = baseline.Child2RotationValueX;
            Child2RotationValueY = baseline.Child2RotationValueY;
            Child2RotationValueZ = baseline.Child2RotationValueZ;
            Child2RotationValueW = baseline.Child2RotationValueW;
        }
        if ((changeMask0 & (1 << 7)) != 0)
        {
            Child2TranslationValueX = reader.ReadPackedIntDelta(baseline.Child2TranslationValueX, compressionModel);
            Child2TranslationValueY = reader.ReadPackedIntDelta(baseline.Child2TranslationValueY, compressionModel);
            Child2TranslationValueZ = reader.ReadPackedIntDelta(baseline.Child2TranslationValueZ, compressionModel);
        }
        else
        {
            Child2TranslationValueX = baseline.Child2TranslationValueX;
            Child2TranslationValueY = baseline.Child2TranslationValueY;
            Child2TranslationValueZ = baseline.Child2TranslationValueZ;
        }
        if ((changeMask0 & (1 << 8)) != 0)
        {
            Child3RotationValueX = reader.ReadPackedIntDelta(baseline.Child3RotationValueX, compressionModel);
            Child3RotationValueY = reader.ReadPackedIntDelta(baseline.Child3RotationValueY, compressionModel);
            Child3RotationValueZ = reader.ReadPackedIntDelta(baseline.Child3RotationValueZ, compressionModel);
            Child3RotationValueW = reader.ReadPackedIntDelta(baseline.Child3RotationValueW, compressionModel);
        }
        else
        {
            Child3RotationValueX = baseline.Child3RotationValueX;
            Child3RotationValueY = baseline.Child3RotationValueY;
            Child3RotationValueZ = baseline.Child3RotationValueZ;
            Child3RotationValueW = baseline.Child3RotationValueW;
        }
        if ((changeMask0 & (1 << 9)) != 0)
        {
            Child3TranslationValueX = reader.ReadPackedIntDelta(baseline.Child3TranslationValueX, compressionModel);
            Child3TranslationValueY = reader.ReadPackedIntDelta(baseline.Child3TranslationValueY, compressionModel);
            Child3TranslationValueZ = reader.ReadPackedIntDelta(baseline.Child3TranslationValueZ, compressionModel);
        }
        else
        {
            Child3TranslationValueX = baseline.Child3TranslationValueX;
            Child3TranslationValueY = baseline.Child3TranslationValueY;
            Child3TranslationValueZ = baseline.Child3TranslationValueZ;
        }
        if ((changeMask0 & (1 << 10)) != 0)
        {
            Child4RotationValueX = reader.ReadPackedIntDelta(baseline.Child4RotationValueX, compressionModel);
            Child4RotationValueY = reader.ReadPackedIntDelta(baseline.Child4RotationValueY, compressionModel);
            Child4RotationValueZ = reader.ReadPackedIntDelta(baseline.Child4RotationValueZ, compressionModel);
            Child4RotationValueW = reader.ReadPackedIntDelta(baseline.Child4RotationValueW, compressionModel);
        }
        else
        {
            Child4RotationValueX = baseline.Child4RotationValueX;
            Child4RotationValueY = baseline.Child4RotationValueY;
            Child4RotationValueZ = baseline.Child4RotationValueZ;
            Child4RotationValueW = baseline.Child4RotationValueW;
        }
        if ((changeMask0 & (1 << 11)) != 0)
        {
            Child4TranslationValueX = reader.ReadPackedIntDelta(baseline.Child4TranslationValueX, compressionModel);
            Child4TranslationValueY = reader.ReadPackedIntDelta(baseline.Child4TranslationValueY, compressionModel);
            Child4TranslationValueZ = reader.ReadPackedIntDelta(baseline.Child4TranslationValueZ, compressionModel);
        }
        else
        {
            Child4TranslationValueX = baseline.Child4TranslationValueX;
            Child4TranslationValueY = baseline.Child4TranslationValueY;
            Child4TranslationValueZ = baseline.Child4TranslationValueZ;
        }
    }
    public void Interpolate(ref Tree_1SnapshotData target, float factor)
    {
        SetRotationValue(math.slerp(GetRotationValue(), target.GetRotationValue(), factor));
        SetTranslationValue(math.lerp(GetTranslationValue(), target.GetTranslationValue(), factor));
        SetChild0RotationValue(math.slerp(GetChild0RotationValue(), target.GetChild0RotationValue(), factor));
        SetChild0TranslationValue(math.lerp(GetChild0TranslationValue(), target.GetChild0TranslationValue(), factor));
        SetChild1RotationValue(math.slerp(GetChild1RotationValue(), target.GetChild1RotationValue(), factor));
        SetChild1TranslationValue(math.lerp(GetChild1TranslationValue(), target.GetChild1TranslationValue(), factor));
        SetChild2RotationValue(math.slerp(GetChild2RotationValue(), target.GetChild2RotationValue(), factor));
        SetChild2TranslationValue(math.lerp(GetChild2TranslationValue(), target.GetChild2TranslationValue(), factor));
        SetChild3RotationValue(math.slerp(GetChild3RotationValue(), target.GetChild3RotationValue(), factor));
        SetChild3TranslationValue(math.lerp(GetChild3TranslationValue(), target.GetChild3TranslationValue(), factor));
        SetChild4RotationValue(math.slerp(GetChild4RotationValue(), target.GetChild4RotationValue(), factor));
        SetChild4TranslationValue(math.lerp(GetChild4TranslationValue(), target.GetChild4TranslationValue(), factor));
    }
}
