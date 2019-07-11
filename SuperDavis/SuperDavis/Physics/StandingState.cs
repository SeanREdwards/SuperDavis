using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Character;
using SuperDavis.State.DavisState;

namespace SuperDavis.Physics
{
    class StandingState : IGameObjectPhysics
    {
        // Idea, by passing different igameobject, implement different 
        // param for Falling, using lists
        private IGameObject gameObject;
        private IDavis davis;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public StandingState(IGameObject gameObjectClass)
        {
            this.gameObject = gameObjectClass;
            if (gameObjectClass is IDavis)
                davis = (IDavis)gameObject;

        }

        public void Update(GameTime gameTime)
        {
            if(gameObject is IDavis)
                if ((davis.DavisState is DavisWalkLeftState) || (davis.DavisState is DavisWalkRightState))
                    davis.PhysicsState = new FallState(davis);
        }
    }
}
