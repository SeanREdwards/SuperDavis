using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileBlockCollisionHandler
    {
        private ProjectileBlockCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, IBlock block, CollisionSide side, IWorld world)
        {
            if (!(block is EmptyBlock))
            {
                switch (side)
                {
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
}
