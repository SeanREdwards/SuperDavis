using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileBlockCollisionHandler
    {
        private ProjectileBlockCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, CollisionSide side, IWorld world)
        {

            switch (side)
            {
                case CollisionSide.Left:
                case CollisionSide.Right:
                    if(!(projectile.PhysicsState is NullPhysicsState))
                        projectile.Explode();
                    break;
                case CollisionSide.None:
                    break;
            }
        }
    }
}
