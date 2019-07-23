using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Variables;

namespace SuperDavis
{
    public class HUD
    {
        public static int score = Variable.score;
        public static int coins = Variable.coins;
        public static int lives = Variable.lives;
        public static string worldText = Variable.worldText;
        public static double time = Variable.time;

        public static void Draw(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch) {
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
    }
}
