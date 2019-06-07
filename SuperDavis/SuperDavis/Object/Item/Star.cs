﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Star : IItem
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        private StarStateMachine starStateMachine;
        private ISprite item;
        public Rectangle HitBox { get; set; }

        public Star(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            starStateMachine = new StarStateMachine();
            item = starStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, item.Width, item.Height);
        }

        public void Update(GameTime gameTime)
        {
            starStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                starStateMachine.Draw(spriteBatch, Location);
            }
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
