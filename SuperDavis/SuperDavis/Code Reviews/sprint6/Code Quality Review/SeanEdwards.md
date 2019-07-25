# Code Quality Review - Sean Edwards
1. Sean Edwards
2. 7/25/2019
3. Sprint 6
4. Memento.cs 
5. Jason Xu
6. 10 minutes
7. I critiqued this same file for my readability review, and have chosen to do the sam file for code quality. One issue that immediately stands out
are the if statements in the Load method(), the complexity of this can be reduced by creating a dictionary that holds an integer character ID as a key
and the character setting as a value. Once the HUD returns the ID it can be passed into the dictionary to set the character. The issue can be seen in the below code:

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

The ResetToCheckPoint() method is guilty of the same issue, but also fails the coding mantra of "Don't repeat yourself" as the same problem mentioned above occurs here.

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

Also, the above code is not data driven and string literals are apparent, which would be a much larger issues if there were more levels.

Overall I know the reason things were implemented this way (time crunch for sprint 6) but these are issues that can easily be avoided.