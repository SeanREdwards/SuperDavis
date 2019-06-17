using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class HiddenBlockStateMachine : IGameObjectSpriteState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

        public HiddenBlockStateMachine(bool isHidden)
        {
            if (isHidden)
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
