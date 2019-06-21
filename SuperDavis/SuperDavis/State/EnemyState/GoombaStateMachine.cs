using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;

namespace SuperDavis.State.EnemyState
{
    class GoombaStateMachine: IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set;}
        public ISprite Sprite { get; set; }

        public GoombaStateMachine(Goomba goomba)
        {
            if (!goomba.Dead)
            {
                Sprite = EnemySpriteFactory.Instance.CreateGoombaWalkRight();
            }
            else
            {
                Sprite = EnemySpriteFactory.Instance.CreateGoombaFlatAnimated();
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
