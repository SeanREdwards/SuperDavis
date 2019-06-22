using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class DavisBlockCollisionHandler
    {
        private DavisBlockCollisionHandler() { }
        public static void HandleCollision(IDavis davis, IBlock block, CollisionSide side, IWorld world)
        {
            switch (side)
            {
                case CollisionSide.Bottom:
                    //davis.PhysicsState.VerticalVelocity = 0;
                    // davis.PhysicsState.ApplyForce(new Vector2(0, -10f));
                    if (block is HiddenBlock && davis.PhysicsState is JumpState)
                    {
                        var hiddenBlock = (HiddenBlock)block;
                        block.SpecialState();
                        if (hiddenBlock.CoinCounter > 0)
                        {
                            world.Items.Add(new Coin(new Vector2(block.Location.X, block.Location.Y - 40)));
                            hiddenBlock.CoinCounter--;
                        }
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
                    else if (block is MushroomBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.Items.Add(new Mushroom(new Vector2(block.Location.X, block.Location.Y - 10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is CoinBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.Items.Add(new Coin(new Vector2(block.Location.X, block.Location.Y - 40)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is StarBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.Items.Add(new Star(new Vector2(block.Location.X, block.Location.Y-10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is FlowerBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.Items.Add(new Flower(new Vector2(block.Location.X, block.Location.Y-10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
                    davis.PhysicsState = new FallState(davis);
                    break;
                case CollisionSide.Top:
                    //if not hidden block
                    if (!block.IsHidden)
                    {
                            davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                            davis.PhysicsState = new StandingState(davis);
                            davis.DavisState.Land();
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
