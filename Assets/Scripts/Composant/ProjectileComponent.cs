using Unity.Entities;
using Unity.Mathematics;

public struct InitProjectileTag : IComponentData {
  public float3 origin;
}

public struct ProjectileComponent : IComponentData {
  public float3 vector;
}