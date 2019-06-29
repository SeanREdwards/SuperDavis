using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisDeathLeftState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public ISprite Sprite { get; set; }
        private int timer = 100;
        public DavisDeathLeftState()
        {

        }

        public void Static(){ }

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

        public void Land(){ }

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
