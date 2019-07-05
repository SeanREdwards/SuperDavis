using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis
{
    class HUD
    {
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            Console.WriteLine("Here");
            spriteBatch.DrawString(font, "FPS " , new Vector2(20, 20), Color.White);
        }
    }
}
