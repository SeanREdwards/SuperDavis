using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.State.EnemyState;
using SuperDavis.State.OtherState;

namespace SuperDavis.Object.Enemy
{
    class Goomba : IEnemy
    {
        public bool FacingLeft { get; set; }
        public bool FacingRight { get; set; }
        public bool Dead { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite enemy;
        private IGameObjectState goombaState;
        public IGameObjectPhysics PhysicsState { get; set; }
        private readonly int groundLevel = 610;

        public Goomba(Vector2 location)
        {
            // initial state
            Dead = false;
            FacingLeft = true;
            Location = location;
            goombaState = new GoombaStateMachine(this);
            PhysicsState = new StandingState(this);
            enemy = goombaState.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width+16, (int)enemy.Height+10);
        }

        public void Update(GameTime gameTime)
        {
            PhysicsState.Update(gameTime);
            goombaState.Update(gameTime);

            if (!Dead)
            {
                if (FacingLeft)
                    Location += new Vector2(-1f, 0);
                else
                    Location += new Vector2(1f, 0);
            }
            else
            {
                Location = new Vector2(Location.X, groundLevel);
            }
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width+16, (int)enemy.Height+10);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaState.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            Dead = true;
            goombaState = new GoombaStateMachine(this);
            goombaState = new RemoveState(this, goombaState.Sprite, 100);
        }
    }
}
