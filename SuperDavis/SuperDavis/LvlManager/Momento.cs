﻿using SuperDavis.Interfaces;
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
        private string checkPoint;

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
            this.checkPoint = levelName;
            if (levelName.Equals("demo-level.xml"))
                world = worldCreator.CreateWorld(levelName, Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);
            else
                world = worldCreator.CreateWorld(levelName, Variables.Variable.bosslevelWidth, Variables.Variable.bosslevelHeight, game1, game1.HUD);

            if (game1.HUD.CharacterSelect == 2)
                world.Characters.DavisToWoody();
            else if (game1.HUD.CharacterSelect == 3)
                world.Characters.DavisToBat();
            // Different levels
            Sounds.Instance.MusicInstance.Play();
            return world;
        }
        public IWorld LoadEmpty()
        {
            IsEmpty = true;
            return null;
        }

        public void ChangeCheckPoint(string levelName)
        {
            this.checkPoint = levelName;
        }

        public IWorld ResetToCheckPoint()
        {
            if(checkPoint.Equals("demo-level.xml"))
                world = worldCreator.CreateWorld(checkPoint, Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);
            else
                world = worldCreator.CreateWorld("boss-level.xml", Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);

            if (game1.HUD.CharacterSelect == 2)
                world.Characters.DavisToWoody();
            else if (game1.HUD.CharacterSelect == 3)
                world.Characters.DavisToBat();
                world.HUD.time = Variables.Variable.time;
                return world;
        }
    }
}
