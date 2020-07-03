using AOT;
using Unity.Burst;
using Unity.NetCode;
using Unity.Networking.Transport;

[BurstCompile]
public struct ProjectileRequest : IRpcCommand {

  public float ox;
  public float oy;
  public float oz;

  public float vx;
  public float vy;
  public float vz;

  public void Serialize (ref DataStreamWriter writer) {
    writer.WriteFloat (ox);
    writer.WriteFloat (oy);
    writer.WriteFloat (oz);

    writer.WriteFloat (vx);
    writer.WriteFloat (vy);
    writer.WriteFloat (vz);
  }

  public void Deserialize (ref DataStreamReader reader) {
    ox = reader.ReadFloat ();
    oy = reader.ReadFloat ();
    oz = reader.ReadFloat ();

    vx = reader.ReadFloat ();
    vy = reader.ReadFloat ();
    vz = reader.ReadFloat ();
  }

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