using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisWalkRightState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisWalkRightState(IDavis davis)
        {
            this.davis = davis;
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Left()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
        }

        public void Right() { }

        public void Up()
        {
            davis.DavisState = new DavisJumpRightState(davis);
        }

        public void Down()
        {
            davis.DavisState = new DavisCrouchRightState(davis);
        }

        public void Land()
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

        public void ShootBullet()
        {

        }

        public void Update(GameTime gameTime)
        {
            davis.Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            davis.Sprite.Draw(spriteBatch, location);
        }
    }
}
