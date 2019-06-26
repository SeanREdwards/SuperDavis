using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class EnemyBlockCollisionHandler
    {

        private EnemyBlockCollisionHandler() { }
        public static void HandleCollision(IEnemy enemy, IBlock block, CollisionSide side, IWorld world)
        {
            switch(side)
            { 
                case CollisionSide.Left:

                case CollisionSide.Right:
                    enemy.FacingLeft = !enemy.FacingLeft;
                    break;
                case CollisionSide.Top:
                    enemy.Location = new Vector2(enemy.Location.X, block.Location.Y - enemy.HitBox.Height);
                    enemy.PhysicsState = new StandingState(enemy);
                    break;
                default:
                    break;
            }
        }
    }
}
