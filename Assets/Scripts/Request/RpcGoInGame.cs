using System;
using AOT;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;
using Unity.Networking.Transport;

// RPC request from client to server for game to go "in game" and send snapshots / inputs
[BurstCompile]
public struct GoInGameRequest : IRpcCommand {
  // Unused integer for demonstration
  public int value;
  public void Deserialize (ref DataStreamReader reader) {
    value = reader.ReadInt ();
  }

  public void Serialize (ref DataStreamWriter writer) {
    writer.WriteInt (value);
  }

  [BurstCompile]
  [MonoPInvokeCallback (typeof (RpcExecutor.ExecuteDelegate))]
  private static void InvokeExecute (ref RpcExecutor.Parameters parameters) {
    RpcExecutor.ExecuteCreateRequestComponent<GoInGameRequest> (ref parameters);
  }

  static PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer =
    new PortableFunctionPointer<RpcExecutor.ExecuteDelegate> (InvokeExecute);
  public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute () {
    return InvokeExecuteFunctionPointer;
  }
}

// The system that makes the RPC request component transfer
public class GoInGameRequestSystem : RpcCommandRequestSystem<GoInGameRequest> { }