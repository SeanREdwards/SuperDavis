using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
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

namespace SuperDavis.World
{
    class WorldCreator : IWorldCreator
    {
        public IList<IDavis> Davises { get; set; }
        public IList<IEnemy> Enemies { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IBlock> Blocks { get; set; }

        private Game1 game1;

        /* Free lunch declaration */
        public Davis davis { get; set; }
        private Coin coin;
        private Flower flower;
        private Mushroom mushroom;
        private YoshiEgg yoshiEgg;
        private Star star;
        public HiddenBlock hiddenBlock { get; set; }
        private ActivatedBlock activatedBlock;
        public Brick brick { get; set; }
        public QuestionBlock questionBlock { get; set; }
        private Pipe pipe;
        private Goomba goomba;
        private Koopa koopa;

        public WorldCreator(Game1 game1Class)
        {
            this.game1 = game1Class;
            DumboInitialization();
        }

        /*
         * TBD: This is just a simple demo for the world creator,
         *      we actually need a helper class to read in the parsing the location,
         *      The code here needs to be modified.
         */
        public void DumboInitialization()
        {
            davis = new Davis(new Vector2(game1.WindowsEdgeHeight / 2, game1.WindowsEdgeWidth / 2));
            Davises = new List<IDavis> { davis };

            flower = new Flower(new Vector2(100, 100));
            coin = new Coin(new Vector2(200, 100));
            mushroom = new Mushroom(new Vector2(300, 100));
            yoshiEgg = new YoshiEgg(new Vector2(400, 100));
            star = new Star(new Vector2(500, 100));
            Items = new List<IItem> { flower, coin, mushroom, yoshiEgg, star };

            hiddenBlock = new HiddenBlock(new Vector2(100, 200));
            activatedBlock = new ActivatedBlock(new Vector2(200, 200));
            brick = new Brick(new Vector2(300, 200));
            questionBlock = new QuestionBlock(new Vector2(400, 200));
            pipe = new Pipe(new Vector2(500, 200));
            Blocks = new List<IBlock> { hiddenBlock, activatedBlock, brick, questionBlock, pipe };

            goomba = new Goomba(new Vector2(100, 300));
            koopa = new Koopa(new Vector2(200, 300));
            Enemies = new List<IEnemy> { goomba, koopa };
        }

        public void Update(GameTime gameTime)
        {
            // We should use IList to set those stuff in the list
            // Instead of listing them out one by one
            // which is dumbo
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
            davis.DavisStatus = DavisStatus.Davis;
            davis.DavisState = new DavisStaticRightState(davis);
            davis.Location = new Vector2(game1.WindowsEdgeHeight / 2, game1.WindowsEdgeWidth / 2);
            hiddenBlock.HiddenBlockStateMachine = new HiddenBlockStateMachine(true);
            brick.BrickStateMachine = new BrickStateMachine(false);
            questionBlock.QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
        }
    }
}
