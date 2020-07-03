using System;
using AOT;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;
using Unity.Networking.Transport;

// Control system updating in the default world
[UpdateInWorld (UpdateInWorld.TargetWorld.Default)]
public class InitGame : ComponentSystem {
  // Singleton component to trigger connections once from a control system
  struct InitGameComponent : IComponentData { }
  protected override void OnCreate () {
    RequireSingletonForUpdate<InitGameComponent> ();
    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name != "NetCube")
      return;
    // Create singleton, require singleton for update so system runs once
    EntityManager.CreateEntity (typeof (InitGameComponent));
  }

  protected override void OnUpdate () {
    // Destroy singleton to prevent system from running again
    EntityManager.DestroyEntity (GetSingletonEntity<InitGameComponent> ());
    foreach (var world in World.All) {
      var network = world.GetExistingSystem<NetworkStreamReceiveSystem> ();
      if (world.GetExistingSystem<ClientSimulationSystemGroup> () != null) {
        // Client worlds automatically connect to localhost
        NetworkEndPoint ep = NetworkEndPoint.LoopbackIpv4;
        ep.Port = 7979;
#if UNITY_EDITOR
        ep = NetworkEndPoint.Parse (ClientServerBootstrap.RequestedAutoConnect, 7979);
#endif
        network.Connect (ep);
      }
#if UNITY_EDITOR || UNITY_SERVER
      else if (world.GetExistingSystem<ServerSimulationSystemGroup> () != null) {
        // Server world automatically listen for connections from any host
        NetworkEndPoint ep = NetworkEndPoint.AnyIpv4;
        ep.Port = 7979;
        network.Listen (ep);
      }
#endif
    }
  }
}