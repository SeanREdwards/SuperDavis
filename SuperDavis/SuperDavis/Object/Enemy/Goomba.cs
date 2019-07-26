using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.Sound;
using SuperDavis.State.EnemyState;
using SuperDavis.State.OtherState;
using System;

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
        private ISprite sprite;
        private IGameObjectState goombaState;
        public IGameObjectPhysics PhysicsState { get; set; }

        public Goomba(Vector2 location, FacingDirection facingDirection)
        {
            // initial state
            Dead = false;
            FacingDirection = facingDirection;
            Location = location;
            sprite = EnemySpriteFactory.Instance.CreateGoombaWalkRight();
            goombaState = new GoombaStateMachine(sprite);
            PhysicsState = new FallState(this);
            sprite = goombaState.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
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

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaState.Draw(spriteBatch, Location);
        }

        public void Jump()
        {
            if (!(PhysicsState is JumpState) || !(PhysicsState is FallState))
                PhysicsState = new JumpState(this);
        }

        public void TakeDamage()
        {
            if (!Dead)
                Sounds.Instance.PlayPhysicsCollision();
            Dead = true;
            PhysicsState = new EnemyDeadState(this);
            sprite = EnemySpriteFactory.Instance.CreateGoombaFlatAnimated();
            goombaState = new GoombaStateMachine(sprite);
            goombaState = new RemoveState(this, goombaState.Sprite, Variables.Variable.EnemyRemoveInt);
        }

        public void ChangeDirection()
        {
            if (FacingDirection == FacingDirection.Left)
            {
                sprite = EnemySpriteFactory.Instance.CreateGoombaWalkRight();
                FacingDirection = FacingDirection.Right;
            }
            else
            {
                sprite = EnemySpriteFactory.Instance.CreateGoombaWalkLeft();
                FacingDirection = FacingDirection.Left;
            }
            goombaState = new GoombaStateMachine(sprite);
        }
    }
}
