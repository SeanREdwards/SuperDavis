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
    class Mushroom : IItem
    {
        public Vector2 Location { get; set; }
        private readonly MushroomStateMachine mushroomStateMachine;

        public Mushroom(Vector2 location)
        {
            // initial state
            Location = location;
            mushroomStateMachine = new MushroomStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            mushroomStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mushroomStateMachine.Draw(spriteBatch, Location);
        }
    }
}
