using System;
using AOT;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Networking.Transport;
using Unity.Transforms;

// When server receives projectile request, create projectile and delete request
[UpdateInGroup (typeof (ServerSimulationSystemGroup))]
public class ProjectileServerSystem : ComponentSystem {
  protected override void OnCreate () {
    RequireSingletonForUpdate<EnableNetCubeGhostSendSystemComponent> ();
  }

  protected override void OnUpdate () {
    Entities.WithNone<SendRpcCommandRequestComponent> ().ForEach ((Entity reqEnt, ref ProjectileRequest request, ref ReceiveRpcCommandRequestComponent reqSrc) => {
      PostUpdateCommands.AddComponent<NetworkStreamInGame> (reqSrc.SourceConnection);

      var ghostCollection = GetSingleton<GhostPrefabCollectionComponent> ();
      var ghostId = NetCubeGhostSerializerCollection.FindGhostType<SphereSnapshotData> ();
      var prefab = EntityManager.GetBuffer<GhostPrefabBuffer> (ghostCollection.serverPrefabs) [ghostId].Value;

      var projectile = EntityManager.Instantiate (prefab);
      PostUpdateCommands.AddComponent (projectile, new InitProjectileComponent {
        origin = new float3 (request.ox, request.oy, request.oz)
      });
      PostUpdateCommands.AddComponent (projectile, new ProjectileComponent {
        playerId = request.playerId,
          vector = new float3 (request.vx, request.vy, request.vz),
      });

      PostUpdateCommands.DestroyEntity (reqEnt);
    });
  }
}