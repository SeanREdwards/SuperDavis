﻿using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{
    class FlyingKneeState : IGameObjectPhysics
    {

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        private float velocityX;
        private int specialAttackTimer = Variables.Variable.WoodySpecialAttackTimer;
        public FlyingKneeState(IGameObject gameObjectClass)
        {

            gameObject = gameObjectClass;
            if ((gameObject as IDavis).FacingDirection == FacingDirection.Left)
                velocityX = 70f;
            else
                velocityX = -70f;

            Velocity = new Vector2(velocityX, 15f);
            Acceleration = new Vector2(0.95f, 0.9f);
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location -= Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (specialAttackTimer == 0)
            {
                Velocity = new Vector2(Velocity.X, 0);
                gameObject.PhysicsState = new FallState(gameObject);
            }
            specialAttackTimer--;
        }
    }
}
