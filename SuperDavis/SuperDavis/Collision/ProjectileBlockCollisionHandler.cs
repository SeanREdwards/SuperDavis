using SuperDavis.Interfaces;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileBlockCollisionHandler
    {
        private ProjectileBlockCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, IBlock block, CollisionSide side, IWorld world)
        {
            switch (side)
            {
                case CollisionSide.Left:

                case CollisionSide.Right:
                    //world.BufferList.Remove(projectile);
                    foreach(IDavis davis in world.Davises)
                    {
                        //davis.DavisProjectile.Add(projectile);
                    }
                    break;
                case CollisionSide.None:
                    break;
            }
        }
    }
}
