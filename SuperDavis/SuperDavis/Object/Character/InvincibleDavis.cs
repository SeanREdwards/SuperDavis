using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperDavis.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.State.DavisState;

namespace SuperDavis.Object.Character
{
    class InvincibleDavis : IDavis
    {
        IDavis decoratedDavis;
        int timer = 500;

        public bool Remove { get; set; }
        public IDavisState DavisState { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }
        public Rectangle HitBox { get; set; }

        public InvincibleDavis(IDavis decoratedDavis)
        {
            // initial state
            DavisStatus = DavisStatus.Bat;
            this.decoratedDavis = decoratedDavis;

        }

        void TakeDamage()
        {
            // StarMario does not take damage
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar();
            }

            decoratedDavis.Update(gameTime);
        }

        void RemoveStar()
        {
            //TODO
            //Game1.World.Davises[0] = decoratedDavis;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisTurnLeft()
        {
            this.Location += new Vector2(-2, 0);
            this.DavisState.SpecialAttack();
        }

        public void DavisTurnRight()
        {
            this.Location += new Vector2(2, 0);
            this.DavisState.SpecialAttack();
        }

        public void DavisJump()
        {
            this.Location += new Vector2(0, -2);
        }

        public void DavisCrouch()
        {
            this.Location += new Vector2(0, 2);
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
        public void DavisToInvincible()
        {
            //do nothing, already invincible.
        }
    }
}
