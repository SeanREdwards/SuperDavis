﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Star : IItem
    {
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        private readonly StarStateMachine starStateMachine;
        private readonly ISprite item;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = 35;
        public Star(Vector2 location)
        {
            // initial state
            Remove = false;
            IsAnimated = false;
            Location = location;
            starStateMachine = new StarStateMachine();
            item = starStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
            {
                starStateMachine.Update(gameTime);
                if (!IsAnimated)
                {
                    if (timer > 0)
                    {
                        Location += new Vector2(0, -0.35f);
                        timer--;
                    }
                    else
                    {
                        timer = 30;
                        IsAnimated = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                starStateMachine.Draw(spriteBatch, Location);
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
