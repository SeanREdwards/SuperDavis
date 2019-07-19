using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Character;
using SuperDavis.State.DavisState;
using System;

namespace SuperDavis.Physics
{
    class BatProjectilePhysicsState : IGameObjectPhysics
    {
        // Idea, by passing different igameobject, implement different 
        // param for Falling, using lists
        private IProjectile projectile;
        private float velocityX;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public BatProjectilePhysicsState(IProjectile projectile)
        {
            this.projectile = projectile;
            if (projectile.FacingDirection == FacingDirection.Left)
                velocityX = -8f;
            else
                velocityX = 8f;
            Velocity = new Vector2(velocityX, 0);
            Acceleration = new Vector2(1f, 1.2f);
            MaxVelocity = new Vector2(0, 5f);

        }

        public void Update(GameTime gameTime)
        {
            projectile.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Math.Abs(Velocity.Y - MaxVelocity.Y) < 1)
            {
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            }
        }
    }
}
