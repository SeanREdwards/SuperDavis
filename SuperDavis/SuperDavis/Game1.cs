using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Command;
using SuperDavis.Controller;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.State.DavisState;
using SuperDavis.State.ItemStateMachine;

/*Author: Jason Xu, Ryan Knighton, and Sean Edwards */
[assembly: CLSCompliant(true)] // CA1014
[assembly: AssemblyVersionAttribute("6.6.6.6")] // CA1016
[assembly: ComVisible(false)] // CA1017
namespace SuperDavis
{
    class Game1 : Game
    {
        private Davis davis;
        private Coin coin;
        private Flower flower;
        private Mushroom mushroom;
        private YoshiEgg yoshiEgg;
        private Star star;
        private HiddenBlock hiddenBlock;
        private ActivatedBlock activatedBlock;
        private Brick brick;
        private QuestionBlock questionBlock;
        private Pipe pipe;
        private Goomba goomba;
        private Koopa koopa;

        private SpriteBatch spriteBatch;
        private List<IController> controllerList;

        public int WindowsEdgeWidth;
        public int WindowsEdgeHeight;

        public Game1()
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

        /* Reset Game*/
        public void ResetGame()
        {
            davis.DavisStatus = DavisStatus.Davis;
            davis.DavisState = new DavisStaticRightState(davis);
            hiddenBlock.HiddenBlockStateMachine = new HiddenBlockStateMachine(true);
            brick.BrickStateMachine = new BrickStateMachine(false);
            questionBlock.QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
        }

        /* Helper methods */
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
                    (Keys.R, new ResetCommand(this)),
                    (Keys.A, new DavisTurnLeftCommand(davis)),
                    (Keys.D, new DavisTurnRightCommand(davis)),
                    (Keys.W, new DavisJumpCommand(davis)),
                    (Keys.S, new DavisCrouchCommand(davis)),
                    (Keys.Y, new DavisToDavisCommand(davis)),
                    (Keys.U, new DavisToWoodyCommand(davis)),
                    (Keys.I, new DavisToBatCommand(davis)),
                    (Keys.C, new ShowHiddenBlockCommand(hiddenBlock)),
                    (Keys.X, new BreakBrickCommand(brick)),
                    (Keys.Z, new UseQuestionBlockCommand(questionBlock)),
                    (Keys.Left, new DavisTurnLeftCommand(davis)),
                    (Keys.Right, new DavisTurnRightCommand(davis)),
                    (Keys.Up, new DavisJumpCommand(davis)),
                    (Keys.Down, new DavisCrouchCommand(davis)),
                    (Keys.O, new DavisDeathCommand(davis)),
                    (Keys.P, new DavisSpecialAttackCommand(davis))
                )}
            };
        }

        private void InitializeObject()
        {
            davis = new Davis(new Vector2(WindowsEdgeWidth / 2, WindowsEdgeHeight / 2));
            flower = new Flower(new Vector2(100, 100));
            coin = new Coin(new Vector2(200,100));
            mushroom = new Mushroom(new Vector2(300, 100));
            yoshiEgg = new YoshiEgg(new Vector2(400, 100));
            star = new Star(new Vector2(500, 100));
            hiddenBlock = new HiddenBlock(new Vector2(100, 200));
            activatedBlock = new ActivatedBlock(new Vector2(200, 200));
            brick = new Brick(new Vector2(300, 200));
            questionBlock = new QuestionBlock(new Vector2(400, 200));
            pipe = new Pipe(new Vector2(500, 200));
            goomba = new Goomba(new Vector2(100, 300));
            koopa = new Koopa(new Vector2(200, 300));
        }

        private void UpdateObject(GameTime gameTime)
        {
            davis.Update(gameTime);
            flower.Update(gameTime);
            coin.Update(gameTime);
            mushroom.Update(gameTime);
            yoshiEgg.Update(gameTime);
            star.Update(gameTime);
            hiddenBlock.Update(gameTime);
            activatedBlock.Update(gameTime);
            brick.Update(gameTime);
            questionBlock.Update(gameTime);
            pipe.Update(gameTime);
            goomba.Update(gameTime);
            koopa.Update(gameTime);
        }

        private void DrawObject(SpriteBatch spriteBatch1)
        {
            davis.Draw(spriteBatch1);
            flower.Draw(spriteBatch1);
            coin.Draw(spriteBatch1);
            mushroom.Draw(spriteBatch1);
            yoshiEgg.Draw(spriteBatch1);
            star.Draw(spriteBatch1);
            hiddenBlock.Draw(spriteBatch1);
            activatedBlock.Draw(spriteBatch1);
            brick.Draw(spriteBatch1);
            questionBlock.Draw(spriteBatch1);
            pipe.Draw(spriteBatch1);
            goomba.Draw(spriteBatch1);
            koopa.Draw(spriteBatch1);
        }
    }
}
