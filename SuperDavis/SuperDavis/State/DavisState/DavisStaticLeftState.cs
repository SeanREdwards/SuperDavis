﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisStaticLeftState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisStaticLeftState(IDavis davis)
        {
            this.davis = davis;
        }

        public void Static()
        {
            // Do nothing
        }
        public void Left()
        {
            davis.DavisState = new DavisWalkLeftState(davis);
        }

        public void Right()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Up()
        {
            davis.DavisState = new DavisJumpLeftState(davis);
        }

        public void Down()
        {
            davis.DavisState = new DavisCrouchLeftState(davis);
        }

        public void Land()
        {

        }

        public void Death()
        {
            davis.DavisState = new DavisDeathLeftState(davis);
        }

        public void SpecialAttack()
        {
            davis.DavisState = new DavisSpecialAttackLeftState(davis);
        }

        public void Update(GameTime gameTime)
        {
            if (davis.DavisStatus == DavisStatus.Invincible)
            {
                davis.InvincibleTimer--;
                if (davis.InvincibleTimer <= 0)
                {
                    davis.DavisStatus = davis.PrevDavisStatus;
                    davis.DavisState.Static();
                    davis.InvincibleTimer = Variables.Variable.InvincibleTimer;
                }
            }
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
