using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{
  /*  class FallState : IGameObjectPhysics
    {

        public float Mass { get; set; }
        // Idea, by passing different igameobject, implement different 
        // param for Falling, using lists
        private IGameObject gameObject;
        private float FallVelocity;
        private float FallVelocityDecayRate;
        private float FallVelocityMax;
        public FallState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            FallVelocity = Variables.Variable.FallVelocity;
            FallVelocityDecayRate = Variables.Variable.FallVelocityIncreaseRate;
            FallVelocityMax = Variables.Variable.FallVelocityMax;
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location += new Vector2(0, FallVelocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            FallVelocity *= FallVelocityDecayRate;
            if (FallVelocity > FallVelocityMax)
            {
                FallVelocity = FallVelocityMax;
            }
        }
    }*/
}
