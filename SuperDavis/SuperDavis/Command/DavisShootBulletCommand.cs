using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System.Collections.Generic;

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
            if (davis.DavisProjectile.Count > 0 && davis.DavisStatus == DavisStatus.Bat)
            {
                foreach(IProjectile projectile in davis.DavisProjectile)
                {
                    projectile.FacingLeft = davis.FacingLeft;
                    projectile.Location = davis.Location + (new Vector2(0, 30f));
                }
                world.Projectiles.Add(davis.DavisProjectile[davis.DavisProjectile.Count - 1]);
                davis.DavisProjectile.RemoveAt(davis.DavisProjectile.Count - 1);
            }
        }
    }
}
