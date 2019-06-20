﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Diagnostics; //used for getting names of methods

/*
 * BackgroundSpriteFactory.cs
 * @Author Sean Edwards
 * Factory class to create background sprites.
 */
namespace SuperDavis.Factory
{
    class BackgroundSpriteFactory
    {
        public static BackgroundSpriteFactory Instance { get; } = new BackgroundSpriteFactory();
        private BackgroundSpriteFactory() { }
        private Dictionary<string, SpriteRegistrar> _spriteRegistrars;
        public void Load(ContentManager content)
        {
            _spriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(File.ReadAllText("Content/SpriteJSONs/Backgrounds.json"));

            foreach (var spriteRegistrar in _spriteRegistrars)
            {
                spriteRegistrar.Value.Texture = content.Load<Texture2D>(spriteRegistrar.Value.TextureName);
            }
        }

        private ISprite Create(string key)
        {
            _spriteRegistrars.TryGetValue(key, out SpriteRegistrar spriteInfo);
            return new GenerateBackground(spriteInfo.Texture, spriteInfo.SourceFrames);
        }

        private string GetMethodName()
        {
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(1);

            return stackFrame.GetMethod().Name;
        }

        public ISprite MarioHillsGreen()
        {
            return Create(GetMethodName());
        }
    }
}
