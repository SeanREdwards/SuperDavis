using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileBlockCollisionHandler
    {
        private ProjectileBlockCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, IBlock block, CollisionSide side, IWorld world)
        {

                switch (side)
                {
                    case CollisionSide.Top:
                    case CollisionSide.Bottom:
                    case CollisionSide.Left:
                    case CollisionSide.Right:
                        if (!(projectile.PhysicsState is NullPhysicsState))
                            projectile.Explode();
                        break;
                    case CollisionSide.None:
                        break;
                }

        }
    }
}
