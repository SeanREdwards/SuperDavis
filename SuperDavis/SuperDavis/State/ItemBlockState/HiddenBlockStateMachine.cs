﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class HiddenBlockStateMachine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public readonly ISprite Sprite;

        public HiddenBlockStateMachine(bool IsHidden)
        {
            if (IsHidden)
            {
                Sprite = ItemSpriteFactory.Instance.CreateEmptyBlock();
            }
            else
            {
                Sprite = ItemSpriteFactory.Instance.CreateActivatedBlock();
            }
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
