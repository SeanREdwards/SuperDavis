using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.Sound;
using System;

namespace Superjulian.Command
{
    class JulianShootBulletCommand : ICommand
    {
        private readonly Julian julian;
        private readonly IWorld world;
        public JulianShootBulletCommand(IEnemy julian, IWorld world)
        {
            this.julian = (Julian)julian;
            this.world = world;
        }

        public void Execute()
        {

        }
    }
}
