using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class PhysicsState : IGameObjectPhysics
    {
        private const float GRAVITY = 5f;
        private const float FRICTION = 2f;

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public PhysicsState(IGameObject @object)
        {
            gameObject = @object;
            Velocity = Vector2.Zero;
            Acceleration = new Vector2(0, GRAVITY);
        }

        public void ApplyForce(Vector2 force)
        {
            Acceleration += force / gameObject.Mass;
        }

        public void Update(GameTime gameTime)
        {
            var timeInterval = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity += Acceleration * timeInterval; // v = at;
            gameObject.Location += Velocity * timeInterval; // s = vt;
        }
    }
}
