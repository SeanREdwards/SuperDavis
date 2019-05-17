using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavisDemo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavisDemo.Sprite
{
    /* Reference: http://rbwhitaker.wikidot.com/monogame-texture-atlases-3 */
    class AnimateSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private SuperDavis superDavis;
        private Texture2D texture;
        private int currentFrame;
        private readonly int totalFrames;
        private double currentTime;
        private const double frameTime = 0.08d;

        public AnimateSprite(Texture2D texture, int totalFrames, SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
            this.texture = texture;
            this.totalFrames = totalFrames;
            currentFrame = 0;
            Width = texture.Width / totalFrames;
            Height = texture.Height;
        }

        public void Update(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime > frameTime)
            {
                currentFrame++;
                currentTime = 0d;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = new Rectangle(Width * currentFrame, 0, Width, Height);
            Rectangle destination = new Rectangle((int)superDavis.DavisPos.X, (int)superDavis.DavisPos.Y, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
    }
}
