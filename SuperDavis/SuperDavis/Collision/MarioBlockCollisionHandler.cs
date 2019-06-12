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
        
        public static void HandleCollision(IDavis davis, IBlock block,CollisionSide side)
        {
            bool isVisible = false;
            // Location setup
            switch (side)
            {
                case CollisionSide.Bottom:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
                    if (block is HiddenBlock)
                    {
                        isVisible = true;
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
                    if (!(block is HiddenBlock))
                    {
                        davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                    }
                    else {
                        if (isVisible == true)
                        {
                            davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                        }
                        else {
                            davis.Location = new Vector2(davis.Location.X, davis.Location.Y);
                        }
                        
                    }
                    break;
                case CollisionSide.Left:
                    davis.Location = new Vector2(block.Location.X - davis.HitBox.Width, davis.Location.Y);
                    break;
                case CollisionSide.Right:
                    davis.Location = new Vector2(block.Location.X + block.HitBox.Width, davis.Location.Y);
                    break;
                case CollisionSide.None:
                   // davis.DavisState.Static();
                    break;
            }
        }
    }
}
