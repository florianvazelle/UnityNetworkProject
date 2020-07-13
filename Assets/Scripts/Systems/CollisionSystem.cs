using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[UpdateInGroup (typeof (GhostPredictionSystemGroup))]
public class CollisionSystem : ComponentSystem {
  private EntityQuery projectileQuery;

  protected override void OnCreate () {
    projectileQuery = GetEntityQuery (ComponentType.ReadOnly<ProjectileComponent> (), ComponentType.ReadWrite<Translation> ());
  }

  protected override void OnUpdate () {
    var group = World.GetExistingSystem<GhostPredictionSystemGroup> ();
    var tick = group.PredictingTick;

    var projectiles = projectileQuery.ToEntityArray (Allocator.TempJob);
    var projectilePositions = projectileQuery.ToComponentDataArray<Translation> (Allocator.TempJob);
    var projectileId = projectileQuery.ToComponentDataArray<ProjectileComponent> (Allocator.TempJob);

    Entities.ForEach ((ref Translation trans, ref MovableCubeComponent cube, ref PredictedGhostComponent prediction) => {
      if (!GhostPredictionSystemGroup.ShouldPredict (tick, prediction))
        return;

      Rectangle rect = new Rectangle { x = trans.Value.x - 0.5f, y = trans.Value.z - 0.5f, width = 1, height = 1 };

      for (var j = 0; j < projectiles.Length; j++) {
        if (projectileId[j].playerId != cube.PlayerId) {

          Circle circle = new Circle { x = projectilePositions[j].Value.x, y = projectilePositions[j].Value.z, radius = 0.5f };
          if (CircleToRectangle (circle, rect)) {
            // UI.Instance.updatePlayerScore (cube.PlayerId);
            // Death
            trans.Value = new float3 (0, 0.5f, 0);
            PostUpdateCommands.SetComponent (projectiles[j], new Translation { Value = new float3 (100, 0, 100) });
          }
        }
      }
    });

    projectiles.Dispose ();
    projectilePositions.Dispose ();
    projectileId.Dispose ();
  }

  struct Circle {
    public float x, y, radius;
  }

  struct Rectangle {
    public float x, y, width, height;
  }

  private bool CircleToRectangle (Circle circle, Rectangle rect) {
    var halfWidth = rect.width / 2;
    var halfHeight = rect.height / 2;

    var cx = math.abs (circle.x - rect.x - halfWidth);
    var cy = math.abs (circle.y - rect.y - halfHeight);
    var xDist = halfWidth + circle.radius;
    var yDist = halfHeight + circle.radius;

    if (cx > xDist || cy > yDist) {
      return false;
    } else if (cx <= halfWidth || cy <= halfHeight) {
      return true;
    } else {
      var xCornerDist = cx - halfWidth;
      var yCornerDist = cy - halfHeight;
      var xCornerDistSq = xCornerDist * xCornerDist;
      var yCornerDistSq = yCornerDist * yCornerDist;
      var maxCornerDistSq = circle.radius * circle.radius;

      return (xCornerDistSq + yCornerDistSq <= maxCornerDistSq);
    }
  }
}