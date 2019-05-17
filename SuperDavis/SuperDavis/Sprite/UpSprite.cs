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
    class UpSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private Texture2D texture;
        private SuperDavis superDavis;

        public UpSprite(Texture2D texture, SuperDavis superDavisClass)
        {
            this.texture = texture;
            this.superDavis = superDavisClass;
            Width = texture.Width;
            Height = texture.Height;
        }

        public void Update(GameTime gameTime)
        {
            superDavis.DavisPos -= new Vector2(0, 2);
            if (superDavis.DavisPos.Y < 0 - superDavis.DavisStatic.Height)
            {
                superDavis.DavisPos = new Vector2(superDavis.DavisPos.X, superDavis.WindowsEdgeHeight + superDavis.DavisStatic.Height);
            }

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,superDavis.DavisPos, Color.White);
        }
    }
}
