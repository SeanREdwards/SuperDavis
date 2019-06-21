using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class DavisBlockCollisionHandler
    {
        private static bool IsStanding = false;
        // Bool would be a bad idea, ask grader

        private DavisBlockCollisionHandler() { }
        public static void HandleCollision(IDavis davis, IBlock block, CollisionSide side)
        {
            switch (side)
            {
                case CollisionSide.Bottom:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
                    davis.PhysicsState = new FallState(davis);
                    if (block is HiddenBlock && davis.PhysicsState is JumpState)
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
                        if(IsStanding && !(davis.PhysicsState is StandingState) )
                        {
                            davis.DavisState.Static();
                        }
                        IsStanding = false;
                    }
                    break;
                case CollisionSide.Left:
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(block.Location.X - davis.HitBox.Width, davis.Location.Y);
                        IsStanding = false;
                    }

                    break;
                case CollisionSide.Right:
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(block.Location.X + block.HitBox.Width, davis.Location.Y);
                        IsStanding = false;
                    }

                    break;
                case CollisionSide.None:
                    // Want this only execute one time
                    if (!IsStanding)
                    {
                        davis.PhysicsState = new FallState(davis);
                        IsStanding = true;
                    }
                    break;
            }
        }
    }
}
