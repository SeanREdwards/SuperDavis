using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;

namespace SuperDavis.State.EnemyState
{
    class GoombaStateMachine: IGameState
    {
        public int Width { get; set; }
        public int Height { get; set;}
        public ISprite Sprite;

        public GoombaStateMachine(Goomba goomba)
        {
            if (!goomba.Dead)
            {
                Sprite = EnemySpriteFactory.Instance.CreateGoombaMovingRight();
            }
            else
            {
                Sprite = EnemySpriteFactory.Instance.CreateGoombaFlateStatic();
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
