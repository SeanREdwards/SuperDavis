using System;
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
        private IGameObjectState goombaState;
        public IGameObjectPhysics PhysicsState { get; set; }

        public Goomba(Vector2 location)
        {
            // initial state
            Dead = false;
            FacingDirection = FacingDirection.Left;
            Location = location;
            goombaState = new GoombaStateMachine(this);
            PhysicsState = new FallState(this);
            enemy = goombaState.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width, (int)enemy.Height);
        }

        public void Update(GameTime gameTime)
        {
            PhysicsState.Update(gameTime);
            goombaState.Update(gameTime);

            if (!Dead)
            {
                if (FacingDirection == FacingDirection.Left)
                    Location += new Vector2(Variables.Variable.EnemyVectorUpdateLeft, 0);
                else
                    Location += new Vector2(Variables.Variable.EnemyVectorUpdateRight, 0);
            }

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width, (int)enemy.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaState.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            Dead = true;
            goombaState = new GoombaStateMachine(this);
            goombaState = new RemoveState(this, goombaState.Sprite, Variables.Variable.EnemyRemoveInt);
        }
    }
}
