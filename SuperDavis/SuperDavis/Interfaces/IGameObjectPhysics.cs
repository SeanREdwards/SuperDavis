using Microsoft.Xna.Framework;

namespace SuperDavis.Interfaces
{
    interface IGameObjectPhysics
    {
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }

        void ApplyForce(Vector2 forceVector);
        void Update(GameTime gameTime);

        //void FreeFalling();
    }
}
