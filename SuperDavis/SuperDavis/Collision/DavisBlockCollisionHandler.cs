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
                    if (block is HiddenBlock && davis.PhysicsState is JumpState)
                    {
                        block.SpecialState();
                    }
                    if (block is CoinBrick && davis.PhysicsState is JumpState)
                    {
                        CoinBrick coinBrick = (CoinBrick)block;
                        if (coinBrick.CoinCounter > 0)
                        {
                            world.AddObject(new Coin(new Vector2(block.Location.X, block.Location.Y - 40)));
                            coinBrick.CoinCounter--;
                            coinBrick.IsBumped = true;
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
                            world.ObjectToRemove.Add(block);
                        }
                        else 
                        {
                            var brick = (Brick)block;
                            brick.IsBumped = true;
                        }
                    }
                    else if (block is MushroomBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.AddObject(new Mushroom(new Vector2(block.Location.X, block.Location.Y - 10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is CoinBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.AddObject(new Mushroom(new Vector2(block.Location.X, block.Location.Y - 10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is StarBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.AddObject(new Star(new Vector2(block.Location.X, block.Location.Y - 10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is FlowerBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.AddObject(new Flower(new Vector2(block.Location.X, block.Location.Y - 10)));
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
                        davis.DavisState.Land();
                        davis.PhysicsState = new StandingState(davis);
                        davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
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
