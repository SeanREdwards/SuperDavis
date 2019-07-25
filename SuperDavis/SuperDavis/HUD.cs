using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Variables;
using SuperDavis.Object.Character;
using SuperDavis.Factory;


namespace SuperDavis
{
    public class HUD
    {
        public static int score = Variable.score;
        public static int coins = Variable.coins;
        public static int lives = Variable.lives;
        public static string worldText = Variable.worldText;
        public static double time = Variable.time;
        private int x;
        private static CharacterSelector characterSelector = new CharacterSelector();

        public static void Draw(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            time -= gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "SuperDavis", new Vector2(50, 20), Color.White);
            spriteBatch.DrawString(font, "" + score, new Vector2(50, 60), Color.White);
            spriteBatch.DrawString(font, "Coins", new Vector2(350, 20), Color.White);
            spriteBatch.DrawString(font, "" + coins, new Vector2(350, 60), Color.White);
            spriteBatch.DrawString(font, "World", new Vector2(600, 20), Color.White);
            spriteBatch.DrawString(font, worldText, new Vector2(600, 60), Color.White);
            spriteBatch.DrawString(font, "Time", new Vector2(850, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)time, new Vector2(850, 60), Color.White);
            spriteBatch.DrawString(font, "Lives", new Vector2(1050, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)lives, new Vector2(1050, 60), Color.White);
            spriteBatch.End();
        }

        public static int DrawMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "SuperDavis", new Vector2(50, 20), Color.White);
            characterSelector.CharacterPortraitList[0].Draw(spriteBatch, new Vector2(300, 300));
            characterSelector.CharacterPortraitList[1].Draw(spriteBatch, new Vector2(550, 300));
            characterSelector.CharacterPortraitList[2].Draw(spriteBatch, new Vector2(800, 300));

            characterSelector.NextCharacter(); //used for testing. Causing jitters atm.

            if (characterSelector.GetCharacterId() == 0)
            {
                DavisSpriteFactory.Instance.CreateDavisWalkRightSprite().Draw(spriteBatch, new Vector2(350, 450));
            }
            else if(characterSelector.GetCharacterId() == 1)
            {
                DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite().Draw(spriteBatch, new Vector2(600, 450));
            }
            else if (characterSelector.GetCharacterId() == 2)
            {
                DavisSpriteFactory.Instance.CreateBatWalkRightSprite().Draw(spriteBatch, new Vector2(850, 450));
            }
            //spriteBatch.DrawString(font, "Press Space To Start", new Vector2(50, 100), Color.White); //Original location per Ryan
            spriteBatch.DrawString(font, "Press Space To Start", new Vector2(450, 550), Color.White);
            spriteBatch.End();
            return 0;
        }
    }
}
