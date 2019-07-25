using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Variables;
using SuperDavis.Object.Character;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis
{
    public class HUD
    {
        public int score = Variable.score;
        public int coins = Variable.coins;
        public int lives = Variable.lives;
        public string worldText = Variable.worldText;
        public double time = Variable.time;

        public int CharacterSelect { get; set; }

        public HUD()
        {
            CharacterSelect = 1;
        }

        public void Draw(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
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

        public void DrawStartMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            StartMenuContext(gameTime, font, spriteBatch);
            spriteBatch.End();
        }

        /* Helper Method */
        public void StartMenuContext(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            if (this.CharacterSelect == 1)
                DavisSpriteFactory.Instance.CreateDavisWalkRightSprite().Draw(spriteBatch, new Vector2(350, 450));
            else if (CharacterSelect == 2)
                DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite().Draw(spriteBatch, new Vector2(600, 450));
            else
                DavisSpriteFactory.Instance.CreateBatWalkRightSprite().Draw(spriteBatch, new Vector2(850, 450));

            spriteBatch.DrawString(font, "SuperDavis - Team Shoryuken", new Vector2(50, 50), Color.White);
            DavisSpriteFactory.Instance.CreateDavisPortrait().Draw(spriteBatch, new Vector2(300, 300));
            DavisSpriteFactory.Instance.CreateWoodyPortrait().Draw(spriteBatch, new Vector2(550, 300));
            DavisSpriteFactory.Instance.CreateBatPortrait().Draw(spriteBatch, new Vector2(800, 300));
            spriteBatch.DrawString(font, "Press Space To Start", new Vector2(450, 550), Color.White);
        }
    }
}
