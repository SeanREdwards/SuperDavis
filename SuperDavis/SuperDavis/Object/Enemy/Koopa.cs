using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.EnemyState;

namespace SuperDavis.Object.Enemy
{
    class Koopa : IEnemy
    {
        public bool Remove { get; set; }
        public bool Dead { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private ISprite enemy;

        private KoopaStateMachine koopaStateMachine;

        public Koopa(Vector2 location)
        {
            // initial state
            Remove = false;
            Dead = false;
            Location = location;
            koopaStateMachine = new KoopaStateMachine(this);
            enemy = koopaStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, enemy.Width, enemy.Height);

        }

        public void Update(GameTime gameTime)
        {
            koopaStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaStateMachine.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            Dead = true;
            koopaStateMachine = new KoopaStateMachine(this);
        }
        public void Reset() {
            Dead = false;
            koopaStateMachine = new KoopaStateMachine(this);
        }
    }
}
