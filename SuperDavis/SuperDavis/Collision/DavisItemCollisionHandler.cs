﻿using SuperDavis.Interfaces;
using SuperDavis.Object.Character;
using SuperDavis.Object.Item;
using SuperDavis.Variables;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class DavisItemCollisionHandler
    {
        private DavisItemCollisionHandler() { }
        
        public static void HandleCollision(IDavis davis, IItem item, CollisionSide side, IWorld world)
        {
            if (side != CollisionSide.None)
            {
                if (item is Flower)
                {
                    if (davis.DavisStatus != DavisStatus.Invincible)
                        davis.DavisStatus = DavisStatus.Bat;
                        davis.DavisState.Static();
                }
                else if (item is Mushroom)
                {
                    if (davis.DavisStatus == DavisStatus.Davis)
                        davis.DavisStatus = DavisStatus.Woody;
                        davis.DavisState.Static();
                }
                else if (item is Star)
                {
                    davis.DavisStatus = DavisStatus.Invincible;
                    //world.ObjectToRemove.Add(davis);
                    //world.AddObject(new InvincibleDavis(davis, world));
                }
                else if (item is Coin)
                {
                    HUD.coins++;
                }
                world.ObjectToRemove.Add(item);
            }
        }
    }
}
