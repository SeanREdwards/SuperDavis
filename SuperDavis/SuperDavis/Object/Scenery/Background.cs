using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.Object.Scenery
{
    class Background : IBackground
    {
        public Vector2 Location { get; set; }
        private readonly ISprite backgroundImage; 

        public Background(Vector2 location)
        {
            // initial state
            Location = location;

            //TODO works with DavisSpriteFactory but not background sprite factory.
            backgroundImage = DavisSpriteFactory.Instance.MarioHillsGreen();
            //backgroundImage = BackgroundSpriteFactory.Instance.MarioHillsGreen();
        }

        public void Update(GameTime gameTime)
        {
            backgroundImage.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundImage.Draw(spriteBatch, Location);
        }
        public void Reset()
        { }
    }
}
