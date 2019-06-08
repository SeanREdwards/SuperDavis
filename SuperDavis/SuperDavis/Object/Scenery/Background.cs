using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Scenery
{
    class Background : IBackground
    {
        public Vector2 Location { get; set; }
        private readonly ISprite sprite;

        public Background(Vector2 location)
        {
            // initial state
            Location = location;
            sprite = ItemSpriteFactory.Instance.CreateActivatedBlock();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }
        public void Reset()
        { }
    }
}
