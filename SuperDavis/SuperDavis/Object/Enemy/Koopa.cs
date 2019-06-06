using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.EnemyState;

namespace SuperDavis.Object.Enemy
{
    class Koopa : IEnemy
    {
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private readonly KoopaStateMachine koopaStateMachine;

        public Koopa(Vector2 location)
        {
            // initial state
            Location = location;
            koopaStateMachine = new KoopaStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            koopaStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaStateMachine.Draw(spriteBatch, Location);
        }
    }
}
