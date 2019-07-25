using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.State.EnemyState;
using SuperDavis.State.OtherState;
using System;

namespace SuperDavis.Object.Enemy
{
    class Julian : IEnemy
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
        private IGameObjectState JulianStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }

        public Julian(Vector2 location)
        {
            // initial state
            Dead = false;
            FacingDirection = FacingDirection.Left;
            Location = location;
            sprite = EnemySpriteFactory.Instance.CreateJulianLeftStatic();
            JulianStateMachine = new KoopaStateMachine(sprite);
            PhysicsState = new FallState(this);
            sprite = JulianStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            JulianStateMachine.Update(gameTime);
            PhysicsState.Update(gameTime);

            if (!(PhysicsState is EnemyDeadState))
            {
                if (!Dead)
                    if (FacingDirection == FacingDirection.Left)
                        Location += new Vector2(-1f, 0);
                    else
                        Location += new Vector2(1f, 0);
                else
                    if (FacingDirection == FacingDirection.Left)
                    Location += new Vector2(-6f, 0);
                else
                    Location += new Vector2(6f, 0);
            }

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            JulianStateMachine.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            sprite = EnemySpriteFactory.Instance.CreateJulianPowerPunchsOneLeft();
            JulianStateMachine = new KoopaStateMachine(sprite);
            if (!Dead)
            {
                Dead = true;
                PhysicsState = new FallState(this);
            }
            else
            {
                PhysicsState = new EnemyDeadState(this);
                JulianStateMachine = new RemoveState(this, JulianStateMachine.Sprite, 200);
            }
        }

        public void ChangeDirection()
        {
            if (!Dead)
            {
                if (FacingDirection == FacingDirection.Left)
                {
                    sprite = EnemySpriteFactory.Instance.CreateJulianWalkRight();
                    FacingDirection = FacingDirection.Right;
                }
                else
                {
                    sprite = EnemySpriteFactory.Instance.CreateJulianWalkLeft();
                    FacingDirection = FacingDirection.Left;
                }
            }
            else
            {
                if (FacingDirection == FacingDirection.Left)
                {
                    sprite = EnemySpriteFactory.Instance.CreateKoopaGreenShellAnimatedRight();
                    FacingDirection = FacingDirection.Right;
                }
                else
                {
                    sprite = EnemySpriteFactory.Instance.CreateKoopaGreenShellAnimatedLeft();
                    FacingDirection = FacingDirection.Left;
                }
            }
            JulianStateMachine = new GoombaStateMachine(sprite);
        }

        public void Jump()
        {
            if (!(PhysicsState is JumpState) || !(PhysicsState is FallState))
                PhysicsState = new JumpState(this);
        }

    }
}
