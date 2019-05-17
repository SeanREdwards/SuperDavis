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
    class StaticSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private SuperDavis superDavis;
        private Texture2D texture; 

        public StaticSprite(Texture2D texture, SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
            this.texture = texture;
            Width = texture.Width;
            Height = texture.Height;
        }

        public void Update(GameTime gameTime) { }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, superDavis.DavisPos, Color.White);
        }
    }
}
