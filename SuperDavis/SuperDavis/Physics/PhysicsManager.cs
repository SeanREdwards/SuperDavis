using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class PhysicsManager : IGameObjectPhysics
    {
        private const float GRAVITY = 5f;
        private const float FRICTION = 2f;

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public PhysicsManager(IGameObject @object, Vector2 maxVelocity)
        {
            gameObject = @object;
            Velocity = Vector2.Zero;
            MaxVelocity = maxVelocity;
            Acceleration = new Vector2(0, GRAVITY);

        }

        public void ApplyForce(Vector2 force)
        {
            Acceleration += force / gameObject.Mass;
        }

        public void Update(GameTime gameTime)
        {
            var timeInterval = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50;
            Velocity += Acceleration * timeInterval; // vt = v0 + at;
            if (Velocity.X > MaxVelocity.X)
                Velocity = new Vector2(MaxVelocity.X, Velocity.Y);
            if (Velocity.Y > MaxVelocity.Y)
                Velocity = new Vector2(Velocity.X, MaxVelocity.Y);
            gameObject.Location += Velocity * timeInterval; // st = s0 + vt;
            System.Console.WriteLine(Velocity + "/" + Acceleration);
        }
    }
}
