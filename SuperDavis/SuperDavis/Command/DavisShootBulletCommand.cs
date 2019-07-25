using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Item;
using System;

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
                var count = davis.DavisProjectile.Count;
                davis.DavisProjectile.Clear();
                Random random = new Random();
                for (int i = count; i > 0; i--)
                {                    
                    switch (davis.DavisStatus)
                    {                                           
                        case (DavisStatus.Davis):
                            davis.DavisProjectile.Add(new DavisProjectile((davis.Location + new Vector2(0, 25f + random.Next(10))), davis.FacingDirection));
                            break;
                        case (DavisStatus.Woody):
                            davis.DavisProjectile.Add(new WoodyProjectile((davis.Location + new Vector2(0, 25f + random.Next(10))), davis.FacingDirection));
                            break;
                        case (DavisStatus.Bat):
                            davis.DavisProjectile.Add(new BatProjectile((davis.Location + new Vector2(0, 25f + random.Next(10))), davis.FacingDirection));
                            break;
                    }
                }
                world.AddObject(davis.DavisProjectile[davis.DavisProjectile.Count - 1]);
                davis.DavisProjectile.RemoveAt(davis.DavisProjectile.Count - 1);
                davis.DavisState.SpecialAttack();
            }
        }
    }
}
