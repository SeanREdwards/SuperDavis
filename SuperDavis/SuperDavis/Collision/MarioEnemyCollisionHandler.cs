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
    class MarioEnemyCollisionHandler
    {
        // Constructor or not?
        
        public static void HandleCollision(IDavis davis, IEnemy enemy, CollisionSide side)
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

            //there was a collision
            if (side != CollisionSide.None)
            {
                //if collision is not on bottom
                if (side != CollisionSide.Bottom)
                {
                    if (!enemy.Dead)
                    {
                        enemy.TakeDamage();
                    }
                }
                else
                {
                    if (!enemy.Dead)
                    {
                        davis.DavisState.Death();
                    }
                }
            }
        }
    }
}
