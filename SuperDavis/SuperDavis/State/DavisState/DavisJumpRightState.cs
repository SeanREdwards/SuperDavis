using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisJumpRightState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisJumpRightState(IDavis davis)
        {
            this.davis = davis;
            davis.PhysicsState.Velocity = new Vector2(davis.PhysicsState.Velocity.X, -Variables.Variable.YMaxVeloctiy);
            davis.PhysicsState.Acceleration = new Vector2(davis.PhysicsState.Acceleration.X, Variables.Variable.GRAVITY);
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Left()
        {
            davis.DavisState = new DavisJumpLeftState(davis);
        }

        public void Right()
        {
            davis.DavisState = new DavisJumpRightState(davis);
        }

        public void Up() { }

        public void Down()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Land()
        {
            davis.DavisState = new DavisStaticRightState(davis);
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
            davis.Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            davis.Sprite.Draw(spriteBatch, location);
        }
    }
}
