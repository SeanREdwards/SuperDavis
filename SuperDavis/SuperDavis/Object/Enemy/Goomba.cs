using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.EnemyState;
using SuperDavis.State.OtherState;

namespace SuperDavis.Object.Enemy
{
    class Goomba : IEnemy
    {
        public bool Remove { get; set; }
        public bool Dead { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite enemy;
        private IGameState goombaState;

        public Goomba(Vector2 location)
        {
            // initial state
            Remove = false;
            Dead = false;
            Location = location;
            goombaState = new GoombaStateMachine(this);
            enemy = goombaState.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, enemy.Width, enemy.Height);
        }

        public void Update(GameTime gameTime)
        {
            goombaState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                goombaState.Draw(spriteBatch, Location);
            }
        }

        public void TakeDamage()
        {
            Dead = true;
            goombaState = new GoombaStateMachine(this);
            goombaState = new RemoveState(this, goombaState.Sprite, 100);
        }
        public void Reset() {
            Dead = false;
            goombaState = new GoombaStateMachine(this);
        }
    }
}
