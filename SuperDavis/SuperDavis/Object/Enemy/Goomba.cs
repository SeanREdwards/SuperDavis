using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.EnemyState;

namespace SuperDavis.Object.Enemy
{
    class Goomba : IEnemy
    {
        public Vector2 Location { get; set; }
        private readonly GoombaStateMachine goombaStateMachine;

        public Goomba(Vector2 location)
        {
            // initial state
            Location = location;
            goombaStateMachine = new GoombaStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            goombaStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaStateMachine.Draw(spriteBatch, Location);
        }
    }
}
