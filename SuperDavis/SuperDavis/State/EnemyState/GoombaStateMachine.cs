using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.EnemyState
{
    class GoombaStateMachine
    {
        private readonly ISprite sprite;

        public GoombaStateMachine()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoombaMovingRight();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
