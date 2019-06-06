using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Collision;
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
using SuperDavis.World;

/*Author: Jason Xu, Ryan Knighton, and Sean Edwards */
[assembly: CLSCompliant(true)] // CA1014
[assembly: AssemblyVersionAttribute("6.6.6.6")] // CA1016
[assembly: ComVisible(false)] // CA1017
namespace SuperDavis
{
    class Game1 : Game
    {
        private SpriteBatch spriteBatch;
        private List<IController> controllerList;
        private CollisionDetection collisionDetection;

        public int WindowsEdgeWidth;
        public int WindowsEdgeHeight;
        public IWorld World;

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
            // TBD
            World = new World.World(this,1,1);
            collisionDetection = new CollisionDetection(World);
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
            World.Update(gameTime);
            collisionDetection.CheckCollisions();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            World.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /*
        public void ResetGame()
        {
            davis.DavisState = new DavisStaticRightState(davis);
            hiddenBlock.HiddenBlockStateMachine = new HiddenBlockStateMachine(true);
            brick.BrickStateMachine = new BrickStateMachine(false);
            questionBlock.QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
        }
        */

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
                    (Keys.R, new ResetCommand(World)),
                    (Keys.A, new DavisTurnLeftCommand(World.davis)),
                    (Keys.D, new DavisTurnRightCommand(World.davis)),
                    (Keys.W, new DavisJumpCommand(World.davis)),
                    (Keys.S, new DavisCrouchCommand(World.davis)),
                    (Keys.Y, new DavisToDavisCommand(World.davis)),
                    (Keys.U, new DavisToWoodyCommand(World.davis)),
                    (Keys.I, new DavisToBatCommand(World.davis)),
                    (Keys.C, new ShowHiddenBlockCommand(World.hiddenBlock)),
                    (Keys.X, new BreakBrickCommand(World.brick)),
                    (Keys.Z, new UseQuestionBlockCommand(World.questionBlock)),
                    (Keys.Left, new DavisTurnLeftCommand(World.davis)),
                    (Keys.Right, new DavisTurnRightCommand(World.davis)),
                    (Keys.Up, new DavisJumpCommand(World.davis)),
                    (Keys.Down, new DavisCrouchCommand(World.davis)),
                    (Keys.O, new DavisDeathCommand(World.davis)),
                    (Keys.P, new DavisSpecialAttackCommand(World.davis))
                )}
            };
        }

    }
}
