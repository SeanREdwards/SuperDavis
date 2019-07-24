using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SuperDavis.Sprite
{
    internal class SpriteRegistrar
    {
        public String TextureName { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceFrames { get; set; }
        public float FrameDelay { get; set; }
        public float Scale { get; set; }
        public string EffectName { get; set; }

        //Standard generic color list is set to White
        public List<Color> ColorList = new List<Color> { Color.White };

        public SpriteEffects Effects { get; set; }
        public SpriteRegistrar() { }
    }
}
