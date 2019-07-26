using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Cameras;
using SuperDavis.Collision;
using SuperDavis.Command;
using SuperDavis.Controller;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.LvlManager;
using SuperDavis.Sound;
using SuperDavis.Worlds;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

/* Author: Jason Xu, Ryan Knighton, and Sean Edwards */
[assembly: CLSCompliant(true)] // CA1014
[assembly: AssemblyVersionAttribute("6.6.6.6")] // CA1016
[assembly: ComVisible(false)] // CA1017

namespace SuperDavis
{
    class Game1 : Game
    {
        public IWorld World { get; set; }
        public bool IsMouseControllerOn { get; set; }
        public bool PauseFlag { get; set; }
        public bool WinGameFlag { get; set; }
        public Camera Camera { get; set; }

        public CollisionDetection CollisionDetection;
        public Momento Momento;
        public HUD HUD;

        private SpriteBatch spriteBatch;
        private List<IController> controllerList;

        private bool resetFlag;

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
            resetFlag = false;
            PauseFlag = false;
            WinGameFlag = false;
            IsMouseControllerOn = false;
            InitializeFactory();
            InitializeSounds();
            InitializeMenuController();
            WorldCreator worldCreator = new WorldCreator();
            Momento = new Momento(World, worldCreator, this);
            HUD = new HUD(Content, Momento);
            World = Momento.LoadEmpty();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            controllerList[0].Update();
            if (!Momento.IsEmpty && !PauseFlag)
            {
                CollisionDetection.CheckCollisions();
                World.Update(gameTime);
                CheckGameReset();
            }
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            if (!Momento.IsEmpty && !PauseFlag && !WinGameFlag)
            {
                Camera = new Camera(World, Variables.Variable.WindowsEdgeWidth, Variables.Variable.WindowsEdgeHeight);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Camera.Draw());
                World.Draw(spriteBatch);
                spriteBatch.End();
                HUD.Draw(gameTime, spriteBatch);
                base.Draw(gameTime);
            }
            else if (PauseFlag)
                HUD.DrawPauseMenu(spriteBatch);
            else if (WinGameFlag)
                HUD.DrawWinMenu(spriteBatch);
            else
                HUD.DrawStartMenu(spriteBatch);



            //KEEP THIS CODE, IT HELPS GENERATE WALLS AND FLOOR
            //creates  green middle block floor
            /*System.Console.WriteLine("//////////////////");
            for (int i = 0; i < 1200; i += 24)
            {
                System.Console.WriteLine("<Block Type='Brick' X='" + i + "' Y='696' />");
                System.Console.WriteLine("<Block Type='Brick' X='" + i + "' Y='672' />");
            }*/

            //creates castle floor
            //System.Console.WriteLine("//////////////////");
            //for (int i = 0; i <= 1200; i += 24)
            //{
            //    System.Console.WriteLine("<Block Type='Brick' X='" + i + "' Y='696' />");
            //    System.Console.WriteLine("<Block Type='Brick' X='" + i + "' Y='672' />");
            //}
            //System.Console.WriteLine("//////////////////");


            //creates walls
            //System.Console.WriteLine("******************");
            //hidden wall all the way to the left
            //for (int i = 0; i < 696; i += 24)
            //{
            //    System.Console.WriteLine("<Block Type='EmptyBlock' X='-24' Y='" + i + "' />");
            //}

            //castle wall between first 2 sections
            //for (int i = 0; i < 576; i += 24)
            //{
            //    System.Console.WriteLine("<Block Type='CastleBlock' X='1152' Y='" + i+"' />");
            //    System.Console.WriteLine("<Block Type='CastleBlock' X='1176' Y='" + i + "' />");
            //}

            //castle wall going into castle
            //for (int i = 0; i < 576; i += 24)
            //{
            //    System.Console.WriteLine("<Block Type='CastleBlock' X='2352' Y='" + i + "' />");
            //    System.Console.WriteLine("<Block Type='CastleBlock' X='2376' Y='" + i + "' />");
            //}

            //castle wall at the end of the level
            //for (int i = 0; i < 700; i += 24)
            //{
            //    System.Console.WriteLine("<Block Type='CastleBlock' X='3552' Y='" + i+"' />");
            //    System.Console.WriteLine("<Block Type='CastleBlock' X='3576' Y='" + i + "' />");
            //}
            //System.Console.WriteLine("******************");
        }

        /* Helper methods */
        private void InitializeFactory()
        {
            DavisSpriteFactory.Instance.Load(Content);
            ItemSpriteFactory.Instance.Load(Content);
            EnemySpriteFactory.Instance.Load(Content);
            BackgroundSpriteFactory.Instance.Load(Content);
        }

        private void InitializeSounds()
        {
            Sounds.Instance.Load(Content);
        }

        public void InitializeController()
        {
            controllerList.Clear();
            var davis = World.Characters;
            controllerList = new List<IController>()
                {
                    new KeyboardController
                    (
                      (Keys.Q, new ExitCommand(this), new NullCommand(), false),
                      (Keys.R, new ResetCommand(World), new NullCommand(), false),
                      (Keys.W, new PauseCommand(this), new NullCommand(), false),
                      (Keys.Y, new DavisToDavisCommand(davis),new NullCommand(), true),
                      (Keys.U, new DavisToWoodyCommand(davis),new NullCommand(), true),
                      (Keys.I, new DavisToBatCommand(davis),new NullCommand(), true),
                      (Keys.Left, new DavisTurnLeftCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.Right, new DavisTurnRightCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.Up, new DavisJumpCommand(davis),new DavisStaticCommand(davis), true),
                      (Keys.Down, new DavisCrouchCommand(davis), new DavisStaticCommand(davis), true),
                      (Keys.Z, new DavisJumpCommand(davis),new NullCommand(), true),
                      (Keys.X, new DavisShootBulletCommand(davis,World),new NullCommand(), false),
                      (Keys.C, new DavisSpecialAttackCommand(davis), new NullCommand(), false),
                      (Keys.M, new NullCommand(),new ToggleMouseControl(this), false)
                    )/*,
                    new GamepadController
                    (
                      (Buttons.Start, new ExitCommand(this)),
                      (Buttons.Back, new ResetCommand(World)),
                      (Buttons.LeftThumbstickLeft, new DavisTurnLeftCommand(davis, World)),
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
                    new MouseController(this),*/
                };

        }

        public void InitializeMenuController()
        {
            controllerList = new List<IController>()
            {
                new KeyboardController
                (
                    (Keys.Space, new StartCommand(this), new NullCommand(), false),
                    (Keys.Left, new StartMenuLeftCommand(this), new NullCommand(), false),
                    (Keys.Right, new StartMenuRightCommand(this), new NullCommand(), false),
                    (Keys.Q, new ExitCommand(this), new NullCommand(), false)

                )

            };
        }

        /*public void ControllerUpdate()
        {
            if (!Momento.IsEmpty)
            {
                foreach (IController controller in controllerList)
                {
                    if (controller is MouseController)
                    {
                        if (IsMouseControllerOn)
                            controller.Update();
                    }
                    else
                        controller.Update();
                }
            }
            else
                controllerList[0].Update();
        }*/

        public void CheckGameReset()
        {
            if (World.Characters == null)
            {
                resetFlag = true;
            }
            else
            {
                if (World.Characters.Location.X < -World.Characters.HitBox.Width || World.Characters.Location.X > World.Width + World.Characters.HitBox.Width || World.Characters.Location.Y > World.Height)
                    resetFlag = true;
                if (Momento.CheckPoint.Equals(Variables.Variable.FirstLevel) && World.Characters.Location.X > Variables.Variable.level11Width - Variables.Variable.UnitPixelSize)
                    Momento.Load(Variables.Variable.BossLevel);
            }

            if (resetFlag)
            {
                World.ResetGame();
                resetFlag = false;
            }
        }
    }
}
