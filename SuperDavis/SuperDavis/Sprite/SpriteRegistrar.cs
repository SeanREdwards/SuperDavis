﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperDavis.Sprite
{
    class SpriteRegistrar
    {
        public String TextureName { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceFrames { get; set; }
        public float FrameDelay { get; set; }
        public float Scale { get; set; }
        public string EffectName { get; set; }
        public SpriteEffects Effects { get; set; }
    }
}
