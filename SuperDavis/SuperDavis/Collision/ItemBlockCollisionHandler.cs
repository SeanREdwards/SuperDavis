using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ItemBlockCollisionHandler
    {

        private ItemBlockCollisionHandler() { }
        public static void HandleCollision(IItem item, IBlock block, CollisionSide side, IWorld world)
        {
            switch(side)
            { 
                case CollisionSide.Left:

                case CollisionSide.Right:
                    item.FacingLeft = !item.FacingLeft;
                    break;
                case CollisionSide.Top:
                    item.Location = new Vector2(item.Location.X, block.Location.Y - item.HitBox.Height);
                    item.PhysicsState = new StandingState(item);
                    break;
                default:
                    break;

            }
        }
    }
}
