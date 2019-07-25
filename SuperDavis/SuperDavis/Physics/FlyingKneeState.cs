using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class FlyingKneeState : IGameObjectPhysics
    {

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        private float velocityX;
        public FlyingKneeState(IGameObject gameObjectClass)
        {

            gameObject = gameObjectClass;
            if ((gameObject as IDavis).FacingDirection == FacingDirection.Left)
                velocityX = 50f;
            else
                velocityX = -50f;

            Velocity = new Vector2(velocityX, 15f);
            Acceleration = new Vector2(0.95f, 0.9f);
            MaxVelocity = new Vector2(0, Variables.Variable.JumpVelocityMin);
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location -= Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Math.Abs(Velocity.Y - MaxVelocity.Y) < 1)
            {
                Velocity = new Vector2(Velocity.X, 0);
                gameObject.PhysicsState = new FallState(gameObject);
            }
        }
    }
}
