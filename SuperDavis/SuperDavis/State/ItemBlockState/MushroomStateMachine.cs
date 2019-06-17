using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class MushroomStateMachine : IGameObjectSpriteState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

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
