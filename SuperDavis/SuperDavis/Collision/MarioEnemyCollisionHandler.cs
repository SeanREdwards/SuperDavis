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
