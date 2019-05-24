﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private SpriteBatch spriteBatch;
        private List<IController> controllerList;

        public int WindowsEdgeWidth;
        public int WindowsEdgeHeight;
        public SuperDavis()
        {
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
            DavisSpriteFactory.Instance.Load(Content);
            Davis = new Davis();
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
        }

        protected override void UnloadContent() { }
        
        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update();
            }
            Davis.Update(gameTime);
            base.Update(gameTime);
        }
   
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            Davis.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
