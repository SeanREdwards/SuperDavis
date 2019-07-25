using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Item
{
    class DavisProjectile : IProjectile
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

        private IGameObjectState BatProjectileStateMachine;
        private ISprite projectileSprite;

        public bool IsExploded { get; set; }
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public DavisProjectile(Vector2 location, FacingDirection facingDirection)
        {
            // initial state
            IsExploded = false;
            this.FacingDirection = facingDirection;
            PhysicsState = new DavisProjectilePhysicsState(this);
            Location = location;
            if (FacingDirection == FacingDirection.Right)
                projectileSprite = DavisSpriteFactory.Instance.CreateDavisProjectileRight();
            else
                projectileSprite = DavisSpriteFactory.Instance.CreateDavisProjectileLeft();
            BatProjectileStateMachine = new ProjectileStateMachine(projectileSprite, this);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectileSprite.Width, (int)projectileSprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            BatProjectileStateMachine.Update(gameTime);
            PhysicsState.Update(gameTime);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectileSprite.Width, (int)projectileSprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BatProjectileStateMachine.Draw(spriteBatch, Location);
        }

        public void Explode()
        {
            PhysicsState = new NullPhysicsState();
            if (FacingDirection == FacingDirection.Right)
                projectileSprite = DavisSpriteFactory.Instance.CreateDavisProjectileExplodeRight();
            else
                projectileSprite = DavisSpriteFactory.Instance.CreateDavisProjectileExplodeLeft();
            BatProjectileStateMachine = new ProjectileExplodeStateMachine(projectileSprite, this);
        }
    }
}
