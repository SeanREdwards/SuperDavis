using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;

namespace SuperDavis.Physics
{
    class JulianKnockBackState : IGameObjectPhysics
    {

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        private readonly float velocityX;

        public JulianKnockBackState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            if ((gameObject as Julian).FacingDirection == FacingDirection.Left)
                velocityX = 1f;
            else
                velocityX = -1f;

            Velocity = new Vector2(velocityX, -3f);
            Acceleration = new Vector2(1f, 0.9f);
            MaxVelocity = new Vector2(0, -0.5f);
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Velocity.Y > MaxVelocity.Y)
            {
                Velocity = new Vector2(Velocity.X, 0);
                gameObject.PhysicsState = new FallState(gameObject);
            }
        }
    }
}
