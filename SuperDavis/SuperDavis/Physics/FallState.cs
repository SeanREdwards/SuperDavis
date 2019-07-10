using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{
    class FallState : IGameObjectPhysics
    {

        private IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public FallState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            Velocity = new Vector2(0, Variables.Variable.FallVelocity);
            Acceleration = new Vector2(0, Variables.Variable.FallVelocityIncreaseRate);
            MaxVelocity = new Vector2(0, Variables.Variable.FallVelocityMax);
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Velocity.Y > MaxVelocity.Y)
            {
                Velocity = new Vector2(Velocity.X, MaxVelocity.Y);
            }
        }
    }
}
