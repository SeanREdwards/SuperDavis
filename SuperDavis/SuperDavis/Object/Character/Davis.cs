using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;
using SuperDavis.Factory;
using System.Collections.Generic;

namespace SuperDavis.Object.Character
{
    class Davis : IDavis
    {
        public bool Remove { get; set; }
        public IDavisState DavisState { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }
        public DavisStatus PrevDavisStatus { get; set; }
        public Rectangle HitBox { get; set; }
        public int InvincibleTimer { get; set; }

        Dictionary<DavisStatus, Dictionary<string, ISprite>> characterDictionary;

        public Davis(Vector2 location)
        {
            // initial state
            InvincibleTimer = 100;
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
            Location = location;
        }

        private void CreateDictionaries()
        {
            characterDictionary = new Dictionary<DavisStatus, Dictionary<string, ISprite>>();
            characterDictionary.Add(DavisStatus.Davis, CreateDavisDictionary());
            characterDictionary.Add(DavisStatus.Woody, CreateWoodyDictionary());
            characterDictionary.Add(DavisStatus.Bat, CreateBatDictionary());
            characterDictionary.Add(DavisStatus.Davis, CreateInvincibleDictionary());
        }

        private static Dictionary<string, ISprite> CreateDavisDictionary()
        {
            Dictionary<string, ISprite> dictionary = new Dictionary<string, ISprite>();
            dictionary.Add("DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateDavisCrouchLeft());
            dictionary.Add("DavisCrouchRightState", DavisSpriteFactory.Instance.CreateDavisCrouchRight());
            dictionary.Add("DavisDeathLeftState", DavisSpriteFactory.Instance.CreateDavisDeathLeft());
            dictionary.Add("DavisDeathRightState", DavisSpriteFactory.Instance.CreateDavisDeathRight());
            dictionary.Add("DavisJumpLeftState", DavisSpriteFactory.Instance.CreateDavisJumpLeft());
            dictionary.Add("DavisJumpRightState", DavisSpriteFactory.Instance.CreateDavisJumpRight());
            dictionary.Add("DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneLeft());
            dictionary.Add("DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneRight());
            dictionary.Add("DavisStaticLeftState", DavisSpriteFactory.Instance.CreateDavisStaticLeftSprite());
            dictionary.Add("DavisStaticRightState", DavisSpriteFactory.Instance.CreateDavisStaticRightSprite());
            dictionary.Add("DavisWalkLeftState", DavisSpriteFactory.Instance.CreateDavisWalkLeftSprite());
            dictionary.Add("DavisWalkRightState", DavisSpriteFactory.Instance.CreateDavisWalkRightSprite());
            return dictionary;
        }

        private static Dictionary<string, ISprite> CreateWoodyDictionary()
        {
            Dictionary<string, ISprite> dictionary = new Dictionary<string, ISprite>();
            dictionary.Add("DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateWoodyCrouchLeft());
            dictionary.Add("DavisCrouchRightState", DavisSpriteFactory.Instance.CreateWoodyCrouchRight());
            dictionary.Add("DavisDeathLeftState", DavisSpriteFactory.Instance.CreateWoodyDeathLeft());
            dictionary.Add("DavisDeathRightState", DavisSpriteFactory.Instance.CreateWoodyDeathRight());
            dictionary.Add("DavisJumpLeftState", DavisSpriteFactory.Instance.CreateWoodyJumpLeft());
            dictionary.Add("DavisJumpRightState", DavisSpriteFactory.Instance.CreateWoodyJumpRight());
            dictionary.Add("DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneLeft());
            dictionary.Add("DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneRight());
            dictionary.Add("DavisStaticLeftState", DavisSpriteFactory.Instance.CreateWoodyStaticLeftSprite());
            dictionary.Add("DavisStaticRightState", DavisSpriteFactory.Instance.CreateWoodyStaticRightSprite());
            dictionary.Add("DavisWalkLeftState", DavisSpriteFactory.Instance.CreateWoodyWalkLeftSprite());
            dictionary.Add("DavisWalkRightState", DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite());
            return dictionary;
        }

        private static Dictionary<string, ISprite> CreateBatDictionary()
        {
            Dictionary<string, ISprite> dictionary = new Dictionary<string, ISprite>();
            dictionary.Add("DavisCrouchLeftState", DavisSpriteFactory.Instance.CreateBatCrouchLeft());
            dictionary.Add("DavisCrouchRightState", DavisSpriteFactory.Instance.CreateBatCrouchRight());
            dictionary.Add("DavisDeathLeftState", DavisSpriteFactory.Instance.CreateBatDeathLeft());
            dictionary.Add("DavisDeathRightState", DavisSpriteFactory.Instance.CreateBatDeathRight());
            dictionary.Add("DavisJumpLeftState", DavisSpriteFactory.Instance.CreateBatJumpLeft());
            dictionary.Add("DavisJumpRightState", DavisSpriteFactory.Instance.CreateBatJumpRight());
            dictionary.Add("DavisSpecialAttackLeftState", DavisSpriteFactory.Instance.CreateBatSpecialAttackOneLeft());
            dictionary.Add("DavisSpecialAttackRightState", DavisSpriteFactory.Instance.CreateBatSpecialAttackOneRight());
            dictionary.Add("DavisStaticLeftState", DavisSpriteFactory.Instance.CreateBatStaticLeftSprite());
            dictionary.Add("DavisStaticRightState", DavisSpriteFactory.Instance.CreateBatStaticRightSprite());
            dictionary.Add("DavisWalkLeftState", DavisSpriteFactory.Instance.CreateBatWalkLeftSprite());
            dictionary.Add("DavisWalkRightState", DavisSpriteFactory.Instance.CreateBatWalkRightSprite());
            return dictionary;
        }

        //TODO
        private static Dictionary<string, ISprite> CreateInvincibleDictionary()
        {
            Dictionary<string, ISprite> dictionary = new Dictionary<string, ISprite>();
            //davisDictionary.Add(DavisCrouchLeftState, DavisSpriteFactory.Instance.CreateDavisCrouchLeft())
            return dictionary;
        }

        public void Update(GameTime gameTime)
        {
            DavisState.Update(gameTime);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, DavisState.Width, DavisState.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisTurnLeft()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState))){
                Location += new Vector2(-2, 0);
            }
            DavisState.Left();
        }

        public void DavisTurnRight()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                Location += new Vector2(2, 0);
            }
            DavisState.Right();
        }

        public void DavisJump()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                Location += new Vector2(0, -2);
            }
            DavisState.Up();
        }

        public void DavisCrouch()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                Location += new Vector2(0, 2);
            }
            DavisState.Down();
        }

        public void DavisToDavis()
        {
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
        }

        public void DavisToWoody()
        {
            DavisStatus = DavisStatus.Woody;
            DavisState = new DavisStaticRightState(this);
        }

        public void DavisToBat()
        {
            DavisStatus = DavisStatus.Bat;
            DavisState = new DavisStaticRightState(this);
        }

        public void DavisDeath()
        {
            DavisState.Death();
        }

        public void DavisSpecialAttack()
        {
            DavisState.SpecialAttack();
        }
        public void DavisToInvincible()
        {
            PrevDavisStatus = DavisStatus;
            DavisStatus = DavisStatus.Invincible;
            DavisState = new DavisStaticRightState(this);
        }

        public void Reset()
        {
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
            Location = new Vector2(Variables.Variable.WindowsEdgeWidth/2 , Variables.Variable.WindowsEdgeHeight/2);
        }
    }
}
