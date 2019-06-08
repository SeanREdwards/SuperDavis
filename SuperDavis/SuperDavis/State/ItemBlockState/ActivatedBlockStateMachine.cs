using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class ActivatedBlockStateMachine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public readonly ISprite Sprite;

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
