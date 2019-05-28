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

        //TEST SPRITE
        ISprite testSprite;

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

            /*Sprite test hardcoding.*/
            /*Used by Sean Edwards for on the fly sprite testing.*/
            Texture2D davisRightZero = Content.Load<Texture2D>("DavisSprites/DavisRight_0");
            Texture2D davisRightOne = Content.Load<Texture2D>("DavisSprites/DavisRight_1");
            Texture2D davisRightTwo = Content.Load<Texture2D>("DavisSprites/DavisRight_2");
            Texture2D davisLeftZero = Content.Load<Texture2D>("DavisSprites/DavisLeft_0");
            Texture2D davisLeftOne = Content.Load<Texture2D>("DavisSprites/DavisLeft_1");
            Texture2D davisLeftTwo = Content.Load<Texture2D>("DavisSprites/DavisLeft_2");

            /*Basic sprite states facing right*/
            //List<Coordinate> standRight = new List<Coordinate>() { new Coordinate(19, 7, 37, 72)};
            //testSprite = new GenerateSprite(davisRightZero, standRight);

            //List<Coordinate> walkRight = new List<Coordinate>() { new Coordinate(338, 6, 38, 73), new Coordinate(421, 6, 35, 73), new Coordinate(502, 6, 34, 73), new Coordinate(582, 7, 35, 72) };
            //testSprite = new GenerateSprite(davisRightZero, walkRight);

            //List<Coordinate> crouchRight = new List<Coordinate>() { new Coordinate(24, 509, 36, 50)};
            //testSprite = new GenerateSprite(davisRightZero, crouchRight);

            //List<Coordinate> deathRight = new List<Coordinate>() { new Coordinate(320, 366, 79, 32)};
            //testSprite = new GenerateSprite(davisRightZero, deathRight);

            /*Basic sprite states facing left*/
            //List<Coordinate> standLeft = new List<Coordinate>() { new Coordinate(744, 7, 37, 72)};
            //testSprite = new GenerateSprite(davisLeftZero, standLeft);

            //List<Coordinate> walkLeft = new List<Coordinate>() { new Coordinate(424, 6, 38, 73), new Coordinate(344, 6, 35, 73), new Coordinate(264, 6, 34, 73), new Coordinate(183, 7, 35, 72) };
            //testSprite = new GenerateSprite(davisLeftZero, walkLeft);

            //List<Coordinate> crouchLeft = new List<Coordinate>() { new Coordinate(740, 509, 36, 50)};
            //testSprite = new GenerateSprite(davisLeftZero, crouchLeft);

            //List<Coordinate> deathLeft = new List<Coordinate>() { new Coordinate(401, 366, 79, 32)};
            //testSprite = new GenerateSprite(davisLeftZero, deathLeft);

            /*Advanced animation*/
            List<Coordinate> specialAttackRight = new List<Coordinate>() { new Coordinate(18, 7, 38, 72), new Coordinate(97, 8, 41, 71), new Coordinate(181, 9, 48, 70), new Coordinate(261, 8, 56, 71), new Coordinate(332, 9, 66, 70), new Coordinate(421, 8, 42, 71), new Coordinate(501, 8, 42, 71), new Coordinate(581, 10, 55, 69), new Coordinate(655, 9, 63, 70), new Coordinate(725, 10, 55, 69) };
            testSprite = new GenerateSprite(davisRightTwo, specialAttackRight);



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

            //Sean Test
            testSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            Davis.Draw(spriteBatch);
            Coin.Draw(spriteBatch);

            //Sean testing
            testSprite.Draw(spriteBatch, new Vector2(WindowsEdgeWidth / 2, WindowsEdgeHeight / 4));

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /* Helper method for initialization */
        private void InitializaFactory()
        {
            DavisSpriteFactory.Instance.Load(Content);
            ItemSpriteFactory.Instance.Load(Content);
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
