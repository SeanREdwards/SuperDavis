using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class YoshiEggStateMachine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly ISprite sprite;

        public YoshiEggStateMachine()
        {
            sprite = ItemSpriteFactory.Instance.CreateYoshiEgg();
            Width = sprite.Width;
            Height = sprite.Height;
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
