using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.Object.Scenery
{
    class GhostHouseAnimated : IBackground
    {
        public Vector2 Location { get; set; }
        private readonly ISprite ghostHouseAnimated;


        public GhostHouseAnimated(Vector2 location)
        {
            // initial state
            Location = location;
            ghostHouseAnimated = BackgroundSpriteFactory.Instance.GhostHouseAnimated();
        }

        public void Update(GameTime gameTime)
        {
            ghostHouseAnimated.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ghostHouseAnimated.Draw(spriteBatch, Location);
        }
    }
}
