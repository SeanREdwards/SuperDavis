﻿using SuperDavis.Interfaces;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileBlockCollisionHandler
    {
        private ProjectileBlockCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, CollisionSide side)
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
