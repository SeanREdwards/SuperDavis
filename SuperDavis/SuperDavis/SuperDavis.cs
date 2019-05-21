using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperDavisDemo.Controller;
using SuperDavisDemo.Interface;
using SuperDavisDemo.Sprite;

/*Author: Jason Xu, Ryan Knighton, Jeremy Alexander and Sean Edwards */
namespace SuperDavisDemo
{
    class SuperDavis : Game
    {

        public Vector2 DavisPos { get; set; }
        public ISprite DavisSprite { get; set; }
        public Texture2D DavisAnimated;
        public Texture2D DavisStatic;
        public int WindowsEdgeWidth;
        public int WindowsEdgeHeight;

        private SpriteBatch spriteBatch;
        private List<IController> controllerList;

        //Sean Edwards Sprint_1 code addition for git.
        bool seansSprintOneAddition;

        public SuperDavis()
        {
            //Sean Edwards Sprint_1 code addition for git.
            bool seansSprintOneAddition = true;

            var graphicsDeviceManager = new GraphicsDeviceManager(game:this);
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
            controllerList = new List<IController>()
            {
                {new KeyboardController(this)},
                {new GamepadController(this)}
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            DavisAnimated = Content.Load<Texture2D>("davis_animated");
            DavisStatic = Content.Load<Texture2D>("davis_static");
            DavisPos = new Vector2((GraphicsDevice.Viewport.Width - DavisStatic.Width) / 2 , (GraphicsDevice.Viewport.Height - DavisStatic.Height) / 2);
            DavisSprite = new StaticSprite(DavisStatic, this);
        }

        protected override void UnloadContent() { }
        
        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update();
            }
            DavisSprite.Update(gameTime);
            base.Update(gameTime);
        }
   
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DavisSprite.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void CreateStaticSprite()
        {
            this.DavisSprite = new StaticSprite(DavisStatic, this);
        }

        public void CreateAnimateSprite()
        {
            this.DavisSprite = new AnimateSprite(DavisAnimated, 8, this);
        }

        public void CreateUpSprite()
        {
            this.DavisSprite = new UpSprite(DavisStatic, this);
        }

        public void CreateRightSprite()
        {
            this.DavisSprite = new RightSprite(DavisAnimated, 8, this);
        }

    }
}
