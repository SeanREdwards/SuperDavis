using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisWalkLeftState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisWalkLeftState(IDavis davis)
        {
            this.davis = davis;
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

        public void Land()
        {

        }

        public void Slide()
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
            davis.Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            davis.Sprite.Draw(spriteBatch, location);
        }
    }
}
