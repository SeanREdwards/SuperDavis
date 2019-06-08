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
using SuperDavis.Worlds;

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
        public IWorld World { get; set; }
        public bool ToggleMouseControl { get; set; }

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
            ToggleMouseControl = false;
            InitializaFactory();
            // TBD
            World = WorldCreator.CreateWorld("test-level.xml", WindowsEdgeWidth, WindowsEdgeHeight, this);
            // Doesn't seems to be a good practice ^^^
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
            UpdateController();
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

        /* Helper methods */
        private void InitializaFactory()
        {
            DavisSpriteFactory.Instance.Load(Content);
            ItemSpriteFactory.Instance.Load(Content);
            EnemySpriteFactory.Instance.Load(Content);
        }

        private void InitializeKeybinding()
        {
            foreach (IDavis davis in World.Davises)
            {
                controllerList = new List<IController>()
                {
                    new KeyboardController
                    (
                      (Keys.Q, new ExitCommand(this)),
                      (Keys.R, new ResetCommand(World)),
                      (Keys.A, new DavisTurnLeftCommand(davis)),
                      (Keys.D, new DavisTurnRightCommand(davis)),
                      (Keys.W, new DavisJumpCommand(davis)),
                      (Keys.S, new DavisCrouchCommand(davis)),
                      (Keys.Y, new DavisToDavisCommand(davis)),
                      (Keys.U, new DavisToWoodyCommand(davis)),
                      (Keys.I, new DavisToBatCommand(davis)),
                      (Keys.Left, new DavisTurnLeftCommand(davis)),
                      (Keys.Right, new DavisTurnRightCommand(davis)),
                      (Keys.Up, new DavisJumpCommand(davis)),
                      (Keys.Down, new DavisCrouchCommand(davis)),
                      (Keys.O, new DavisDeathCommand(davis)),
                      (Keys.P, new DavisSpecialAttackCommand(davis)),
                      (Keys.M, new ToggleMouseControl(this))
                    )
                };

            };

        }

        private void UpdateController()
        {
            if (ToggleMouseControl)
            {
                if (controllerList.Count==1) { 
                    controllerList.Add(new MouseController(this));
                }
            }
            else
            {
                if (controllerList.Count > 1)
                {
                    controllerList.RemoveAt(1);
                }

            }
        }

    }
}
