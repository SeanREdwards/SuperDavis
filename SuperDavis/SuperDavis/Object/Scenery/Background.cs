using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.Object.Scenery
{
    class Background : IBackground
    {
        public Vector2 Location { get; set; }
        private readonly ISprite background;

        public Background(Vector2 location)
        {
            // initial state
            Location = location;
            background = BackgroundSpriteFactory.Instance.MarioHillsGreen();
        }

        public void Update(GameTime gameTime)
        {
            background.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, Location);
        }

        public void Reset()
        {
            // Do nothing for current sprint
        }
    }
}
