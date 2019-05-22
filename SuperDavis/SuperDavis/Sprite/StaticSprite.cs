using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Sprite
{

    class StaticSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly Texture2D texture;

        public StaticSprite(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Width;
            Height = texture.Height;
        }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }

    }
}
