﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.SpriteState.ItemStateMachine
{
    class ActivatedBlockStateMachine : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

        public ActivatedBlockStateMachine()
        {
            Sprite = ItemSpriteFactory.Instance.CreateActivatedBlock();
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
