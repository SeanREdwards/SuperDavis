﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;

namespace SuperDavis.Object.Character
{
    class Davis : IDavis
    {
        public bool Remove { get; set; }
        public IDavisState DavisState { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }
        public Rectangle HitBox { get; set; }

        public Davis(Vector2 location)
        {
            // initial state
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
            Location = location;
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
            this.DavisState.Death();
        }

        public void DavisSpecialAttack()
        {
            this.DavisState.SpecialAttack();
        }
        public void DavisToInvincible()
        {
            // TBD
            this.DavisState.SpecialAttack();
        }
    }
}
