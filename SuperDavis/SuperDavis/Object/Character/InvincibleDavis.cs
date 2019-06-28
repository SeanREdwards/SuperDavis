using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperDavis.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.State.DavisState;
using SuperDavis.Interfaces;
using System.Collections.Generic;

namespace SuperDavis.Object.Character
{
    class InvincibleDavis : IDavis
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
        }
        void TakeDamage()
        {
            // StarMario does not take damage
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
               //TODO Remove star
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        public void DavisStatic()
        {
            //do nothing
        }

        // Davis State Change Helper Method
        public void DavisTurnLeft()
        {
            //do nothing
        }
        public void DavisTurnRight()
        {
            //do nothing
        }
        public void DavisJump()
        {
            //do nothing
        }
        public void DavisCrouch()
        {
            //do nothing
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
            //do nothing
        }
        public void DavisSpecialAttack()
        {
            //do nothing
        }

        public void DavisLand()
        {
            //do nothing
        }
        public void DavisToInvincible()
        {
            //do nothing, already invincible.
        }
    }
}
