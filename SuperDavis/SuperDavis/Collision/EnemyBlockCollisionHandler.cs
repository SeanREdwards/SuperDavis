using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.PhysicsState;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class EnemyBlockCollisionHandler
    {

        private EnemyBlockCollisionHandler() { }
        public static void HandleCollision(IEnemy enemy, IBlock block, CollisionSide side)
        {
            switch(side)
            { 
                case CollisionSide.Left:

                case CollisionSide.Right:
                    enemy.FacingLeft = !enemy.FacingLeft;
                    break;
                default:
                    break;

            }
        }
    }
}
