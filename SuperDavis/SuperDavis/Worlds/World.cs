using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;
using System.Collections.Generic;
using SuperDavis.Object.Scenery;

namespace SuperDavis.Worlds
{
    class World : IWorld
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IList<IDavis> Davises { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IBlock> Blocks { get; set; }
        public IList<IEnemy> Enemies { get; set; }
        public IList<IBackground> Backgrounds { get; set; }

        private Game1 game;

        public World(int width, int height, Game1 game)
        {
            this.game = game;
            Width = width;
            Height = height;

            // Initialize for lists
            Davises = new List<IDavis>();
            Items = new List<IItem>();
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemy>();
            Backgrounds = new List<IBackground>();
        }
        
        public void Update(GameTime gameTime)
        {
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
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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
        }

        public void ResetGame()
        {
            // Character reset
            foreach (IDavis character in Davises)
            {
                character.DavisStatus = DavisStatus.Davis;
                character.DavisState = new DavisStaticRightState(character);
                character.Location = new Vector2(game.WindowsEdgeHeight / 2, game.WindowsEdgeWidth / 2);
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


        }
    }
}
