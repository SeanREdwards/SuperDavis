﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Item
{
    class BatProjectile : IProjectile
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

        public BatProjectile(Vector2 location, FacingDirection facingDirection)
        {
            // initial state
            IsExploded = false;
            this.FacingDirection = facingDirection;
            PhysicsState = new BatProjectilePhysicsState(this);
            Location = location;
            if (FacingDirection == FacingDirection.Right)
                projectileSprite = DavisSpriteFactory.Instance.CreateBatProjectileRight();
            else
                projectileSprite = DavisSpriteFactory.Instance.CreateBatProjectileLeft();
            BatProjectileStateMachine = new ProjectileStateMachine(projectileSprite);
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
            projectileSprite = DavisSpriteFactory.Instance.BatExplodeRight();
            BatProjectileStateMachine = new ProjectileExplodeStateMachine(projectileSprite, this);
        }
    }
}
