﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interface;
using SuperDavis.State.DavisState;
using SuperDavis.State.ItemStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Object.Item
{
    class Flower : IItem
    {
        public Vector2 Location { get; set; }
        private readonly FlowerStateMachine flowerStateMachine;

        public Flower(Vector2 location)
        {
            // initial state
            Location = location;
            flowerStateMachine = new FlowerStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            flowerStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            flowerStateMachine.Draw(spriteBatch, Location);
        }
    }
}