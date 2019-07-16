using System;
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
        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                OnPositionChanged?.Invoke(this, Tuple.Create(location, value));
                location = value;
            }
        }

        public FacingDirection FacingDirection { get; set; }
        public bool Dead { get; set; }

        public Rectangle HitBox { get; set; }
        private readonly ISprite enemy;
        private IGameObjectState koopaStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }

        public Koopa(Vector2 location)
        {
            // initial state
            Dead = false;
            FacingDirection = FacingDirection.Left;
            Location = location;
            koopaStateMachine = new KoopaStateMachine(this);
            PhysicsState = new FallState(this);
            enemy = koopaStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)(int)enemy.Width, (int)enemy.Height);
        }

        public void Update(GameTime gameTime)
        {
            koopaStateMachine.Update(gameTime);
            PhysicsState.Update(gameTime);

            if (!Dead)
            {
                if (FacingDirection == FacingDirection.Left)
                    Location += new Vector2(-1f, 0);
                else
                    Location += new Vector2(1f, 0);
            }

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width, (int)enemy.Height);
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
