using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class MushroomStateMachine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ISprite Sprite;

        public MushroomStateMachine()
        {
            Sprite = ItemSpriteFactory.Instance.CreateRedMushroom();
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
