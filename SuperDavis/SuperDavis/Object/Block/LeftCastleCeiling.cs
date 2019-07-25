﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using System;

namespace SuperDavis.Object.Block
{
    /*
     * Class to represent castle Ceiling block.
     * @Author Sean Edwards
     */

    class LeftCastleCeiling : IBlock
    {
        public float Mass { get; set; }
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private readonly ISprite sprite;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        public LeftCastleCeiling(Vector2 location)
        {
            // initial state
            IsHidden = false;
            Location = location;

            //Re-use of activatedBlockStateMachine since Ceiling ultimately functions like an activated block.

            sprite = ItemSpriteFactory.Instance.CreateLeftCastleCeiling();

            //Hitbox size for all Castle Ceiling tiles is same size
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            //Ceiling doesn't need to be updated
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }
        public void SpecialState()
        {
            // No nothing for current sprint
        }
    }
}
