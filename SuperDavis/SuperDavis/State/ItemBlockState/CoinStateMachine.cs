using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.State.ItemStateMachine
{
    class CoinStateMachine
    {
        private readonly ISprite sprite;

        public CoinStateMachine()
        {
            sprite = ItemSpriteFactory.Instance.CreateYoshiCoinAnimated();
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
