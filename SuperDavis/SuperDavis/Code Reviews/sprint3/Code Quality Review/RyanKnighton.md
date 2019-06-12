# Ryan Knighton code quality review for sprint 3
1. Ryan Knighton
2. 6/12/19
3. Sprint 3
4. World.cs
5. Jason Xu
6. 20 minutes
7. Specific Comments - Some code smells that I was looking for in particular are classes with too much code, similar looking code and unused or redundant variables.  After reviewing the file, I can see that the class is not too long and fairly easy to follow and understand.  I can see that all the variables have meaningful names and no unused or redundant variable names.  There are a few spots where code is repeated and very similiar that could be better handled by a function. The repeated code is listed below:

```
            foreach (IBackground background in Backgrounds)
            {
                background.Update(gameTime);
            }
            foreach (IDavis character in Davises)
            {
                character.Update(gameTime);
            }
            foreach (IItem item in Items)
            {
                item.Update(gameTime);
            }
            foreach (IBlock block in Blocks)
            {
                block.Update(gameTime);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update(gameTime);
```

```
            foreach (IBackground background in Backgrounds)
            {
                background.Draw(spriteBatch);
            }
            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IDavis character in Davises)
            {
                character.Draw(spriteBatch);
            }
```

```
            foreach (IDavis character in Davises)
            {
                character.Reset();
            }
            foreach (IBlock block in Blocks)
            {
                block.Reset();
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Reset();
            }
            foreach (IItem item in Items)
            {
                item.Reset();
            }
```

8. Hypothetical Change - A change that might make this file smaller and more compact would be to create a function that took two parameters.  The first parameter would be the desired interface for the foreach loop and the second parameter would be what action was being done.  Update, draw or reset for example.  Then instead of having 4 foreach loops in each function, we could just make a dictionary or map with the interface=>action key value pair and call the desired function.  This would make the class shorter and easier to read.