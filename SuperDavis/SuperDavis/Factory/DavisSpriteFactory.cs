using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;

/*
 * DavisSpriteFactory.cs
 * @Author Sean Edwards & Jason Xu
 * Factory class to create character sprites.
 */
namespace SuperDavis.Factory
{
    /* Character Sprites credited for http://www.lf2.net/ */
    class DavisSpriteFactory
    {

        public static DavisSpriteFactory Instance { get; } = new DavisSpriteFactory();

        private DavisSpriteFactory() { }

        /*Sprite Registrar to parse JSONs*/
        private Dictionary<string, SpriteRegistrar> _spriteRegistrars;

        public void Load(ContentManager content)
        {
            _spriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(File.ReadAllText("Content/SpriteJSONs/PlayerCharacter.json"));

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
            return new GenerateSprite(spriteInfo.Texture,  new List<Color> { Color.White}, 1f, SpriteEffects.None, spriteInfo.SourceFrames);
        }

        public ISprite CreateDavisStaticLeftSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisStaticRightSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisWalkLeftSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisWalkRightSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisCrouchLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisCrouchRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisJumpLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisJumpRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisDeathLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisDeathRight()
        {
            return Create(GetMethodName());
        }

        /*Advanced Davis Sprites*/
        public ISprite CreateDavisSpecialAttackOneLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDavisSpecialAttackOneRight()
        {
            return Create(GetMethodName());
        }

        /*Basic Woody Sprites*/
        public ISprite CreateWoodyStaticLeftSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyStaticRightSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyWalkLeftSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyWalkRightSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyCrouchLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyCrouchRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyJumpLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyJumpRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyDeathLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodyDeathRight()
        {
            return Create(GetMethodName());
        }

        /*Advanced Woody Sprites*/
        public ISprite CreateWoodySpecialAttackOneLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateWoodySpecialAttackOneRight()
        {
            return Create(GetMethodName());
        }

        /*Basic Bat Sprites*/
        public ISprite CreateBatStaticLeftSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatStaticRightSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatWalkLeftSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatWalkRightSprite()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatCrouchLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatCrouchRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatJumpLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatJumpRight()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatDeathLeft()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBatDeathRight()
        {
            return Create(GetMethodName());
        }

        /*Advanced Bat Sprites*/
        public ISprite CreateBatSpecialAttackOneLeft()
        {
            _spriteRegistrars.TryGetValue(GetMethodName(), out SpriteRegistrar spriteInfo);
            return new GenerateSprite(spriteInfo.Texture, new List<Color> { Color.White, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple, Color.Black }, 1f, SpriteEffects.None, spriteInfo.SourceFrames);
        }

        public ISprite CreateBatSpecialAttackOneRight()
        {
            _spriteRegistrars.TryGetValue(GetMethodName(), out SpriteRegistrar spriteInfo);
            return new GenerateSprite(spriteInfo.Texture, new List<Color> { Color.White, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple, Color.Black }, 1f, SpriteEffects.None, spriteInfo.SourceFrames);
        }

        public ISprite BatExplodeRight()
        {
            return Create(GetMethodName());
        }

        public ISprite BatExplodeLeft()
        {
            return Create(GetMethodName());
        }
    }
}
