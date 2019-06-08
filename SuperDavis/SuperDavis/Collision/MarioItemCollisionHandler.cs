using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class MarioItemCollisionHandler
    {
        // Constructor or not?
        
        public static void HandleCollision(IDavis davis, IItem item,CollisionSide side)
        {
            // Location setup
            /*switch(side)
            {
                case CollisionSide.Top:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                    break;
                case CollisionSide.Left:
                    davis.Location = new Vector2(block.Location.X - davis.HitBox.Width, davis.Location.Y);
                    break;
                case CollisionSide.Right:
                    davis.Location = new Vector2(block.Location.X + block.HitBox.Width, davis.Location.Y);
                    break;
                case CollisionSide.Bottom:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
                    break;
                case CollisionSide.None:
                   // davis.DavisState.Static();
                    break;
            }*/
            if (side != CollisionSide.None)
            {
                if (item is Flower)
                {
                    davis.DavisStatus = DavisStatus.Bat;
                    davis.DavisState.Static();
                }
                else if (item is Mushroom)
                {
                    davis.DavisStatus = DavisStatus.Woody;
                    davis.DavisState.Static();
                }
                else if (item is Star)
                {
                    davis.DavisStatus = DavisStatus.Invincible;
                    davis.DavisState.Static();
                }
                else if (item is YoshiEgg)
                {

                }
                else if (item is Coin)
                {

                }
                item.Clear();
            }
        }
    }
}
