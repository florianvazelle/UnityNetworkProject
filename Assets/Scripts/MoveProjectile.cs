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

    Entities.ForEach ((ref Translation trans, ref PredictedGhostComponent prediction, ref ProjectileComponent projectile) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;

      trans.Value += projectile.vector * deltaTime * 2f;
    });
  }
}

[UpdateInGroup (typeof (GhostPredictionSystemGroup))]
[UpdateBefore (typeof (MoveProjectileSystem))]
public class InitMoveProjectileSystem : ComponentSystem {
  protected override void OnUpdate () {
    var group = World.GetExistingSystem<GhostPredictionSystemGroup> ();
    var tick = group.PredictingTick;

    Entities.ForEach ((Entity entity, ref Translation trans, ref PredictedGhostComponent prediction, ref InitProjectileTag projectile) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;
      trans.Value = projectile.origin;
      PostUpdateCommands.RemoveComponent<InitProjectileTag> (entity);
    });
  }
}