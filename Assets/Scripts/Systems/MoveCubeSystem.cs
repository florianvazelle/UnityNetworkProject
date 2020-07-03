using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[UpdateInGroup (typeof (GhostPredictionSystemGroup))]
public class MoveCubeSystem : ComponentSystem {
  protected override void OnUpdate () {
    var group = World.GetExistingSystem<GhostPredictionSystemGroup> ();
    var tick = group.PredictingTick;
    var deltaTime = Time.DeltaTime;

    Entities.ForEach ((DynamicBuffer<CubeInput> inputBuffer, ref Translation trans, ref Rotation rot, ref PredictedGhostComponent prediction) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;

      CubeInput input;
      inputBuffer.GetDataAtTick (tick, out input);

      // Translation
      if (input.horizontal > 0)
        trans.Value.x += deltaTime;
      if (input.horizontal < 0)
        trans.Value.x -= deltaTime;
      if (input.vertical > 0)
        trans.Value.z += deltaTime;
      if (input.vertical < 0)
        trans.Value.z -= deltaTime;

      // Rotation
      if (input.rotation < 0)
        rot.Value = math.mul (math.normalize (rot.Value), quaternion.AxisAngle (math.up (), -0.2f * deltaTime));
      if (input.rotation > 0)
        rot.Value = math.mul (math.normalize (rot.Value), quaternion.AxisAngle (math.up (), 0.2f * deltaTime));
    });
  }
}