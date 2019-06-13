﻿using Microsoft.Xna.Framework;
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
        private MarioItemCollisionHandler() { }
        
        public static void HandleCollision(IDavis davis, IItem item, CollisionSide side)
        {
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
                    davis.PrevDavisStatus = davis.DavisStatus;
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
