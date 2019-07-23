using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Block
{
    class CastleBlock : IBlock
    {
        public float Mass { get; set; }
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public IGameObjectState CastleBlockStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        public CastleBlock(Vector2 location)
        {
            // initial state
            IsHidden = false;
            IsBumped = false;
            Location = location;
            CastleBlockStateMachine = new CastleBlockStateMachine();
            block = CastleBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            CastleBlockStateMachine.Update(gameTime);    
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CastleBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
        }
        
    }
}
