﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class BrickStateMachine
    {
        private ISprite sprite;

        public BrickStateMachine(bool IsBroken)
        {
            if (!IsBroken)
            {
                sprite = ItemSpriteFactory.Instance.CreateBrickBlock();
            }
            else
            {
                sprite = ItemSpriteFactory.Instance.CreateEmptyBlock();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
