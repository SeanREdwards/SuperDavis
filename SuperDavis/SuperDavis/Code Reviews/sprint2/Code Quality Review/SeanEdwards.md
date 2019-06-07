1. Sean Edwards
2. 5/30/2019
3. Sprint 2
4. DavisWalkRightState.cs
5. Jason Xu
6. 10 minutes
7. For the code quality review of the DavisWalkRightState.cs (and cascading into the other states as they are similiarly laid out) 
I was mainly trying to look for duplicated code, excessive use of literals, and inappropriate intimacy between classes.

Overall the code was laid out well, but as can be seen in the below code snippet there is some repeated code that is noticeable in the
switch case:

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

 A way to potentially elimate the repeated code would be to make DavisState identifier (i.e. Davis, Woody, Bat) a key that is
mapped to a value containing the assocaited sprite with that state identifier. This way that if more characters are added in the future a
Dictionary can be used rather than a switch case and since Dictionary's are made up of hashed key value pairs the usage of a dictionary
should be more efficient as more characters are added.

In this code review there did not seem to be an excessive usage of literals, or any inappropriate intimacy between classes.

