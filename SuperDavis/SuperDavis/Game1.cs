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

        public IWorld World { get; set; }
        public bool ToggleMouseControl { get; set; }

        public Game1()
        {
            using (var graphicsDeviceManager = new GraphicsDeviceManager(game: this))
            {
                graphicsDeviceManager.PreferredBackBufferWidth = Variables.Variable.WindowsEdgeWidth;
                graphicsDeviceManager.PreferredBackBufferHeight = Variables.Variable.WindowsEdgeHeight;
                graphicsDeviceManager.DeviceCreated += (o, e) =>
                {
                    spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
                };
            }
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ToggleMouseControl = false;
            InitializaFactory();
            // TBD
            World = WorldCreator.CreateWorld("test-level.xml", Variables.Variable.WindowsEdgeWidth, Variables.Variable.WindowsEdgeHeight, this);
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
            BackgroundSpriteFactory.Instance.Load(Content);
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
                    ),
                    new GamepadController
                    (
                      (Buttons.Start, new ExitCommand(this)),
                      (Buttons.Back, new ResetCommand(World)),
                      (Buttons.LeftThumbstickLeft, new DavisTurnLeftCommand(davis)),
                      (Buttons.LeftThumbstickRight, new DavisTurnRightCommand(davis)),
                      (Buttons.LeftThumbstickUp, new DavisJumpCommand(davis)),
                      (Buttons.LeftThumbstickDown, new DavisCrouchCommand(davis)),
                      (Buttons.X, new DavisToDavisCommand(davis)),
                      (Buttons.Y, new DavisToWoodyCommand(davis)),
                      (Buttons.LeftTrigger, new DavisToBatCommand(davis)),
                      (Buttons.RightTrigger, new DavisDeathCommand(davis)),
                      (Buttons.A, new DavisSpecialAttackCommand(davis)),
                      (Buttons.B, new ToggleMouseControl(this))
                    ),
                };
            };
        }

        /* Needs to be improved */
        private void UpdateController()
        {
            if (ToggleMouseControl)
            {
                if (controllerList.Count == 2) { 
                    controllerList.Add(new MouseController(this));
                }
            }
            else
            {
                if (controllerList.Count > 2)
                {
                    controllerList.RemoveAt(2);
                }

            }
        }

    }
}
