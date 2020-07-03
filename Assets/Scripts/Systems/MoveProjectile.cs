using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[UpdateInGroup (typeof (GhostPredictionSystemGroup))]
public class MoveProjectileSystem : ComponentSystem {
  protected override void OnUpdate () {
    var group = World.GetExistingSystem<GhostPredictionSystemGroup> ();
    var tick = group.PredictingTick;
    var deltaTime = Time.DeltaTime;

    Entities.ForEach ((Entity entity, ref Translation trans, ref PredictedGhostComponent prediction, ref InitProjectileComponent projectile) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;
      trans.Value = projectile.origin;
      PostUpdateCommands.RemoveComponent<InitProjectileComponent> (entity);
    });

    Entities.ForEach ((ref Translation trans, ref PredictedGhostComponent prediction, ref ProjectileComponent projectile) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;

      trans.Value += projectile.vector * deltaTime * 3f;
    });
  }
}