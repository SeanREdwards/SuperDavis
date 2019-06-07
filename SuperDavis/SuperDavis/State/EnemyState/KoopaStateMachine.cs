using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.EnemyState
{
    class KoopaStateMachine : IGameState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ISprite Sprite;

        public KoopaStateMachine()
        {
            Sprite = EnemySpriteFactory.Instance.CreateKoopaGreenShellAnimatedLeft();
            Width = Sprite.Width;
            Height = Sprite.Height;
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

    }
}
