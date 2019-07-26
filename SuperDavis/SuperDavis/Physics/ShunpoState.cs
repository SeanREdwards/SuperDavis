using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Physics
{
    class ShunpoState : IGameObjectPhysics
    {

        private readonly IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        private float velocityX;
        private int specialAttackTimer = Variables.Variable.BatSpecialAttackTimer;
        public ShunpoState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            if ((gameObject as IDavis).FacingDirection == FacingDirection.Left)
                velocityX = -50f;
            else
                velocityX = 50f;

            Velocity = new Vector2(velocityX, 0f);

        }

        public void Update(GameTime gameTime)
        {
            //gameObject.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            if (specialAttackTimer == Variables.Variable.BatSpecialAttackTimer / 2)
            {
                if (velocityX > 0)
                    gameObject.Location += new Vector2(200f, 0);
                else
                    gameObject.Location += new Vector2(-200f, 0);
            }
            if (specialAttackTimer == 0)
            {
                gameObject.PhysicsState = new FallState(gameObject);
            }
            specialAttackTimer--;
        }
    }
}
