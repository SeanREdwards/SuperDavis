using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.Variables;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class DavisEnemyCollisionHandler
    {
        private DavisEnemyCollisionHandler() { }
        public static void HandleCollision(IDavis davis, IEnemy enemy, CollisionSide side, IWorld world)
        {
            if (side != CollisionSide.None)
            {
                if (davis.PhysicsState is FlyingKneeState || davis.PhysicsState is ShoryukenState || davis.PhysicsState is ShunpoState)
                {
                    enemy.TakeDamage();
                    world.HUD.score += 100;
                }

                    //if collision is not on bottom
                if (side == CollisionSide.Top)
                {
                    if (!enemy.Dead && !davis.DeadFlag)
                    {
                        enemy.TakeDamage();
                        world.HUD.score += 100;
                    }
                }
                else
                {
                    if (!enemy.Dead && davis.DavisStatus != DavisStatus.Invincible && !davis.DeadFlag && !(davis.PhysicsState is FlyingKneeState) &&!(davis.PhysicsState is ShoryukenState && !(davis.PhysicsState is ShunpoState)) )
                    {
                        davis.DavisDeath();
                        world.HUD.lives--;
                    }
                }
            }
        }
    }
}
