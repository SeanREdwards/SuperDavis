using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class DavisProjectilePhysicsState : IGameObjectPhysics
    {
        // Idea, by passing different igameobject, implement different 
        // param for Falling, using lists
        private IProjectile projectile;
        private float velocityX;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public DavisProjectilePhysicsState(IProjectile projectile)
        {
            this.projectile = projectile;
            if (projectile.FacingDirection == FacingDirection.Left)
                velocityX = -5f;
            else
                velocityX = 5f;
            Velocity = new Vector2(velocityX, 0);
            Acceleration = new Vector2(1.05f, 0f);
            MaxVelocity = new Vector2(45f, 0f);
        }

        public void Update(GameTime gameTime)
        {


            projectile.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Math.Abs(Velocity.X) - MaxVelocity.X > 1)
            {
                if (Velocity.X > 0)
                    Velocity = new Vector2(MaxVelocity.X, 0);
                else
                    Velocity = new Vector2(-MaxVelocity.X, 0);
            }
        }
    }
}
