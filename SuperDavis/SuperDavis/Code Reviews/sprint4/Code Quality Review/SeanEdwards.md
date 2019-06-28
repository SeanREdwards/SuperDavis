# Code Quality Review - Sean Edwards
1. Sean Edwards
2. 6/28/2019
3. Sprint 4
4. DavisItemCollisionHandler.cs
5. Jason Xu
6. 10 minutes
7.I looked at the DavisItemCollisionHandler as the most of the collision handlers were very similiar,
but this one in particular was important as it changed character status based on item pick up.

Mainly I was looking for duplicated code, cycolmatic complexity, and excessive use of literals. There 
was no duplicated code, but there is some potential cyclomatic complexity due to the if statements, this
could be fixed by making dictionary entries and data driving them with JSON files as the complexity could
get more extreme if numerous new item types were added.

```
            if (side != CollisionSide.None)
            {
                if (item is Flower)
                {
                    if(davis.DavisStatus != DavisStatus.Invincible)
                        davis.DavisStatus = DavisStatus.Bat;
                        davis.DavisState.Static();
                }
                else if (item is Mushroom)
                {
                    if(davis.DavisStatus == DavisStatus.Davis)
                        davis.DavisStatus = DavisStatus.Woody;
                        davis.DavisState.Static();
                }
                else if (item is Star)
                {
                    davis.PrevDavisStatus = davis.DavisStatus;
                    davis.DavisToInvincible();
                    davis.DavisState.Static();
                }
                world.ObjectToRemove.Add(item);
```
Seperate methods for each item could be created and the dictionary set so that the item name is a key and
the value is a method call which would set the character state/status to the required state/status
based on the item picked up.