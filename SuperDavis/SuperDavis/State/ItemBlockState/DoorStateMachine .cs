﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class DoorStateMachine : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

        public DoorStateMachine(ISprite sprite)
        {
            this.Sprite = sprite;
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
