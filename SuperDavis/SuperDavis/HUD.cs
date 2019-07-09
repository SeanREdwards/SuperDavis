using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDavis
{
    public class HUD
    {
  
        public int score = 0;
        public int coins = 0;
        public string worldText = "1-1";
        public double time = 400;
     
        public void Draw(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch) {
            //if timer runs out reset game.
            time -= gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "SuperFkingDavis", new Vector2(100, 20), Color.White);
            spriteBatch.DrawString(font, "" + score, new Vector2(100, 60), Color.White);
            spriteBatch.DrawString(font, "Coins", new Vector2(400, 20), Color.White);
            spriteBatch.DrawString(font, "" + coins, new Vector2(400, 60), Color.White);
            spriteBatch.DrawString(font, "World", new Vector2(600, 20), Color.White);
            spriteBatch.DrawString(font, worldText, new Vector2(600, 60), Color.White);
            spriteBatch.DrawString(font, "Time", new Vector2(800, 20), Color.White);
            spriteBatch.DrawString(font, "" + (int)time, new Vector2(800, 60), Color.White);
            spriteBatch.End();

        }
    }
}
