using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Variables;
using SuperDavis.Object.Character;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Sound;

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
            spriteBatch.End();

            if (lives < 0)
            {
                DrawGameOverMenu(gameTime, font, spriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "" + (int)lives, new Vector2(1050, 60), Color.White);
                spriteBatch.End();
            }
        }

        public void DrawStartMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            StartMenuContext(gameTime, font, spriteBatch);
            spriteBatch.End();
        }

        public void DrawPauseMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            PauseMenu(gameTime, font, spriteBatch);
            spriteBatch.End();
        }

        public void PauseMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Paused, Go grab some snacks kid", new Vector2(450, 400), Color.White);
        }

        public void DrawWinMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            WinMenu(gameTime, font, spriteBatch);
            spriteBatch.End();
        }

        public void WinMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Well, You have made it!", new Vector2(500, 400), Color.White);
        }

        public void DrawGameOverMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            GameOverMenu(gameTime, font, spriteBatch);
            spriteBatch.End();
        }

        public void GameOverMenu(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(font, "Game Over!", new Vector2(500, 350), Color.White);
            spriteBatch.DrawString(font, "COME ON! YOU SUCKKKKKKKK", new Vector2(380, 400), Color.White);
            Sounds.Instance.MusicInstance.IsLooped = false;
            Sounds.Instance.MusicInstance.Pause();

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
