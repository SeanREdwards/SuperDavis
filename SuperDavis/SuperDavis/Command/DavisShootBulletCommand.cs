using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisShootBulletCommand : ICommand
    {
        private readonly IDavis davis;
        private readonly IWorld world;
        public DavisShootBulletCommand(IDavis davis, IWorld world)
        {
            this.davis = davis;
            this.world = world;
        }

        public void Execute()
        {
            if (davis.DavisProjectile.Count > 0)
            {
                foreach (IProjectile projectile in davis.DavisProjectile)
                {
                    projectile.FacingDirection = davis.FacingDirection;
                    projectile.Location = davis.Location + (new Vector2(0, 30f));
                }
                world.AddObject(davis.DavisProjectile[davis.DavisProjectile.Count - 1]);
                davis.DavisProjectile.RemoveAt(davis.DavisProjectile.Count - 1);
                davis.DavisState.SpecialAttack();
            }
        }
    }
}
