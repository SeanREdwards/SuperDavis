using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class ActivatedBlock : IBlock
    {
        public float Mass { get; set; }
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get ; set ; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private readonly ISprite block;
        private readonly ActivatedBlockStateMachine activatedBlockStateMachine;

        public event EventHandler<Tuple<Vector2,Vector2>> OnPositionChanged;

        public ActivatedBlock(Vector2 location)
        {
            // initial state
            IsHidden = false;
            Location = location;
            activatedBlockStateMachine = new ActivatedBlockStateMachine();
            block = activatedBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
                activatedBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                activatedBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            // No nothing for current sprint
        }
    }
}
