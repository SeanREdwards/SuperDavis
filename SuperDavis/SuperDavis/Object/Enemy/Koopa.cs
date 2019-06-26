using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.State.EnemyState;
using SuperDavis.State.OtherState;

namespace SuperDavis.Object.Enemy
{
    class Koopa : IEnemy
    {
        public bool FacingLeft { get; set; }
        public bool Dead { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite enemy;
        private IGameObjectState koopaStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }

        public Koopa(Vector2 location)
        {
            // initial state

            Dead = false;
            FacingLeft = true;
            Location = location;
            koopaStateMachine = new KoopaStateMachine(this);
            PhysicsState = new StandingState(this);
            enemy = koopaStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)(int)enemy.Width, (int)enemy.Height+15);
        }

        public void Update(GameTime gameTime)
        {

            koopaStateMachine.Update(gameTime);
            PhysicsState.Update(gameTime);

            if (!Dead)
            {
                if (FacingLeft)
                    Location += new Vector2(-1f, 0);
                else
                    Location += new Vector2(1f, 0);
            }
            else
            {
                Location = new Vector2(Location.X, 600);
            }
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width, (int)enemy.Height+15);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

                koopaStateMachine.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            Dead = true;
            koopaStateMachine = new KoopaStateMachine(this);
            koopaStateMachine = new RemoveState(this, koopaStateMachine.Sprite, 100);
        }
    }
}
