using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisDeathRightState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }
        private int timer = 100;

        public DavisDeathRightState(IDavis davis)
        {
            this.davis = davis;
            switch (davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    Sprite = DavisSpriteFactory.Instance.CreateDavisDeathRight();
                    break;
                case DavisStatus.Woody:
                    Sprite = DavisSpriteFactory.Instance.CreateWoodyDeathRight();
                    break;
                case DavisStatus.Bat:
                    Sprite = DavisSpriteFactory.Instance.CreateBatDeathRight();
                    break;
                case DavisStatus.Invincible:
                    Sprite = DavisSpriteFactory.Instance.CreateBatSpecialAttackOneRight();
                    break;
                default:
                    break;
            }
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Static()
        { 
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

        public void Land()
        {

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
