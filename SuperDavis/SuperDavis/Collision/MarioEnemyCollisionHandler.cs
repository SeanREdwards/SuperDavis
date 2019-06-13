using SuperDavis.Interfaces;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class MarioEnemyCollisionHandler
    {
        private MarioEnemyCollisionHandler() { }        
        public static void HandleCollision(IDavis davis, IEnemy enemy, CollisionSide side)
        {
            if (side != CollisionSide.None)
            {
                //if collision is not on bottom
                if (side != CollisionSide.Bottom)
                {
                    if (!enemy.Dead)
                    {
                        enemy.TakeDamage();
                    }
                }
                else
                {
                    if (!enemy.Dead)
                    {
                        davis.DavisState.Death();
                    }
                }
            }
        }
    }
}
