﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Variables;
using SuperDavis.Object.Character;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Sound;
using Microsoft.Xna.Framework.Content;

namespace SuperDavis
{
    public class HUD
    {
        public int score = Variable.score;
        public int coins = Variable.coins;
        public int lives = Variable.lives;
        public string worldText = Variable.worldText;
        public double time = Variable.time;

        private int scrollingFactor = 0;
        public int CharacterSelect { get; set; }

        private readonly SpriteFont font;
        private readonly SpriteFont fontBig;
        private readonly SpriteFont fontMenu;

        public HUD(ContentManager Content)
        {
            CharacterSelect = 1;
            font = Content.Load<SpriteFont>("Font/File");
            fontMenu = Content.Load<SpriteFont>("Font/fontMenu");
            fontBig = Content.Load<SpriteFont>("Font/Bigfont");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
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

            if (lives <= 0)
            {
                DrawGameOverMenu(spriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "" + (int)lives, new Vector2(1050, 60), Color.White);
                spriteBatch.End();
            }
        }

        public void DrawStartMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            StartMenuContext(spriteBatch);
            spriteBatch.End();
        }

        public void DrawPauseMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "PAUSE! GO GRAB SOME SNACKS KIDDO", new Vector2(350, 300), Color.Gold);
            spriteBatch.End();
        }

        public void DrawWinMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(fontBig, "HUH, PURE LUCK MORTAL", new Vector2(500, 360), Color.White);
            spriteBatch.End();
        }

        public void DrawGameOverMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            GameOverMenu(spriteBatch);
            spriteBatch.End();
        }

        public void GameOverMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(fontBig, "Death Recap:", new Vector2(420, 250), Color.Gray);
            spriteBatch.DrawString(fontBig, "STUPUDITY!!!", new Vector2(420, 350), Color.Red);
            Sounds.Instance.MusicInstance.IsLooped = false;
            Sounds.Instance.MusicInstance.Pause();

        }
        /* Helper Method */
        public void StartMenuContext(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            if (this.CharacterSelect == 1)
                DavisSpriteFactory.Instance.CreateDavisWalkRightSprite().Draw(spriteBatch, new Vector2(350, 450));
            else if (CharacterSelect == 2)
                DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite().Draw(spriteBatch, new Vector2(600, 450));
            else
                DavisSpriteFactory.Instance.CreateBatWalkRightSprite().Draw(spriteBatch, new Vector2(850, 450));

            spriteBatch.DrawString(fontMenu, "Team SHORYUKEN", new Vector2(50 , 50), Color.Gray);

            spriteBatch.DrawString(fontMenu, "SUPER DUPER DAVIS", new Vector2((float)3.6 * scrollingFactor, 150 + (float) 1 * (scrollingFactor % 100)), Color.Yellow);
            DavisSpriteFactory.Instance.CreateDavisPortrait().Draw(spriteBatch, new Vector2(300, 300));
            DavisSpriteFactory.Instance.CreateWoodyPortrait().Draw(spriteBatch, new Vector2(550, 300));
            DavisSpriteFactory.Instance.CreateBatPortrait().Draw(spriteBatch, new Vector2(800, 300));
            spriteBatch.DrawString(fontMenu, "Press Space To Start", new Vector2(450, 600), Color.White);
            scrollingFactor++;
            if (scrollingFactor == 333)
                scrollingFactor = 0;
        }

    }
}
