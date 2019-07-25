using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;

namespace SuperDavis.Factory
{
    sealed class ItemSpriteFactory
    {
        private Dictionary<string, SpriteRegistrar> _spriteRegistrars;

        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        private ItemSpriteFactory() { }

        public void Load(ContentManager content)
        {
            _spriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(File.ReadAllText("Content/SpriteJSONs/Items.json"));

            foreach (var spriteRegistrar in _spriteRegistrars)
            {
                spriteRegistrar.Value.Texture = content.Load<Texture2D>(spriteRegistrar.Value.TextureName);
            }
        }

        private static string GetMethodName()
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

        /*Item Sprites*/
        public ISprite CreateStar()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateYoshiEgg()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateYoshiCoinAnimated()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateFireFlower()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateRedMushroom()
        {
            return Create(GetMethodName());
        }

        /*Block Sprites*/
        public ISprite CreateQuestionMarkBlockAnimated()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateActivatedBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateEmptyBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBrickBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateMiddleCastleBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateCastleDoorClosed()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateCastleDoorOpened()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateSkullBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateSpinBlockStatic()
        {
            return Create(GetMethodName());
        }

         public ISprite CreateSpinBlockAnimated()
         {
             return Create(GetMethodName());
         }

        public ISprite CreateLeftGreenFloor()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateLeftCastleFloor()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateMiddleCastleFloor()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateRightCastleFloor()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateRightCastleCeiling()
        {
            return Create(GetMethodName());
        }
        public ISprite CreateLeftCastleCeiling()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateMiddleGrassBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateDirtBlock()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateBeerBottle()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateMilkJug()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateKey()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateMiddleGreenFloor()
        {
            return Create(GetMethodName());
        }

        public ISprite CreateRightGreenFloor()
        {
            return Create(GetMethodName());
        }

        /*Pipes*/
        public ISprite CreateGreenPipe()
        {
            return Create(GetMethodName());
        }

    }
}
