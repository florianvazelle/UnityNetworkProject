using System;
using AOT;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;
using Unity.Networking.Transport;

// When server receives go in game request, go in game and delete request
[UpdateInGroup (typeof (ServerSimulationSystemGroup))]
public class GoInGameServerSystem : ComponentSystem {
  protected override void OnCreate () {
    RequireSingletonForUpdate<EnableNetCubeGhostSendSystemComponent> ();
  }

  protected override void OnUpdate () {
    Entities.WithNone<SendRpcCommandRequestComponent> ().ForEach ((Entity reqEnt, ref GoInGameRequest req, ref ReceiveRpcCommandRequestComponent reqSrc) => {
      PostUpdateCommands.AddComponent<NetworkStreamInGame> (reqSrc.SourceConnection);
      UnityEngine.Debug.Log (String.Format ("Server setting connection {0} to in game", EntityManager.GetComponentData<NetworkIdComponent> (reqSrc.SourceConnection).Value));

      var ghostCollection = GetSingleton<GhostPrefabCollectionComponent> ();
      var ghostId = NetCubeGhostSerializerCollection.FindGhostType<CubeSnapshotData> ();
      var prefab = EntityManager.GetBuffer<GhostPrefabBuffer> (ghostCollection.serverPrefabs) [ghostId].Value;
      var player = EntityManager.Instantiate (prefab);
      EntityManager.SetComponentData (player, new MovableCubeComponent { PlayerId = EntityManager.GetComponentData<NetworkIdComponent> (reqSrc.SourceConnection).Value });

      PostUpdateCommands.AddBuffer<CubeInput> (player);
      PostUpdateCommands.SetComponent (reqSrc.SourceConnection, new CommandTargetComponent { targetEntity = player });

      PostUpdateCommands.DestroyEntity (reqEnt);
    });
  }
}