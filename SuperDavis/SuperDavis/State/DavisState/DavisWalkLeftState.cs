using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisWalkLeftState : IDavisState
    {
        // Needed?
        public int Width { get; set; }
        public int Height { get; set; }

        private IDavis davis;
        private ISprite sprite;

        public DavisWalkLeftState(IDavis davis)
        {
            this.davis = davis;
            switch(davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    sprite = DavisSpriteFactory.Instance.CreateDavisWalkLeftSprite();
                    break;
                case DavisStatus.Woody:
                    sprite = DavisSpriteFactory.Instance.CreateWoodyWalkLeftSprite();
                    break;
                case DavisStatus.Bat:
                    sprite = DavisSpriteFactory.Instance.CreateBatWalkLeftSprite();
                    break;
                case DavisStatus.Invincible:
                    sprite = DavisSpriteFactory.Instance.Invincible();
                    break;
                default:
                    break;
            }
            // Needed?
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
        }
        public void Left() { }

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
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
