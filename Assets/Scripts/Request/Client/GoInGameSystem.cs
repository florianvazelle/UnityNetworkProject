using System;
using AOT;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;
using Unity.Networking.Transport;

// When client has a connection with network id, go in game and tell server to also go in game
[UpdateInGroup (typeof (ClientSimulationSystemGroup))]
public class GoInGameClientSystem : ComponentSystem {
  protected override void OnCreate () {
    RequireSingletonForUpdate<EnableNetCubeGhostReceiveSystemComponent> ();
  }

  protected override void OnUpdate () {
    Entities.WithNone<NetworkStreamInGame> ().ForEach ((Entity ent, ref NetworkIdComponent id) => {
      PostUpdateCommands.AddComponent<NetworkStreamInGame> (ent);
      var req = PostUpdateCommands.CreateEntity ();
      PostUpdateCommands.AddComponent<GoInGameRequest> (req);
      PostUpdateCommands.AddComponent (req, new SendRpcCommandRequestComponent { TargetConnection = ent });
    });
  }
}