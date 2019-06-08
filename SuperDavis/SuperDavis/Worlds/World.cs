using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Background;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.State.DavisState;
using SuperDavis.State.ItemStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Worlds
{
    class World : IWorld
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Background Bkgnd;
        public IList<IDavis> Davises { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IBlock> Blocks { get; set; }
        public IList<IEnemy> Enemies { get; set; }

        private Game1 game;

        public World(int width, int height, Game1 game)
        {
            this.game = game;
            Width = width;
            Height = height;

            // Initialize for lists
            Bkgnd = new Background();
            Davises = new List<IDavis>();
            Items = new List<IItem>();
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemy>();
        }
        
        public void Update(GameTime gameTime)
        {
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
            //Bkgnd.Draw(spriteBatch, new Vector2(1024,768));
            foreach (IDavis character in Davises)
            {
                character.Draw(spriteBatch);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
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
                if(block is HiddenBlock)
                {
                    //block.Reset();
                } 
            }
            foreach (IEnemy enemy in Enemies)
            {
                //TBD
            }

        }
    }
}
