using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[UpdateInGroup (typeof (GhostPredictionSystemGroup))]
public class MoveProjectileSystem : ComponentSystem {
  protected override void OnUpdate () {
    var group = World.GetExistingSystem<GhostPredictionSystemGroup> ();
    var tick = group.PredictingTick;

    Entities.ForEach ((ref Translation trans, ref PredictedGhostComponent prediction, ref ProjectileComponent projectile) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;

      trans.Value += projectile.origin;
    });
  }
}