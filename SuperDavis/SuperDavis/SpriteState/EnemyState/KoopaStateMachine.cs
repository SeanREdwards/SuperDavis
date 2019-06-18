using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;

namespace SuperDavis.SpriteState.EnemyState
{
    class KoopaStateMachine : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

        public KoopaStateMachine(Koopa koopa)
        {
            if (!koopa.Dead)
            {
                Sprite = EnemySpriteFactory.Instance.CreateKoopaGreenStaticLeft();
            }
            else
            {
                Sprite = EnemySpriteFactory.Instance.CreateKoopaGreenShellAnimatedLeft();
            }
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
