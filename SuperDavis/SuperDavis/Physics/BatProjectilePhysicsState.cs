using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
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

            Velocity = new Vector2(velocityX, 1f);
            Acceleration = new Vector2(1f, 1.3f);
            MaxVelocity = new Vector2(0, 10f);
        }

        public void Update(GameTime gameTime)
        {
            if (projectile.FacingDirection == FacingDirection.Left)
                velocityX = -15f;
            else
                velocityX = 15f;
            Velocity = new Vector2(velocityX, Velocity.Y);

            projectile.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Math.Abs(Velocity.Y) - MaxVelocity.Y > 1)
            {
                var y = Velocity.Y;
                if (y < 0)
                    y = 1f;
                else
                    y = -1f;
                Velocity = new Vector2(Velocity.X, y);
            }
        }
    }
}
