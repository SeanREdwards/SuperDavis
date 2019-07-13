# Code Quality Review - Sean Edwards
1. Sean Edwards
2. 7/12/2019
3. Sprint 5
4. HUD.cs 8 minutes
7.I looked at the HUD.cs since it was one of the nw implementations for this sprint I hadn't worked on. Overall the number of code smells are at a minimum for this file
as the complexity is extremly low (it mostly just draws strings to notify the player of game information), however one that is blatently obvious is the excessive use of literals
as there are numerous hard coded strings. These can be seen in the following code snippet.

---
            spriteBatch.DrawString(font, "SuperDavis", new Vector2(50, 20), Color.White);
            spriteBatch.DrawString(font, "" + score, new Vector2(50, 60), Color.White);
            spriteBatch.DrawString(font, "Coins", new Vector2(300, 20), Color.White);
            spriteBatch.DrawString(font, "" + coins, new Vector2(300, 60), Color.White);
            spriteBatch.DrawString(font, "World", new Vector2(500, 20), Color.White);
            spriteBatch.DrawString(font, worldText, new Vector2(500, 60), Color.White);
            spriteBatch.DrawString(font, "Time", new Vector2(700, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)time, new Vector2(700, 60), Color.White);
            spriteBatch.DrawString(font, "Lives", new Vector2(850, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)lives, new Vector2(850, 60), Color.White);
---

Blatently obvious are string literals for nearly every line, and the vector location integer literals that are hardcoded into the file. This issue with string and integer literals could easily
be solved by data driving all of them (purpose of the variables.cs file in the first place).