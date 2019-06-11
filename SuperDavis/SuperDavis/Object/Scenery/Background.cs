/*BackgroundSpriteFactory.cs
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.Object.Scenery
{
    class Background : IBackground
    {
        public Vector2 Location { get; set; }
        private ISprite backgroundImage;
        private ISprite test;

        public Background(Vector2 location)
        {
            // initial state
            Location = location;
            backgroundImage = DavisSpriteFactory.Instance.MarioHillsGreen();
        }

        public void Update(GameTime gameTime)
        {
            backgroundImage.Update(gameTime);
            test.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundImage.Draw(spriteBatch, Location);
        }
        public void Reset()
        { }
    }
}
