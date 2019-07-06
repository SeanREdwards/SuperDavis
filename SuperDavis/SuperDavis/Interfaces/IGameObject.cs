using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperDavis.Interfaces
{
    interface IGameObject
    {
        event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        Rectangle HitBox { get; set; }
        Vector2 Location { get; set; }
        IGameObjectPhysics PhysicsState { get; set; }
        float Mass { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spritebatch);
    }
}
