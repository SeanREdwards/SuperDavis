using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Factory;
using System.Collections.Generic;

namespace SuperDavis.Object.Background
{
    class Background
    {
        public Vector2 Location { get; set; }
        private ISprite backgroundImg;

        public Background(/*Vector2 location*/)
        {
            //initial state
            //Location = location;

            //TODO Generalize background.
            backgroundImg = BackgroundFactory.Instance.MarioHillsGreen();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            backgroundImg.Draw(spriteBatch, location);
        }
    }
}
