using System;
using Unity.Entities;
using Unity.NetCode;
using Unity.Networking.Transport;
using Unity.Transforms;
using UnityEngine;

public struct CubeInput : ICommandData<CubeInput> {
  public uint Tick => tick;
  public uint tick;
  public int horizontal;
  public int vertical;
  public int rotation;

  public void Deserialize (uint tick, ref DataStreamReader reader) {
    this.tick = tick;
    horizontal = reader.ReadInt ();
    vertical = reader.ReadInt ();
    rotation = reader.ReadInt ();
  }

  public void Serialize (ref DataStreamWriter writer) {
    writer.WriteInt (horizontal);
    writer.WriteInt (vertical);
    writer.WriteInt (rotation);
  }

  public void Deserialize (uint tick, ref DataStreamReader reader, CubeInput baseline,
    NetworkCompressionModel compressionModel) {
    Deserialize (tick, ref reader);
  }

  public void Serialize (ref DataStreamWriter writer, CubeInput baseline, NetworkCompressionModel compressionModel) {
    Serialize (ref writer);
  }
}

public class NetCubeSendCommandSystem : CommandSendSystem<CubeInput> { }
public class NetCubeReceiveCommandSystem : CommandReceiveSystem<CubeInput> { }

[UpdateInGroup (typeof (ClientSimulationSystemGroup))]
public class SampleCubeInput : ComponentSystem {
  private int m_FrameCount;

  protected override void OnCreate () {
    RequireSingletonForUpdate<NetworkIdComponent> ();
    RequireSingletonForUpdate<EnableNetCubeGhostReceiveSystemComponent> ();
  }

  protected override void OnUpdate () {

    var localInput = GetSingleton<CommandTargetComponent> ().targetEntity;
    if (localInput == Entity.Null) {
      var localPlayerId = GetSingleton<NetworkIdComponent> ().Value;
      Entities.WithNone<CubeInput> ().ForEach ((Entity ent, ref Translation trans, ref MovableCubeComponent cube) => {
        if (cube.PlayerId == localPlayerId) {
          PostUpdateCommands.AddBuffer<CubeInput> (ent);
          PostUpdateCommands.SetComponent (GetSingletonEntity<CommandTargetComponent> (), new CommandTargetComponent { targetEntity = ent });
        }
      });
      return;
    }

    var input = default (CubeInput);
    input.tick = World.GetExistingSystem<ClientSimulationSystemGroup> ().ServerTick;
    if (Input.GetKey ("q"))
      input.horizontal -= 1;
    if (Input.GetKey ("d"))
      input.horizontal += 1;
    if (Input.GetKey ("s"))
      input.vertical -= 1;
    if (Input.GetKey ("z"))
      input.vertical += 1;
    if (Input.GetKey ("r"))
      input.rotation += 1;
    if (Input.GetKey ("y"))
      input.rotation -= 1;
    var inputBuffer = EntityManager.GetBuffer<CubeInput> (localInput);
    inputBuffer.AddCommandData (input);

    Vector3 position = EntityManager.GetComponentData<Translation> (localInput).Value;

    ++m_FrameCount;
    if (Input.GetMouseButton (1) && m_FrameCount % 50 == 0) {
      m_FrameCount = 0;

      Plane plane = new Plane (Vector3.up, 0);

      float distance;
      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
      if (plane.Raycast (ray, out distance)) {
        Vector3 vector = ray.GetPoint (distance);
        vector.x = vector.x - position.x;
        vector.y = 0;
        vector.z = vector.z - position.z;
        vector = Vector3.Normalize (vector);

        var projectile = PostUpdateCommands.CreateEntity ();
        PostUpdateCommands.AddComponent (projectile, new ProjectileRequest {
          ox = position.x, oy = position.y, oz = position.z,
            vx = vector.x, vy = vector.y, vz = vector.z,
        });
        PostUpdateCommands.AddComponent (projectile, new SendRpcCommandRequestComponent { TargetConnection = Entity.Null });
      }
    }
  }
}