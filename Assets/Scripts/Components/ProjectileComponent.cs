using Unity.Entities;
using Unity.Mathematics;

public struct InitProjectileComponent : IComponentData {
  public float3 origin;
}

public struct ProjectileComponent : IComponentData {
  public int playerId;
  public float3 vector;
}