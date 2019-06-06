using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class HiddenBlockStateMachine
    {
        private readonly ISprite sprite;

        public HiddenBlockStateMachine(bool IsHidden)
        {
            if (IsHidden)
            {
                sprite = ItemSpriteFactory.Instance.CreateEmptyBlock();
            }
            else
            {
                sprite = ItemSpriteFactory.Instance.CreateActivatedBlock();
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
