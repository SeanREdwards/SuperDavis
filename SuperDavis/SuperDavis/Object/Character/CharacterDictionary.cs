using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System.Collections.Generic;
using System;
using SuperDavis.Factory;

namespace SuperDavis.Object.Character
{
    class CharacterDictionary
    {
        private Dictionary<string, Dictionary<string, ISprite>> characterDictionary;

        public CharacterDictionary() {
            characterDictionary = new Dictionary<string, Dictionary<string, ISprite>>() { { "Davis", CreateDavisDictionary() },
            { "Woody", CreateWoodyDictionary()}, {"Bat", CreateBatDictionary() } };
        }

        private Dictionary<string, ISprite> CreateDavisDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>();
            dict.Add("SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateDavisCrouchLeft());
            dict.Add("SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateDavisCrouchRight());
            dict.Add("SuperDavis.State.DavisState.DavisDeathLeftState", DavisSpriteFactory.Instance.CreateDavisDeathLeft());
            dict.Add("SuperDavis.State.DavisState.DavisDeathRightState", DavisSpriteFactory.Instance.CreateDavisDeathRight());
            dict.Add("SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateDavisJumpLeft());
            dict.Add("SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateDavisJumpRight());
            dict.Add("SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneLeft());
            dict.Add("SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneRight());
            dict.Add("SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateDavisStaticLeftSprite());
            dict.Add("SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateDavisStaticRightSprite());
            dict.Add("SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateDavisWalkLeftSprite());
            dict.Add("SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateDavisWalkRightSprite());
            return dict;
        }

        private Dictionary<string, ISprite> CreateWoodyDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>();
            dict.Add("SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateWoodyCrouchLeft());
            dict.Add("SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateWoodyCrouchRight());
            dict.Add("SuperDavis.State.DavisState.DavisDeathLeftState", DavisSpriteFactory.Instance.CreateWoodyDeathLeft());
            dict.Add("SuperDavis.State.DavisState.DavisDeathRightState", DavisSpriteFactory.Instance.CreateWoodyDeathRight());
            dict.Add("SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateWoodyJumpLeft());
            dict.Add("SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateWoodyJumpRight());
            dict.Add("SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneLeft());
            dict.Add("SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneRight());
            dict.Add("SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateWoodyStaticLeftSprite());
            dict.Add("SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateWoodyStaticRightSprite());
            dict.Add("SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateWoodyWalkLeftSprite());
            dict.Add("SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite());
            return dict;
        }

        private Dictionary<string, ISprite> CreateBatDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>();
            dict.Add("SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateBatCrouchLeft());
            dict.Add("SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateBatCrouchRight());
            dict.Add("SuperDavis.State.DavisState.DavisDeathLeftState", DavisSpriteFactory.Instance.CreateBatDeathLeft());
            dict.Add("SuperDavis.State.DavisState.DavisDeathRightState", DavisSpriteFactory.Instance.CreateBatDeathRight());
            dict.Add("SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateBatJumpLeft());
            dict.Add("SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateBatJumpRight());
            dict.Add("SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateBatSpecialAttackOneLeft());
            dict.Add("SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateBatSpecialAttackOneRight());
            dict.Add("SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateBatStaticLeftSprite());
            dict.Add("SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateBatStaticRightSprite());
            dict.Add("SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateBatWalkLeftSprite());
            dict.Add("SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateBatWalkRightSprite());
            return dict;
        }

        public ISprite GetSprite(string charStr, string stateStr)
        {
            characterDictionary.TryGetValue(charStr, out Dictionary<string, ISprite> dict);
            dict.TryGetValue(stateStr,out ISprite sprite);
            return sprite;
        }
    }
}
