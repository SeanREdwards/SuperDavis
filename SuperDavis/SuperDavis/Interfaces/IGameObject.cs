using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperDavis.Interfaces
{
    interface IGameObject
    {
        Rectangle HitBox { get; set; }
        Vector2 Location { get; set; }
        IGameObjectPhysics PhysicsState { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spritebatch);
    }
}
