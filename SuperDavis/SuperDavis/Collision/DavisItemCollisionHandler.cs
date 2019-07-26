﻿using SuperDavis.Interfaces;
using SuperDavis.Object.Character;
using SuperDavis.Object.Item;
using SuperDavis.Sound;
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
                    world.HUD.score += 1000;
                    davis.DavisState.Static();

                }
                else if (item is Mushroom)
                {
                    world.HUD.lives += 1;
                    davis.DavisState.Static();
                }
                else if (item is Star)
                {
                    world.Characters = new InvincibleDavis(world.Characters, world);
                    //world.DecoratorReplacement(davis, world.Characters);
                }
                else if (item is Coin)
                {
                    world.HUD.coins++;
                    world.HUD.score += 50;
                    Sounds.Instance.PlayItemPickUp();
                }
                else if (item is Key)
                {
                    world.HUD.score += 150;
                    Sounds.Instance.PlayItemPickUp();
                }
                world.ObjectToRemove.Add(item);
            }
        }
    }
}
