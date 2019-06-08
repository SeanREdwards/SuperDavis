using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.EnemyState;

namespace SuperDavis.Object.Enemy
{
    class Goomba : IEnemy
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private ISprite enemy;
        private readonly GoombaStateMachine goombaStateMachine;

        public Goomba(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            goombaStateMachine = new GoombaStateMachine();
            enemy = goombaStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, enemy.Width, enemy.Height);
        }

        public void Update(GameTime gameTime)
        {
            goombaStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                goombaStateMachine.Draw(spriteBatch, Location);
            }
        }

        public void TakeDamage()
        {

        }
    }
}
