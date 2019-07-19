using SuperDavis.Interfaces;
using static SuperDavis.Collision.CollisionDetection;

namespace SuperDavis.Collision
{
    class ProjectileBlockCollisionHandler
    {
        private ProjectileBlockCollisionHandler() { }
        public static void HandleCollision(IProjectile projectile, CollisionSide side, IWorld world)
        {
            switch (side)
            {
                case CollisionSide.Left:
                case CollisionSide.Right:
                    var davis = world.Characters;
                    davis.DavisProjectile.Add(projectile);
                    world.ObjectToRemove.Add(projectile);
                    break;
                case CollisionSide.None:
                    break;
            }
        }
    }
}
