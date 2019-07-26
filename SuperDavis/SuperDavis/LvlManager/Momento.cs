using SuperDavis.Interfaces;
using SuperDavis.Sound;
using SuperDavis.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.LvlManager
{
    class Momento
    {
        public bool IsEmpty { get; set; }
        private IWorld world;
        private readonly WorldCreator worldCreator;
        private readonly Game1 game1;
        public string CheckPoint { get; set; }

        public Momento(IWorld world, WorldCreator worldCreator, Game1 game1)
        {
            this.IsEmpty = false;
            this.world = world;
            this.worldCreator = worldCreator;
            this.game1 = game1;
        }

        public IWorld Load(string levelName)
        {
            IsEmpty = false;
            this.CheckPoint = levelName;
            if (levelName.Equals("demo-level.xml"))
            {
                world = worldCreator.CreateWorld(levelName, Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);
                Sounds.Instance.MusicInstance.Play();
            }
            else
            {
                world = worldCreator.CreateWorld(levelName, Variables.Variable.bosslevelWidth, Variables.Variable.bosslevelHeight, game1, game1.HUD);
                Sounds.Instance.BossMusicInstance.Play();
            }

            if (game1.HUD.CharacterSelect == 2)
                world.Characters.DavisToWoody();
            else if (game1.HUD.CharacterSelect == 3)
                world.Characters.DavisToBat();
            // Different levels

            return world;
        }
        public IWorld LoadEmpty()
        {
            IsEmpty = true;
            return null;
        }

        public void ChangeCheckPoint(string levelName)
        {
            this.CheckPoint = levelName;
        }

        public IWorld ResetToCheckPoint()
        {
            if(CheckPoint.Equals("demo-level.xml"))
                world = worldCreator.CreateWorld(CheckPoint, Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);
            else
                world = worldCreator.CreateWorld("boss-level.xml", Variables.Variable.bosslevelWidth, Variables.Variable.bosslevelWidth, game1, game1.HUD);

            if (game1.HUD.CharacterSelect == 2)
                world.Characters.DavisToWoody();
            else if (game1.HUD.CharacterSelect == 3)
                world.Characters.DavisToBat();
                world.HUD.time = Variables.Variable.time;
                return world;
        }
    }
}
