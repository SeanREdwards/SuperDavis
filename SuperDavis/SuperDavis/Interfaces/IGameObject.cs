﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperDavis.Interfaces
{
    interface IGameObject
    {
        event System.EventHandler OnPositionChanged;
        Rectangle HitBox { get; set; }
        Vector2 Location { get; set; }
        IGameObjectPhysics PhysicsState { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spritebatch);
    }
}
