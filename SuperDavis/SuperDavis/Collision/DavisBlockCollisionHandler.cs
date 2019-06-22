using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Physics;
using SuperDavis.State.DavisState;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class DavisBlockCollisionHandler
    {
        private DavisBlockCollisionHandler() { }
        public static void HandleCollision(IDavis davis, IBlock block, CollisionSide side)
        {
            switch (side)
            {
                case CollisionSide.Bottom:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
                    davis.PhysicsState = new FallState(davis);
                    //davis.PhysicsState.VerticalVelocity = 0;
                   // davis.PhysicsState.ApplyForce(new Vector2(0, -10f));
                    if (block is HiddenBlock)
                    {
                        block.SpecialState();
                    }
                    else if (block is QuestionBlock)
                    {
                        block.SpecialState();
                    }
                    else if (block is Brick)
                    {
                        if (davis.DavisStatus != DavisStatus.Davis)
                        {
                            block.SpecialState();
                            block.Remove = true;
                        }
                        else
                        {
                            block.IsBumped = true;
                        }
                    }
                    break;
                case CollisionSide.Top:
                    //if not hidden block
                    if (!block.IsHidden)
                    {
                            davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                            davis.PhysicsState = new StandingState(davis);
                            davis.DavisState.Land();
                            //davis.PhysicsState.ApplyForce(new Vector2(0, -5f));
                    }
                    break;
                case CollisionSide.Left:
                    if (!block.IsHidden)
                        davis.Location = new Vector2(block.Location.X - davis.HitBox.Width, davis.Location.Y);
                    break;
                case CollisionSide.Right:
                    if (!block.IsHidden)
                        davis.Location = new Vector2(block.Location.X + block.HitBox.Width, davis.Location.Y);
                    break;
                case CollisionSide.None:
                    break;
            }
        }
    }
}
