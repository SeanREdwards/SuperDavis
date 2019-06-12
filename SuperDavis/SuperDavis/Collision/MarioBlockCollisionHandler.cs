using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class MarioBlockCollisionHandler
    {
        // Constructor or not?
        
        public static void HandleCollision(IDavis davis, IBlock block, CollisionSide side)
        {
            switch (side)
            {
                case CollisionSide.Bottom:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
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
                        block.SpecialState();
                        block.Remove = true;
                    }
                    break;
                case CollisionSide.Top:
                    //if not hidden block
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                    }
                    break;
                case CollisionSide.Left:
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(block.Location.X - davis.HitBox.Width, davis.Location.Y);
                    }
                    break;
                case CollisionSide.Right:
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(block.Location.X + block.HitBox.Width, davis.Location.Y);
                    }
                    break;
                case CollisionSide.None:
                    break;
            }
        }
    }
}
