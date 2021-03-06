﻿using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{
    class ShoryukenState : IGameObjectPhysics
    {

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }
        private float velocityX;
        private int specialAttackTimer = Variables.Variable.DavisSpecialAttackTimer;
        public ShoryukenState(IGameObject gameObjectClass)
        {

            gameObject = gameObjectClass;
            if ((gameObject as IDavis).FacingDirection == FacingDirection.Left)
                velocityX = 10f;
            else
                velocityX = -10f;

            Velocity = new Vector2(velocityX, 80f);
            Acceleration = new Vector2(1f, 0.85f);
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
