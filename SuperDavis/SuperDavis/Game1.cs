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
        public bool IsMouseControllerOn { get; set; }

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
            IsMouseControllerOn = false;
            InitializeFactory();
            WorldCreator worldCreator = new WorldCreator();
            World = worldCreator.CreateWorld("level1-1.xml", Variables.Variable.WindowsEdgeWidth, Variables.Variable.WindowsEdgeHeight);
            collisionDetection = new CollisionDetection(World);
            InitializeController();
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
                if (controller is MouseController)
                {
                    if (IsMouseControllerOn)
                    {
                        controller.Update();
                    }
                }
                else
                {
                    controller.Update();
                }
            }
            // Just to write the coords for world generator
            System.Console.WriteLine("***************************************");
            for(int i = 0; i<100; i++)
            {
                System.Console.WriteLine("  <Block Type=\"ActivatedBlock\" X="+i*16+" Y=\"752\" />");
                System.Console.WriteLine("  <Block Type=\"ActivatedBlock\" X="+i*16+" Y=\"736\" />");
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
        private void InitializeFactory()
        {
            DavisSpriteFactory.Instance.Load(Content);
            ItemSpriteFactory.Instance.Load(Content);
            EnemySpriteFactory.Instance.Load(Content);
            BackgroundSpriteFactory.Instance.Load(Content);
        }

        private void InitializeController()
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
                    new MouseController(this),
                };
            };
        }
    }
}
