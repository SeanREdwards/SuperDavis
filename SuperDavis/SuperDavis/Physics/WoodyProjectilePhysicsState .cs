using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class WoodyProjectilePhysicsState : IGameObjectPhysics
    {
        // Idea, by passing different igameobject, implement different 
        // param for Falling, using lists
        private IProjectile projectile;
        private float velocityX;
        private float velocityY;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public WoodyProjectilePhysicsState(IProjectile projectile)
        {
            this.projectile = projectile;
            if (projectile.FacingDirection == FacingDirection.Left)
                velocityX = -5f;
            else
                velocityX = 5f;

            Random random = new Random();
            if (random.Next(2) < 1)
                velocityY = 1f;
            else
                velocityY = -1f;
            Velocity = new Vector2(velocityX, velocityY);
            Acceleration = new Vector2(1.1f, 1f);
            MaxVelocity = new Vector2(40f, 0f);
        }

        public void Update(GameTime gameTime)
        {
            projectile.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Math.Abs(Velocity.X) - MaxVelocity.X > 1)
            {
                if (Velocity.X > 0)
                    Velocity = new Vector2(MaxVelocity.X, Velocity.Y);
                else
                    Velocity = new Vector2(-MaxVelocity.X, Velocity.Y);
            }
        }
    }
}
