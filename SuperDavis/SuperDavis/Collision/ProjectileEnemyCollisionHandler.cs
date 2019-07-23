﻿using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileEnemyCollisionHandler
    {
        private ProjectileEnemyCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, IEnemy enemy, CollisionSide side, IWorld world)
        {
            if (!(enemy.PhysicsState is EnemyDeadState))
                switch (side)
                {
                    case CollisionSide.Top:
                    case CollisionSide.Bottom:
                    case CollisionSide.Left:
                    case CollisionSide.Right:
                        if (!(projectile.PhysicsState is NullPhysicsState))
                              projectile.Explode();
                        enemy.TakeDamage();
                        break;
                    case CollisionSide.None:
                        break;
            }
        }
    }
}
