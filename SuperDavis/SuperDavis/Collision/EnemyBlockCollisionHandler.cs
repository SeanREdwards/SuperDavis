using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class EnemyBlockCollisionHandler
    {
        private EnemyBlockCollisionHandler() { }
        public static void HandleCollision(IEnemy enemy, IBlock block, CollisionSide side)
        {
            if (!(enemy.PhysicsState is EnemyDeadState))
                switch (side)
                {
                    case CollisionSide.Left:
                    case CollisionSide.Right:
                        enemy.ChangeDirection();
                        break;
                    case CollisionSide.Bottom:
                        if (!(block is EmptyBlock))
                        {
                            enemy.Location = new Vector2(enemy.Location.X, block.Location.Y + block.HitBox.Height);
                            enemy.PhysicsState = new FallState(enemy);
                        }
                        break;
                    case CollisionSide.Top:
                        if (!(block is EmptyBlock))
                        {
                            enemy.Location = new Vector2(enemy.Location.X, block.Location.Y - enemy.HitBox.Height);
                            enemy.PhysicsState = new StandingState(enemy);
                        }
                        break;
                    default:
                        break;
                }
        }
    }
}
