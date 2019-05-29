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
    class StarStateMachine
    {
        private readonly ISprite sprite;

        public StarStateMachine()
        {
            sprite = ItemSpriteFactory.Instance.CreateMushroom();
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
