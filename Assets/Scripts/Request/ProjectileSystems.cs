using System;
using AOT;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Networking.Transport;
using Unity.Transforms;

// When client has a connection with network id, go in game and tell server to also go in game
[UpdateInGroup (typeof (ClientSimulationSystemGroup))]
public class ProjectileClientSystem : ComponentSystem {
  protected override void OnCreate () {
    RequireSingletonForUpdate<EnableNetCubeGhostReceiveSystemComponent> ();
  }

  protected override void OnUpdate () {
    Entities.WithNone<NetworkStreamInGame> ().ForEach ((Entity ent, ref ProjectileRequest request, ref NetworkIdComponent id) => {
      PostUpdateCommands.AddComponent<NetworkStreamInGame> (ent);
      var entity = PostUpdateCommands.CreateEntity ();
      // PostUpdateCommands.AddComponent (entity, new ProjectileComponent {
      //   origin = new float3 (request.ox, request.oy, request.oz),
      // });
      PostUpdateCommands.AddComponent<ProjectileRequest> (entity);
      PostUpdateCommands.AddComponent (entity, new SendRpcCommandRequestComponent { TargetConnection = ent });
    });
  }
}

// When server receives go in game request, go in game and delete request
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
      PostUpdateCommands.AddComponent (projectile, new InitProjectileTag {
        origin = new float3 (request.ox, request.oy, request.oz)
      });
      PostUpdateCommands.AddComponent (projectile, new ProjectileComponent {
        vector = new float3 (request.vx, request.vy, request.vz),
      });

      PostUpdateCommands.DestroyEntity (reqEnt);
    });
  }
}