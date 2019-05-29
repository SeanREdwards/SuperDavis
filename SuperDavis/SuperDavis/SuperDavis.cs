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
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using SuperDavis.Object.Item;
using SuperDavis.Sprite;

/*Author: Jason Xu, Ryan Knighton, and Sean Edwards */
namespace SuperDavis
{
    class SuperDavis : Game
    {
        public Davis Davis { get; set; }
        public Coin Coin { get; set; }
        public Flower Flower { get; set; }
        public Mushroom Mushroom { get; set; }
        public HealthMushroom HealthMushroom { get; set; }
        public Star Star { get; set; }
        public HiddenBlock HiddenBlock { get; set; }
        public ActivatedBlock ActivatedBlock { get; set; }
        public Brick Brick { get; set; }
        public QuestionBlock QuestionBlock { get; set; }
        public Pipe Pipe { get; set; }
        

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
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            UpdateObject(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DrawObject(spriteBatch);
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
                    (Keys.I, new DavisToBatCommand(Davis)),
                    (Keys.C, new ShowHiddenBlockCommand(HiddenBlock)),
                    (Keys.X, new BreakBrickCommand(Brick)),
                    (Keys.Z, new UseQuestionBlockCommand(QuestionBlock))
                )
            },
                {new GamepadController(this)}
            };

        }

        private void InitializeObject()
        {
            Davis = new Davis(new Vector2(WindowsEdgeWidth / 2, WindowsEdgeHeight / 2));
            Flower = new Flower(new Vector2(100, 100));
            Coin = new Coin(new Vector2(200,100));
            Mushroom = new Mushroom(new Vector2(300, 100));
            HealthMushroom = new HealthMushroom(new Vector2(400, 100));
            Star = new Star(new Vector2(500, 100));
            HiddenBlock = new HiddenBlock(new Vector2(100, 200));
            ActivatedBlock = new ActivatedBlock(new Vector2(200, 200));
            Brick = new Brick(new Vector2(300, 200));
            QuestionBlock = new QuestionBlock(new Vector2(400, 200));
            Pipe = new Pipe(new Vector2(500, 200));
        }

        private void UpdateObject(GameTime gameTime)
        {
            Davis.Update(gameTime);
            Flower.Update(gameTime);
            Coin.Update(gameTime);
            Mushroom.Update(gameTime);
            HealthMushroom.Update(gameTime);
            Star.Update(gameTime);
            HiddenBlock.Update(gameTime);
            ActivatedBlock.Update(gameTime);
            Brick.Update(gameTime);
            QuestionBlock.Update(gameTime);
            Pipe.Update(gameTime);
        }

        private void DrawObject(SpriteBatch spriteBatch)
        {
            Davis.Draw(spriteBatch);
            Flower.Draw(spriteBatch);
            Coin.Draw(spriteBatch);
            Mushroom.Draw(spriteBatch);
            HealthMushroom.Draw(spriteBatch);
            Star.Draw(spriteBatch);
            HiddenBlock.Draw(spriteBatch);
            ActivatedBlock.Draw(spriteBatch);
            Brick.Draw(spriteBatch);
            QuestionBlock.Draw(spriteBatch);
            Pipe.Draw(spriteBatch);
        }
    }
}
