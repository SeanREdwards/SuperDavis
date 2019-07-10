using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Variables;

namespace SuperDavis
{
    public class HUD
    {
        public static void Draw(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch) {
            Variable.time -= gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.DrawString(font, "SuperDavis", new Vector2(50, 20), Color.White);
            spriteBatch.DrawString(font, "" + Variable.score, new Vector2(50, 60), Color.White);
            spriteBatch.DrawString(font, "Coins", new Vector2(300, 20), Color.White);
            spriteBatch.DrawString(font, "" + Variable.coins, new Vector2(300, 60), Color.White);
            spriteBatch.DrawString(font, "World", new Vector2(500, 20), Color.White);
            spriteBatch.DrawString(font, Variable.worldText, new Vector2(500, 60), Color.White);
            spriteBatch.DrawString(font, "Time", new Vector2(700, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)Variable.time, new Vector2(700, 60), Color.White);
            spriteBatch.DrawString(font, "Lives", new Vector2(850, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)Variable.lives, new Vector2(850, 60), Color.White);
        }
    }
}
