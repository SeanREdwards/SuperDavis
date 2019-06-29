/*
 * CharacterDictionary.cs
 * @Author Sean Edwards
 * A one-stop-shop location to access character sprites in a flyweight pattern so that player sprites are only generated a single time and merely ascessed rather than
 * created on every single sprite call. 
 * 
 * TODO Data drive the dictionary strings/sprite call tuples via JSON.
 * 
 */
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
        private readonly Dictionary<string, Dictionary<string, ISprite>> characterDictionary;

        public CharacterDictionary() {
            characterDictionary = new Dictionary<string, Dictionary<string, ISprite>>() { { "Davis", CreateDavisDictionary() },
            { "Woody", CreateWoodyDictionary()}, {"Bat", CreateBatDictionary() }, {"Invincible", CreateInvincibleDavisDictionary() } };
        }

        private static Dictionary<string, ISprite> CreateDavisDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>
            {
                { "SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateDavisCrouchLeft() },
                { "SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateDavisCrouchRight() },
                { "SuperDavis.State.DavisState.DavisDeathLeftState", DavisSpriteFactory.Instance.CreateDavisDeathLeft() },
                { "SuperDavis.State.DavisState.DavisDeathRightState", DavisSpriteFactory.Instance.CreateDavisDeathRight() },
                { "SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateDavisJumpLeft() },
                { "SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateDavisJumpRight() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneLeft() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneRight() },
                { "SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateDavisStaticLeftSprite() },
                { "SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateDavisStaticRightSprite() },
                { "SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateDavisWalkLeftSprite() },
                { "SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateDavisWalkRightSprite() }
            };
            return dict;
        }

        private static Dictionary<string, ISprite> CreateWoodyDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>
            {
                { "SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateWoodyCrouchLeft() },
                { "SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateWoodyCrouchRight() },
                { "SuperDavis.State.DavisState.DavisDeathLeftState", DavisSpriteFactory.Instance.CreateWoodyDeathLeft() },
                { "SuperDavis.State.DavisState.DavisDeathRightState", DavisSpriteFactory.Instance.CreateWoodyDeathRight() },
                { "SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateWoodyJumpLeft() },
                { "SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateWoodyJumpRight() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneLeft() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneRight() },
                { "SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateWoodyStaticLeftSprite() },
                { "SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateWoodyStaticRightSprite() },
                { "SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateWoodyWalkLeftSprite() },
                { "SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite() }
            };
            return dict;
        }

        private static Dictionary<string, ISprite> CreateBatDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>
            {
                { "SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateBatCrouchLeft() },
                { "SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateBatCrouchRight() },
                { "SuperDavis.State.DavisState.DavisDeathLeftState", DavisSpriteFactory.Instance.CreateBatDeathLeft() },
                { "SuperDavis.State.DavisState.DavisDeathRightState", DavisSpriteFactory.Instance.CreateBatDeathRight() },
                { "SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateBatJumpLeft() },
                { "SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateBatJumpRight() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateBatSpecialAttackOneLeft() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateBatSpecialAttackOneRight() },
                { "SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateBatStaticLeftSprite() },
                { "SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateBatStaticRightSprite() },
                { "SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateBatWalkLeftSprite() },
                { "SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateBatWalkRightSprite() }
            };
            return dict;
        }

        private static Dictionary<string, ISprite> CreateInvincibleDavisDictionary()
        {
            Dictionary<string, ISprite> dict = new Dictionary<string, ISprite>
            {
                { "SuperDavis.State.DavisState.DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateInvincibleDavisCrouchLeft() },
                { "SuperDavis.State.DavisState.DavisCrouchRightState", DavisSpriteFactory.Instance.CreateInvincibleDavisCrouchRight() },
                { "SuperDavis.State.DavisState.DavisJumpLeftState", DavisSpriteFactory.Instance.CreateInvincibleDavisJumpLeft() },
                { "SuperDavis.State.DavisState.DavisJumpRightState", DavisSpriteFactory.Instance.CreateInvincibleDavisJumpRight() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateInvincibleDavisSpecialAttackOneLeft() },
                { "SuperDavis.State.DavisState.DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateInvincibleDavisSpecialAttackOneRight() },
                { "SuperDavis.State.DavisState.DavisStaticLeftState", DavisSpriteFactory.Instance.CreateInvincibleDavisStaticLeftSprite() },
                { "SuperDavis.State.DavisState.DavisStaticRightState", DavisSpriteFactory.Instance.CreateInvincibleDavisStaticRightSprite() },
                { "SuperDavis.State.DavisState.DavisWalkLeftState", DavisSpriteFactory.Instance.CreateInvincibleDavisWalkLeftSprite() },
                { "SuperDavis.State.DavisState.DavisWalkRightState", DavisSpriteFactory.Instance.CreateInvincibleDavisWalkRightSprite() }
            };
            return dict;
        }

        public ISprite GetSprite(string charStr, string stateStr)
        {
            characterDictionary.TryGetValue(charStr, out Dictionary<string, ISprite> dict);
            Console.Out.WriteLine(charStr + "          " + stateStr);
            dict.TryGetValue(stateStr,out ISprite sprite);
            return sprite;
        }
    }
}
