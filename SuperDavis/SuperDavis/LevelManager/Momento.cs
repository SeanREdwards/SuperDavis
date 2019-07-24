using SuperDavis.Interfaces;
using SuperDavis.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.LevelManager
{
    class Momento
    {
        public bool IsEmpty { get; set; }
        private IWorld world;
        private WorldCreator worldCreator;
        private Game1 game1;
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
            world = worldCreator.CreateWorld(levelName, Variables.Variable.level11Width, Variables.Variable.level11Height, game1);
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
            if(checkPoint.Equals("demo-level"))
                world = worldCreator.CreateWorld(checkPoint, Variables.Variable.level11Width, Variables.Variable.level11Height, game1);
            else
                world = worldCreator.CreateWorld("demo-level.xml", Variables.Variable.level11Width, Variables.Variable.level11Height, game1);
            return world;
        }
    }
}
