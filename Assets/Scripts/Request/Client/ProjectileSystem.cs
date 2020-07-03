// using System;
// using AOT;
// using Unity.Burst;
// using Unity.Entities;
// using Unity.Mathematics;
// using Unity.NetCode;
// using Unity.Networking.Transport;
// using Unity.Transforms;

// // When client has a connection with network id, go in game and tell server to also go in game
// [UpdateInGroup (typeof (ClientSimulationSystemGroup))]
// public class ProjectileClientSystem : ComponentSystem {
//   protected override void OnCreate () {
//     RequireSingletonForUpdate<EnableNetCubeGhostReceiveSystemComponent> ();
//   }

//   protected override void OnUpdate () {
//     Entities.WithNone<NetworkStreamInGame> ().ForEach ((Entity ent, ref ProjectileRequest request, ref NetworkIdComponent id) => {
//       PostUpdateCommands.AddComponent<NetworkStreamInGame> (ent);
//       var entity = PostUpdateCommands.CreateEntity ();
//       // PostUpdateCommands.AddComponent (entity, new ProjectileComponent {
//       //   origin = new float3 (request.ox, request.oy, request.oz),
//       // });
//       PostUpdateCommands.AddComponent<ProjectileRequest> (entity);
//       PostUpdateCommands.AddComponent (entity, new SendRpcCommandRequestComponent { TargetConnection = ent });
//     });
//   }
// }