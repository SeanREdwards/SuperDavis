using SuperDavis.Interfaces;
using SuperDavis.Object.Item;
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
                    if(davis.DavisStatus != DavisStatus.Invincible)
                        davis.DavisStatus = DavisStatus.Bat;
                    davis.DavisState.Static();
                }
                else if (item is Mushroom)
                {
                    if(davis.DavisStatus == DavisStatus.Davis)
                        davis.DavisStatus = DavisStatus.Woody;
                    davis.DavisState.Static();
                }
                else if (item is Star)
                {
                    davis.PrevDavisStatus = davis.DavisStatus;
                    davis.DavisStatus = DavisStatus.Invincible;
                    davis.DavisState.Static();
                }
                item.Clear();
            }
        }
    }
}
