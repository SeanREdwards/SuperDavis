using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.OtherState
{
    class DavisRemoveState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }
        private readonly IGameObject gameObject;
        private readonly ISprite sprite;
        private int timer;

        public DavisRemoveState(IGameObject gameObject, ISprite sprite, int timer)
        {
            this.gameObject = gameObject;
            this.sprite = sprite;
            this.timer = timer;
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (timer >= 0)
            {
                sprite.Draw(spriteBatch, location);
            }
        }

        public void Static()
        {

        }

        public void Left()
        {

        }

        public void Right()
        {

        }

        public void Up()
        {

        }

        public void Down()
        {

        }

        public void Land()
        {

        }


        public void Death()
        {

        }

        public void SpecialAttack()
        {

        }

        public void ShootBullet()
        { }
    }
}
