1. Sean Edwards
2. 5/29/2019
3. Sprint 2
4. DavisWalkRightState.cs
5. Jason Xu
6. 10 minutes
7. 
Initially in my code review I was mainly trying to look for duplicated code, excessive use of literals,
and inappropriate intimacy between classes.

The entirity of the DavisWalkRightState code was very readable but there are a few confusing points
that should probably be addressed during the refactor. First the name of the class is somewhat confusing.
DavisWalkRightState.cs makes sense if there is only one characer: "Davis". This could create issues
in the future if numerous characters are added and calling a generic character a Davis object when this
object can also be set as "Woody" or "Bat" (other characters). For reference see the below code snippet:

```
	public DavisWalkRightState(IDavis davis)
        {
            this.davis = davis;
            switch(davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    sprite = DavisSpriteFactory.Instance.CreateDavisWalkRightSprite();
                    break;
                case DavisStatus.Woody:
                    sprite = DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite();
                    break;
                case DavisStatus.Bat:
                    sprite = DavisSpriteFactory.Instance.CreateBatWalkRightSprite();
                    break;
                case DavisStatus.Invincible:
                    // TBD;
                    break;
                default:
                    break;
            }
            // Needed?
            Width = sprite.Width;
            Height = sprite.Height;
        }
```
While the layout itself is excellent having a IDavis interface, a status called Davis, and numerous other
references to a Davis could create issues in understanding. This cascades as from this file alone I can 
see references to a generic Davis naming convention accross other classes. I think in the refactor the 
IDavis Interface should be changed to an ICharacter interfacte, rename DavisSpriteFactory to CharacterSpriteFactory, and DavisStatus
to CharacterStatus to avoid redundancy and make the code more intuitive. Other than issues with class/state naming conventions 
the code itself is laid out well so that in just a glance. I can tell that once I know a Davis is a generic character 
the class instantiates a character sprite for each of the characters currently available and each method in this class 
assigns a state to said character.

I like the comments mentioning "Needed?" & "TBD" because I can tell Jason is thinking ahead to future tasks, i.e. needing to know a sprite's
width/height for collisions in later sprints etc.