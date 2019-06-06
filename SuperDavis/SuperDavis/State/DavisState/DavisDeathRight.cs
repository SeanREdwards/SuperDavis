using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisDeathRightState : IDavisState
    {
        // Needed?
        public int Width { get; set; }
        public int Height { get; set; }

        private IDavis davis;
        private ISprite sprite;

        public DavisDeathRightState(IDavis davis)
        {
            this.davis = davis;
            switch (davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    sprite = DavisSpriteFactory.Instance.CreateDavisDeathRight();
                    break;
                case DavisStatus.Woody:
                    sprite = DavisSpriteFactory.Instance.CreateWoodyDeathRight();
                    break;
                case DavisStatus.Bat:
                    sprite = DavisSpriteFactory.Instance.CreateBatDeathRight();
                    break;
                case DavisStatus.Invincible:
                    // TBD;
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
        public void Left()
        {
            //Do Nothing.
        }

        public void Right()
        {
            //Do Nothing.
        }

        public void Up()
        {
            //Do Nothing.
        }

        public void Down()
        {
            //Do Nothing
        }

        public void Death()
        {
            //Do Nothing
        }

        public void SpecialAttack()
        {
            //Do Nothing.
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
