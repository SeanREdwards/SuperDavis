# Jason Xu code review for code readability - Sprint 6
1. Jason Xu
2. 7/24/2019
3. Sprint 6
4. Momento.cs / Sounds.cs
5. Jason Xu, Sean Edwards
6. 15 minutes
7. 
```
        public IWorld Load(string levelName)
        {
            IsEmpty = false;
            this.checkPoint = levelName;
            world = worldCreator.CreateWorld(levelName, Variables.Variable.level11Width, Variables.Variable.level11Height, game1, game1.HUD);
            if (game1.HUD.CharacterSelect == 2)
                world.Characters.DavisToWoody();
            else if (game1.HUD.CharacterSelect == 3)
                world.Characters.DavisToBat();
            // Different levels
            Sounds.Instance.MusicInstance.Play();
            return world;
        }
```
	In this file, the readability is ok, what I want to do is to load the world based on the character choice in character select page, 
	It is good to add such momento class, apply an overall control over the high coupling of the game.

```
 public void Load(ContentManager content)
        {
            Music = content.Load<SoundEffect>("SoundFX/DemoMusic");
            MusicInstance = Music.CreateInstance();
            MusicInstance.IsLooped = true;
            Jump = content.Load<SoundEffect>("SoundFX/Jump");
            Death = content.Load<SoundEffect>("SoundFX/Death");
            ItemPickup = content.Load<SoundEffect>("SoundFX/ItemPickup");
            readyJump = true;
        }

        public void PlayJump()
        {
            if (readyJump)
            {
                readyJump = false;
                Jump.Play();
            }
        }
```
	From this Sounds.cs file, since it is static, it is very good to implement it from everywhere in the class, and the readability of this file
	is quite straight forward, loading music in looped behavior and one time behavior.

