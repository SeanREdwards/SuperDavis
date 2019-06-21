using Microsoft.Xna.Framework;

namespace SuperDavis.Interfaces
{
    interface IGameObjectPhysics
    {
      /*  float HorizontalVelocity { get; set; }
        float VerticalVelocity { get; set; }
        float HorizontalAcceleration { get; set; }
        float VerticalAcceleration { get; set; }
        void ApplyForce(Vector2 forceVector);*/
        void Update(GameTime gameTime);
    }
}
