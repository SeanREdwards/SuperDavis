using Microsoft.Xna.Framework;

namespace SuperDavis.Interfaces
{
    interface IGameObjectPhysics
    {
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }

        void Update(GameTime gameTime);

        //void FreeFalling();
    }
}
