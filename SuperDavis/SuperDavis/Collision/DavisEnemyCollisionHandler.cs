using SuperDavis.Interfaces;
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
                //if collision is not on bottom
                if (side == CollisionSide.Top)
                {
                    if (!enemy.Dead)
                    {
                        enemy.TakeDamage();
                        Variable.score += 100;
                    }
                }
                else
                {
                    if (!enemy.Dead && davis.DavisStatus != DavisStatus.Invincible)
                    {
                        davis.DavisState.Death();
                        Variable.time = 400;
                        Variable.lives--;
                        world.ObjectToRemove.Add(davis);
                    }
                }
            }
        }
    }
}
