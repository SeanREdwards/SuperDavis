using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class ProjectileExplodeStateMachine : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }
        private IProjectile projectile;
        private int timer = 12;

        public ProjectileExplodeStateMachine(ISprite sprite, IProjectile projectile)
        {
            this.projectile = projectile;
            Sprite = sprite;
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (timer == 0)
            {
                projectile.IsExploded = true;
            }
            timer--;
        }
    }
}
