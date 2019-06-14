# Sean Edwards code quality review for sprint 3
1. Sean Edwards
2. 6/13/19
3. Sprint 3
4. CollisionDetection.cs
5. Jason Xu
6. 15 minutes
7. Initial code smells were duplicated code, excessive use of literals, and cyclomatic complexity. On first glance CollisionDetection.cs 
seems laid out fundamentally well, and its immediately apparent that this is the overall driver method for overseeing varied collision 
states for the player, enemies, and game objects. The methods within this class are are clearly defined and pretty self explanatory based solely
on naming convention. While no real instances of duplicated code or excessive use of literals were apparent, there does appear to be some borderline
cyclomatic complexity which can be seen in the nested loops below:

```
             private static void CheckMarioItemCollision(IList<IDavis> davises, IList<IItem> items)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IItem item in items)
                {
                    if (!item.Remove)
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, item.HitBox), davis.HitBox, item.HitBox);
                        MarioItemCollisionHandler.HandleCollision(davis, item, side);
                    }

                }
            }
        }
```
If there were an excessive amount of player objects and collidable items the above code could potentially cause issues, though based on the fact our
game is contingent on one player character at the moment this is not yet an issue. Potential fix would be to check all player characters at the same time
versus the items currently in the game so that the loops don't need to cycle through multiple times per character.
