﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class MushroomBlock : IBlock
    {
        public bool IsBumped { get; set; }
        public bool Remove { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public MushroomBlockStateMachine MushroomBlockStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public MushroomBlock(Vector2 location)
        {
            // initial state
            Remove = false;
            IsHidden = false;
            IsBumped = false;
            Location = location;
            MushroomBlockStateMachine = new MushroomBlockStateMachine(false);
            block = MushroomBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                MushroomBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                MushroomBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            MushroomBlockStateMachine = new MushroomBlockStateMachine(true);
        }
    }
}
