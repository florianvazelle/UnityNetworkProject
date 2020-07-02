using AOT;
using Unity.Burst;
using Unity.NetCode;
using Unity.Networking.Transport;

[BurstCompile]
public struct ProjectileRequest : IRpcCommand {
  public void Serialize (ref DataStreamWriter writer) { }

  public void Deserialize (ref DataStreamReader reader) { }

  [BurstCompile]
  [MonoPInvokeCallback (typeof (RpcExecutor.ExecuteDelegate))]
  private static void InvokeExecute (ref RpcExecutor.Parameters parameters) {
    RpcExecutor.ExecuteCreateRequestComponent<ProjectileRequest> (ref parameters);
  }

  static PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer =
    new PortableFunctionPointer<RpcExecutor.ExecuteDelegate> (InvokeExecute);
  public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute () {
    return InvokeExecuteFunctionPointer;
  }
}
class ProjectileRequestRpcCommandRequestSystem : RpcCommandRequestSystem<ProjectileRequest> { }