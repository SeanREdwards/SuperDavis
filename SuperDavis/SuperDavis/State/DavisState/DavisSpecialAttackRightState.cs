using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisSpecialAttackRightState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisSpecialAttackRightState(IDavis davis)
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

        public void Right()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Up() { }

        public void Down()
        {
            davis.DavisState = new DavisStaticRightState(davis);
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
            //Do Nothing.
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
