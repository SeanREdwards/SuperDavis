using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;

/*
 * BackgroundFactory.cs
 * @Author Sean Edwards
 * Factory class to create background sprites.
 */
namespace SuperDavis.Factory
{
    class BackgroundFactory

    {
        private List<Rectangle> backgroundList;

        private Texture2D marioBackgroundOne;

        public static BackgroundFactory Instance { get; } = new BackgroundFactory();

        private BackgroundFactory() { }

        public void Load(ContentManager content)
        {
            marioBackgroundOne = content.Load<Texture2D>("BackgroundSprites/BackgroundsMario1");
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, backgroundList);
        }

        /*Basic Davis Sprites*/
        public ISprite MarioHillsGreen()
        {
            backgroundList = new List<Rectangle>() { new Rectangle(1072, 0, 512, 447) };
            return Create(marioBackgroundOne);
        }
    }
}
