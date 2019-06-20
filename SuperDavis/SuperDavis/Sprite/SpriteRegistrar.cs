using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Sprite
{
    class SpriteRegistrar
    {
        public String TextureName { get; set; }
        public Texture2D Texture { get; set; }
        public List<Rectangle> SourceFrames { get; set; }
        public float FrameDelay { get; set; }
        public float Scale { get; set; }
    }
}
