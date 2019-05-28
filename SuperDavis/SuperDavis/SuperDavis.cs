using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Command;
using SuperDavis.Controller;
using SuperDavis.Factory;
using SuperDavis.Interface;
using SuperDavis.Object;
using SuperDavis.Sprite;

/*Author: Jason Xu, Ryan Knighton, Jeremy Alexander and Sean Edwards */
namespace SuperDavis
{
    class SuperDavis : Game
    {

        public Davis Davis { get; set; }
        public Coin Coin { get; set; }

        private SpriteBatch spriteBatch;
        private List<IController> controllerList;

        public int WindowsEdgeWidth;
        public int WindowsEdgeHeight;

        public SuperDavis()
        {
            var graphicsDeviceManager = new GraphicsDeviceManager(game: this);
            WindowsEdgeWidth = 1024;
            WindowsEdgeHeight = 768;
            graphicsDeviceManager.PreferredBackBufferWidth = WindowsEdgeWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WindowsEdgeHeight;
            graphicsDeviceManager.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            InitializaFactory();
            InitializeObject();
            InitializeKeybinding();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //*Pipes*/
            //List<Coordinate> greenPipe = new List<Coordinate>() { new Coordinate(96, 0, 32, 32) };
            //testSprite = new GenerateSprite(blocksAndPipesTwo, greenPipe);

            //List<Coordinate> yellowPipe = new List<Coordinate>() { new Coordinate(128, 0, 32, 32) };
            //testSprite = new GenerateSprite(blocksAndPipesTwo, yellowPipe);

            //List<Coordinate> bluePipe = new List<Coordinate>() { new Coordinate(160, 0, 32, 32) };
            //testSprite = new GenerateSprite(blocksAndPipesTwo, bluePipe);



            /*Items*/
            //List<Coordinate> yoshiCoinStatic = new List<Coordinate>() { new Coordinate(0, 32, 16, 32) };
            //testSprite = new GenerateSprite(blocksAndPipesTwo, yoshiCoinStatic);

            //List<Coordinate> yoshiCoinAnimated = new List<Coordinate>() { new Coordinate(0, 32, 16, 32), new Coordinate(16, 32, 16, 32), new Coordinate(32, 32, 16, 32), new Coordinate(48, 32, 16, 32), new Coordinate(64, 32, 16, 32), new Coordinate(80, 32, 16, 32)};
            //testSprite = new GenerateSprite(blocksAndPipesTwo, yoshiCoinAnimated);

            //List<Coordinate> fireFlowerStatic = new List<Coordinate>() { new Coordinate(202, 107, 16, 16)};
            //testSprite = new GenerateSprite(blocksAndPipes, fireFlowerStatic);

            //List<Coordinate> mushroomStatic = new List<Coordinate>() { new Coordinate(182, 107, 16, 16) };
            //testSprite = new GenerateSprite(blocksAndPipes, mushroomStatic);


        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            Davis.Update(gameTime);
            Coin.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            Davis.Draw(spriteBatch);
            Coin.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /* Helper method for initialization */
        private void InitializaFactory()
        {
            DavisSpriteFactory.Instance.Load(Content);
            ItemSpriteFactory.Instance.Load(Content);
            EnemySpriteFactory.Instance.Load(Content);
        }

        private void InitializeKeybinding()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController
                (
                    (Keys.Q, new ExitCommand(this)),
                    (Keys.A, new DavisTurnLeftCommand(Davis)),
                    (Keys.D, new DavisTurnRightCommand(Davis)),
                    (Keys.Y, new DavisToDavisCommand(Davis)),
                    (Keys.U, new DavisToWoodyCommand(Davis)),
                    (Keys.I, new DavisToBatCommand(Davis))
                )},
                {new GamepadController(this)}
            };

        }

        private void InitializeObject()
        {
            Davis = new Davis(new Vector2(WindowsEdgeWidth / 2, WindowsEdgeHeight / 2));
            Coin = new Coin(new Vector2(WindowsEdgeWidth / 2, WindowsEdgeHeight / 2 - 100));
        }

    }
}
