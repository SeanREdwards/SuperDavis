using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{
    class NullPhysicsState : IGameObjectPhysics
    {

        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public NullPhysicsState()
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
