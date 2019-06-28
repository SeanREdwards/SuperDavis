using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;

/*
 * EnemySpriteFactory.cs
 * @Author Sean Edwards
 * Class to create a sprite factory allowing for the streamlining of enemy sprites.
 */
namespace SuperDavis.Factory
{
    class EnemySpriteFactory
    {
        private Dictionary<string, SpriteRegistrar> _spriteRegistrars;

        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        private EnemySpriteFactory() { }

        public void Load(ContentManager content)
        {
            _spriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(File.ReadAllText("Content/SpriteJSONs/Enemies.json"));

            foreach (var spriteRegistrar in _spriteRegistrars)
            {
                spriteRegistrar.Value.Texture = content.Load<Texture2D>(spriteRegistrar.Value.TextureName);
            }

        }

        private string GetMethodName()
        {
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(1);
            return stackFrame.GetMethod().Name;
        }

        private ISprite Create(string key)
        {
            _spriteRegistrars.TryGetValue(key, out SpriteRegistrar spriteInfo);
            return new GenerateSprite(spriteInfo);
        }


        public ISprite CreateGoombaMovingLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateGoombaWalkLeft()
        {
            return Create(GetMethodName());
        }


        public ISprite CreateGoombaWalkRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateGoombaFlatAnimated()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKoopaGreenStaticLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKoopaGreenStaticRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKoopaGreenWalkLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKoopaGreenWalkRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKoopaGreenShellAnimatedLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKoopaGreenShellAnimatedRight()
        {
            return Create(GetMethodName());
        }
    }
}
