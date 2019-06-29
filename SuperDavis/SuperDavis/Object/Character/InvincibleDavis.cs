using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;
using System.Collections.Generic;
using SuperDavis.Physics;
using SuperDavis.Object.Item;

namespace SuperDavis.Object.Character
{
    /*class InvincibleDavis : IDavis
    {
        IDavis decoratedDavis;
        public int InvincibleTimer { get; set; }
        private readonly CharacterDictionary charDict;
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public IDavisState DavisState { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        public IList<IProjectile> DavisProjectile { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }
        public DavisStatus PrevDavisStatus { get; set; }
        public Rectangle HitBox { get; set; }
        public ISprite Sprite { get; set; }

        public InvincibleDavis(IDavis decoratedDavis)
        {
            this.decoratedDavis = decoratedDavis;
            this.DavisStatus = DavisStatus.Invincible;
            charDict = new CharacterDictionary();
        }

        public void Update(GameTime gameTime)
        {
            InvincibleTimer--;
            if (InvincibleTimer == 0)
            {
                RemoveStar();
            }
            decoratedDavis.Update(gameTime);
        }
        void RemoveStar()
        {
               //TODO reassign the davis to original.
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        public void DavisStatic()
        {
            DavisState.Static();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        // Davis State Change Helper Method
        public void DavisTurnLeft()
        {
            Location += new Vector2(-3, 0);
            FacingLeft = true;
            DavisState.Left();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }
        public void DavisTurnRight()
        {
            Location += new Vector2(3, 0);
            FacingLeft = false;
            DavisState.Right();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }
        public void DavisJump()
        {
            if (!(PhysicsState is JumpState) && !(PhysicsState is FallState))
                PhysicsState = new JumpState(this);
            DavisState.Up();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }
        public void DavisCrouch()
        {
            DavisState.Down();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        public void DavisLand()
        {
            DavisState.Land();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        void TakeDamage()
        {
            // StarMario does not take damage
        }

        public void DavisToDavis()
        {
            //Do nothing
        }
        public void DavisToWoody()
        {
            //Do nothing
        }
        public void DavisToBat()
        {
            //do nothing
        }
        public void DavisDeath()
        {
            //do nothing, Davis cant die.
        }
        public void DavisSpecialAttack()
        {
            DavisState.SpecialAttack();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        public void DavisToInvincible()
        {
            //do nothing, already invincible.
        }
    }
    */
}
