using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisStaticLeftState : IDavisState
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisStaticLeftState(IDavis davis)
        {
            this.davis = davis;
            switch(davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    Sprite = DavisSpriteFactory.Instance.CreateDavisStaticLeftSprite();
                    break;
                case DavisStatus.Woody:
                    Sprite = DavisSpriteFactory.Instance.CreateWoodyStaticLeftSprite();
                    break;
                case DavisStatus.Bat:
                    Sprite = DavisSpriteFactory.Instance.CreateBatStaticLeftSprite();
                    break;
                case DavisStatus.Invincible:
                    Sprite = DavisSpriteFactory.Instance.CreateBatSpecialAttackOneLeft();
                    break;
                default:
                    break;
            }
            Width = Sprite.Width;
            Height = Sprite.Height;
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
            // dumbdumb! a lot of coupling
            if (davis.DavisStatus == DavisStatus.Invincible)
            {
                davis.InvincibleTimer--;
                if (davis.InvincibleTimer <= 0)
                {
                    davis.DavisStatus = davis.PrevDavisStatus;
                    davis.DavisState.Static();
                    davis.InvincibleTimer = 100;
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
