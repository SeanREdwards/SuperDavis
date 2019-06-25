using SuperDavis.Interfaces;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileEnemyCollisionHandler
    {
        private ProjectileEnemyCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, IEnemy enemy, CollisionSide side, IWorld world)
        {
            switch (side)
            {
                case CollisionSide.Top:
                case CollisionSide.Bottom:
                case CollisionSide.Left:
                case CollisionSide.Right:                  
                    foreach(IDavis davis in world.Characters)
                    {
                        davis.DavisProjectile.Add(projectile);
                    }
                    world.ObjectToRemove.Add(projectile);
                    world.ObjectToRemove.Add(enemy);
                    break;
                case CollisionSide.None:
                    break;
            }
        }
    }
}
