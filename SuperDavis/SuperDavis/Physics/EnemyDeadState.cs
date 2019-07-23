using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class EnemyDeadState : IGameObjectPhysics
    {

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }


        public EnemyDeadState(IGameObject gameObject)
        {
            this.gameObject = gameObject;
            Velocity = new Vector2(0, 5f);
            Acceleration = new Vector2(0, 0.8f);
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location -= Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Math.Abs(Velocity.Y) < 1)
            {
                Velocity = new Vector2(0, -1f);
                Acceleration = new Vector2(0, 1.1f);
            }

        }
    }
}
