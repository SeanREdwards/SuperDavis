using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class HiddenBlock : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public HiddenBlockStateMachine HiddenBlockStateMachine;
        private readonly ISprite block;

        public event EventHandler<Vector2> OnPositionChanged;

        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public HiddenBlock(Vector2 location)
        {
            // initial state
            IsHidden = true;
            Location = location;
            HiddenBlockStateMachine = new HiddenBlockStateMachine(IsHidden);
            block = HiddenBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            HiddenBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HiddenBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            IsHidden = false;
            HiddenBlockStateMachine = new HiddenBlockStateMachine(IsHidden);
        }
    }
}
