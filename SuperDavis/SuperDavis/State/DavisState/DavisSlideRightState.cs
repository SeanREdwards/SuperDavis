using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.State.DavisState
{
    class DavisSlideRightState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisSlideRightState(IDavis davis)
        {
            this.davis = davis;
            davis.PhysicsState.Acceleration = new Vector2(0, davis.PhysicsState.Acceleration.Y);
            davis.PhysicsState.ApplyForce(new Vector2(-Variables.Variable.FRICTION, davis.PhysicsState.Acceleration.Y));
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Left()
        {
            davis.DavisState = new DavisSlideLeftState(davis);
        }

        public void Right()
        {
            davis.DavisState = new DavisWalkRightState(davis);
        }

        public void Up()
        {
            davis.PhysicsState.Acceleration = new Vector2(0, davis.PhysicsState.Acceleration.Y);
            davis.DavisState = new DavisJumpRightState(davis);
        }

        public void Down()
        {
            davis.DavisState = new DavisCrouchRightState(davis);
        }

        public void Land()
        {

        }

        public void Slide()
        {

        }

        public void Death()
        {
            davis.DavisState = new DavisDeathRightState(davis);
        }

        public void SpecialAttack()
        {
            davis.DavisState = new DavisSpecialAttackRightState(davis);
        }

        public void Update(GameTime gameTime)
        {
            if(davis.DavisStatus == DavisStatus.Invincible)
            {
                davis.InvincibleTimer--;
                if(davis.InvincibleTimer <=0)
                {
                    davis.DavisStatus = davis.PrevDavisStatus;
                    davis.DavisState.Static();
                    davis.InvincibleTimer = Variables.Variable.InvincibleTimer;
                }
            }
            davis.Sprite.Update(gameTime);
            if (Math.Abs(davis.PhysicsState.Velocity.X) < 1)
                Static();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            davis.Sprite.Draw(spriteBatch, location);
        }
    }
}
