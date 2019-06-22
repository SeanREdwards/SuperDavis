using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Cameras;
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
        public CollisionDetection collisionDetection;
        private Camera camera;
        private int deathTimer = 100;
        public IWorld World { get; set; }
        public bool IsMouseControllerOn { get; set; }

        public Game1()
        {
            using (var graphicsDeviceManager = new GraphicsDeviceManager(game: this))
            {
                graphicsDeviceManager.PreferredBackBufferWidth = Variables.Variable.WindowsEdgeWidth;
                graphicsDeviceManager.PreferredBackBufferHeight = Variables.Variable.WindowsEdgeHeight;
                graphicsDeviceManager.ApplyChanges();
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
            World = worldCreator.CreateWorld("level1-1.xml", Variables.Variable.WindowsEdgeWidth, Variables.Variable.WindowsEdgeHeight,this);
            // After creating world, pass the world into collision detection
            // But 
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
            if (World.Davises[0].Location.X < - 100 || World.Davises[0].Location.X > 4900 || World.Davises[0].Location.Y > 768)
            {
                World.ResetGame();
            }
            if (World.Davises[0].Remove)
            {
                if(deathTimer > 0)
                {
                    deathTimer--;
                }
                else
                {
                    World.ResetGame();
                    deathTimer = 100;
                }
            }
            World.Update(gameTime);
            collisionDetection.CheckCollisions();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            camera = new Camera(World, Variables.Variable.WindowsEdgeWidth,Variables.Variable.WindowsEdgeHeight);
            //spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //spriteBatch.DrawString(spriteFont:,"FPS+framerate",newVector2(0,0),color.)
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.Draw());
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

        public void InitializeController()
        {
            foreach (IDavis davis in World.Davises)
            {
                controllerList = new List<IController>()
                {
                    new KeyboardController
                    (
                      (Keys.Q, new ExitCommand(this), new NullCommand(), false),
                      (Keys.R, new ResetCommand(World), new NullCommand(), false),
                      (Keys.S, new DavisCrouchCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.A, new DavisTurnLeftCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.D, new DavisTurnRightCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.W, new DavisJumpCommand(davis),new NullCommand(), true),
                      (Keys.Y, new DavisToDavisCommand(davis),new NullCommand(), true),
                      (Keys.U, new DavisToWoodyCommand(davis),new NullCommand(), true),
                      (Keys.I, new DavisToBatCommand(davis),new NullCommand(), true),
                      (Keys.Left, new DavisTurnLeftCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.Right, new DavisTurnRightCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.Up, new DavisJumpCommand(davis),new NullCommand(), true),
                      (Keys.Z, new DavisJumpCommand(davis),new NullCommand(), true),
                      (Keys.X, new DavisShootBulletCommand(davis,World),new NullCommand(), false),
                      (Keys.Down, new DavisCrouchCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.O, new DavisDeathCommand(davis), new NullCommand(), true),
                      (Keys.P, new DavisSpecialAttackCommand(davis), new NullCommand(), true),
                      (Keys.M, new NullCommand(),new ToggleMouseControl(this), false)
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
