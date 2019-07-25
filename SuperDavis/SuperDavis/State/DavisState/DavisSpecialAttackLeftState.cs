using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisSpecialAttackLeftState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }
        private int specialAttackTimer = 25;

        public DavisSpecialAttackLeftState(IDavis davis)
        {
            this.davis = davis;
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }
        public void Left()
        {

        }

        public void Right()
        {

        }

        public void Up() { }

        public void Down()
        {

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

        }

        public void Update(GameTime gameTime)
        {
            davis.Sprite.Update(gameTime);
            if (specialAttackTimer == 0)
                davis.DavisState = new DavisStaticLeftState(davis);
            specialAttackTimer--;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            davis.Sprite.Draw(spriteBatch, location);
        }
    }
}
