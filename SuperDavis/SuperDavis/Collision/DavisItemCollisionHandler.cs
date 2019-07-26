using SuperDavis.Interfaces;
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
                    Sounds.Instance.PlayDrinkMilk();
                    world.HUD.score += 1500;
                    davis.DavisState.Static();
                }
                else if (item is Mushroom)
                {
                    Sounds.Instance.PlayHealSound();
                    world.HUD.lives += 1;
                    davis.DavisState.Static();
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
                    Sounds.Instance.PlayKeyPickUp();
                    davis.KeyFlag = true;
                }
                world.ObjectToRemove.Add(item);
            }
        }
    }
}
