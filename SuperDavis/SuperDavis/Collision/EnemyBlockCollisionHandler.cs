using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class EnemyBlockCollisionHandler
    {
        private EnemyBlockCollisionHandler() { }
        public static void HandleCollision(IEnemy enemy, IBlock block, CollisionSide side)
        {
            if(!(enemy.PhysicsState is EnemyDeadState))
                switch(side)
                {
                   case CollisionSide.Left:
                   case CollisionSide.Right:
                       if (enemy.FacingDirection == FacingDirection.Left)
                           enemy.FacingDirection = FacingDirection.Right;
                       else
                           enemy.FacingDirection = FacingDirection.Left;
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
