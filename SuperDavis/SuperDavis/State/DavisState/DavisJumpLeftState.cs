using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisJumpLeftState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisJumpLeftState(IDavis davis)
        {
            this.davis = davis;
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
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
            davis.DavisState = new DavisStaticLeftState(davis);
        }

        public void Land()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
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
