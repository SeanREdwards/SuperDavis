using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using SuperDavis.Sound;
using SuperDavis.State.EnemyState;
using SuperDavis.State.OtherState;
using System;
using System.Collections.Generic;

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
        public IList<IProjectile> JulianProjectile { get; set; }
        public IGameObjectState JulianStateMachine { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public int HealthCounter { get; set; }
        public Rectangle HitBox { get; set; }
        public ISprite Sprite { get; set; }
        public IWorld World;


        public Julian(Vector2 location, IWorld world)
        {
            this.World = world;
            // initial state
            HealthCounter = 20;
            Dead = false;
            FacingDirection = FacingDirection.Left;
            Location = location;
            Sprite = EnemySpriteFactory.Instance.CreateJulianLeftStatic();
            JulianStateMachine = new JulianStateMachine(Sprite);
            PhysicsState = new FallState(this);
            JulianProjectile = new List<IProjectile>()
            {
                (new JulianProjectile(location,FacingDirection))
            };
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)Sprite.Width, (int)Sprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            Walk();
            JulianStateMachine.Update(gameTime);
            PhysicsState.Update(gameTime);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)Sprite.Width, (int)Sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            JulianStateMachine.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            if (HealthCounter > 0)
            {
                HealthCounter--;
                PhysicsState = new JulianKnockBackState(this);
            }
            else
            {
                if (FacingDirection == FacingDirection.Left)
                    Sprite = EnemySpriteFactory.Instance.CreateJulianDeadLeft();
                else
                    Sprite = EnemySpriteFactory.Instance.CreateJulianDeadRight();
                JulianStateMachine = new JulianStateMachine(Sprite);
                PhysicsState = new EnemyDeadState(this);
                JulianStateMachine = new RemoveState(this, JulianStateMachine.Sprite, 200);
            }
        }

        public void Walk()
        {
            if (!(PhysicsState is EnemyDeadState) && !(PhysicsState is JulianKnockBackState) && !(JulianStateMachine is JulianPowerPunchState) && !(JulianStateMachine is JulianMetaAttackState))
            {
                if (!Dead)
                {
                    if (FacingDirection == FacingDirection.Left)
                    {
                        Location += new Vector2(-1f, 0);
                    }
                    else
                    {
                        Location += new Vector2(1f, 0);
                    }
                }


            }
        }

        public void ChangeDirection()
        {
            if (!Dead)
            {
                if (FacingDirection == FacingDirection.Left)
                {
                    Sprite = EnemySpriteFactory.Instance.CreateJulianWalkRight();
                    FacingDirection = FacingDirection.Right;
                }
                else
                {
                    Sprite = EnemySpriteFactory.Instance.CreateJulianWalkLeft();
                    FacingDirection = FacingDirection.Left;
                }
            }
            JulianStateMachine = new JulianStateMachine(Sprite);
        }

        public void PowerPunch()
        {
            if (!Dead && !(JulianStateMachine is JulianPowerPunchState))
            {
                if (FacingDirection == FacingDirection.Left)
                    Sprite = EnemySpriteFactory.Instance.CreateJulianPowerPunchsOneLeft();
                else
                    Sprite = EnemySpriteFactory.Instance.CreateJulianPowerPunchsOneRight();

                JulianStateMachine = new JulianPowerPunchState(Sprite, this);
            }

        }

        public void MetaAttack()
        {
            if (!Dead && !(JulianStateMachine is JulianMetaAttackState))
            {
                PhysicsState = new NullPhysicsState();
                Sounds.Instance.PlayExplodeSound1();
                Location += new Vector2(0, -487f);
                if (FacingDirection == FacingDirection.Left)
                    Sprite = EnemySpriteFactory.Instance.CreateJulianMegaAttackLeft();
                else
                    Sprite = EnemySpriteFactory.Instance.CreateJulianMegaAttackRight();
                JulianStateMachine = new JulianMetaAttackState(Sprite, this);
            }

        }

        public void Jump()
        {
            if (!(PhysicsState is JumpState) || !(PhysicsState is FallState))
                PhysicsState = new JumpState(this);
        }

    }
}
