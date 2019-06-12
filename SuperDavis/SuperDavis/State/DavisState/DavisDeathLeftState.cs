using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisDeathLeftState : IDavisState
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly IDavis davis;
        public ISprite Sprite { get; set; }
        private int timer = 100;
        public DavisDeathLeftState(IDavis davis)
        {
            this.davis = davis;
            switch (davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    Sprite = DavisSpriteFactory.Instance.CreateDavisDeathLeft();
                    break;
                case DavisStatus.Woody:
                    Sprite = DavisSpriteFactory.Instance.CreateWoodyDeathLeft();
                    break;
                case DavisStatus.Bat:
                    Sprite = DavisSpriteFactory.Instance.CreateBatDeathLeft();
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
            timer--;
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (timer >= 0)
            {
                Sprite.Draw(spriteBatch, location);
            }
        }
    }
}
