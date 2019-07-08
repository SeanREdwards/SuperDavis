using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class PhysicsManager : IGameObjectPhysics
    {
        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public PhysicsManager(IGameObject @object, Vector2 maxVelocity)
        {
            gameObject = @object;
            Velocity = Vector2.Zero;
            MaxVelocity = maxVelocity;
            Acceleration = new Vector2(0, Variables.Variable.GRAVITY);
        }

        public void ApplyForce(Vector2 force)
        {
            Acceleration += force / gameObject.Mass;
        }

        public void Update(GameTime gameTime)
        {
            var timeInterval = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50;
            Velocity += Acceleration * timeInterval; // vt = v0 + at;
            CheckMaxVelocity();
            gameObject.Location += Velocity * timeInterval; // st = s0 + vt;
            System.Console.WriteLine(Velocity + "/" + Acceleration);
        }

        /* Helper Method */
        public void CheckMaxVelocity()
        {
            if (Math.Abs(Velocity.X) > MaxVelocity.X)
            {
                if (Velocity.X > 0)
                    Velocity = new Vector2(MaxVelocity.X, Velocity.Y);
                else
                    Velocity = new Vector2(-MaxVelocity.X, Velocity.Y);
            }
            if (Math.Abs(Velocity.Y) > MaxVelocity.Y)
            {
                if (Velocity.Y > 0)
                    Velocity = new Vector2(Velocity.X, MaxVelocity.Y);
                else
                    Velocity = new Vector2(Velocity.X, -MaxVelocity.Y);
            }
        }
    }
}
