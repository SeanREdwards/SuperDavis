using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{

    class JumpState : IGameObjectPhysics
    {
        // Idea, by passing different igameobject, implement different 
        // param for Jumping, using lists
        private IGameObject gameObject;
        private float JumpVelocity;
        private float JumpVelocityDecayRate;
        private float JumpVelocityMin;
        public JumpState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            JumpVelocity = Variables.Variable.JumpVelocity;
            JumpVelocityDecayRate = Variables.Variable.JumpVelocityDecayRate;
            JumpVelocityMin = Variables.Variable.JumpVelocityMin;
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location -= new Vector2(0, JumpVelocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50);
            JumpVelocity *= JumpVelocityDecayRate;
            if (JumpVelocity < JumpVelocityMin)
            {
                JumpVelocity = 0;
                gameObject.PhysicsState = new FallState(gameObject);
            }
        }
    }
}
