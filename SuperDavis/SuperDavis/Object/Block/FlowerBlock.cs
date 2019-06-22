using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class FlowerBlock : IBlock
    {
        public bool IsBumped { get; set; }
        public bool Remove { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public FlowerBlockStateMachine FlowerBlockStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public FlowerBlock(Vector2 location)
        {
            // initial state
            Remove = false;
            IsHidden = false;
            IsBumped = false;
            Location = location;
            FlowerBlockStateMachine = new FlowerBlockStateMachine(false);
            block = FlowerBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                FlowerBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                FlowerBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            FlowerBlockStateMachine = new FlowerBlockStateMachine(true);
        }
    }
}
