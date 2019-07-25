# Code Readability Review - Sean Edwards
1. Sean Edwards
2. 7/25/2019
3. Sprint 6
4. Memento.cs 
5. Jason Xu
6. 8 minutes
7. I looked at the Memento.cs since it was new for sprint 6 and is fullfilling a few different roles for us. Jason currently has it set up to function as both 
an object for level resets and as the initial character selector. The load function calls the HUD which is our intro screen and has character selection output
which is pretty clear and can be seen below.
---
        public IWorld Load(string levelName)
        {
            IsEmpty = false;
            this.checkPoint = levelName;
            world = worldCreator.CreateWorld(levelName, Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);
            if (game1.HUD.CharacterSelect == 2)
                world.Characters.DavisToWoody();
            else if (game1.HUD.CharacterSelect == 3)
                world.Characters.DavisToBat();
            return world;
        }
---
As one can see character selection choice is based on a return value for the HUD which is determined on game start once a character is chosen. 
The next major method section is Reset to checkpoint which reads the current checkpoint (set via which level is currently being played) and resets
to the start of that level once a player loses or presses reset.
---
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
---
There is some breaking of the rule of "Don't repeat yourself", as the above method has some crossover/redundancy with the initial load of the momento object.