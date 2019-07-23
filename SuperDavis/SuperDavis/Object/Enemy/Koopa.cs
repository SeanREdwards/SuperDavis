using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
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
        private ISprite sprite;
        private IGameObjectState koopaStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }

        public Koopa(Vector2 location)
        {
            // initial state
            Dead = false;
            FacingDirection = FacingDirection.Left;
            Location = location;
            sprite = EnemySpriteFactory.Instance.CreateKoopaGreenWalkLeft();
            koopaStateMachine = new KoopaStateMachine(sprite);
            PhysicsState = new FallState(this);
            sprite = koopaStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            koopaStateMachine.Update(gameTime);
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
                        Location += new Vector2(-8f, 0);
                    else
                        Location += new Vector2(8f, 0);
            }

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaStateMachine.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            sprite = EnemySpriteFactory.Instance.CreateKoopaGreenShellAnimatedLeft();
            koopaStateMachine = new KoopaStateMachine(sprite);
            if (!Dead)
            {
                Dead = true;
                PhysicsState = new FallState(this);
            }
            else
            {
                PhysicsState = new EnemyDeadState(this);
                koopaStateMachine = new RemoveState(this, koopaStateMachine.Sprite, 200);
            }
        }

        public void ChangeDirection()
        {
            if (!Dead)
            {
                if (FacingDirection == FacingDirection.Left)
                {
                    sprite = EnemySpriteFactory.Instance.CreateKoopaGreenWalkRight();
                    FacingDirection = FacingDirection.Right;
                }
                else
                {
                    sprite = EnemySpriteFactory.Instance.CreateKoopaGreenWalkLeft();
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
            koopaStateMachine = new GoombaStateMachine(sprite);
        }

        public void Jump()
        {
            if (!(PhysicsState is JumpState) || !(PhysicsState is FallState))
                PhysicsState = new JumpState(this);
        }
        
    }
}
