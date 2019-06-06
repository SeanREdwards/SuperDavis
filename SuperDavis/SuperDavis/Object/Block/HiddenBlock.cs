using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class HiddenBlock : IBlock
    {
        public Vector2 Location { get; set; }
        public HiddenBlockStateMachine HiddenBlockStateMachine;
        private ISprite block;
        public Rectangle HitBox { get; set; }
        public HiddenBlock(Vector2 location)
        {
            // initial state
            Location = location;
            HiddenBlockStateMachine = new HiddenBlockStateMachine(true);
            block = HiddenBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, block.Width, block.Height);
        }

        public void Update(GameTime gameTime)
        {
            HiddenBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HiddenBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void UnhiddenBlock()
        {
            HiddenBlockStateMachine = new HiddenBlockStateMachine(false);
        }

        public void Reset()
        {
            HiddenBlockStateMachine = new HiddenBlockStateMachine(true);
        }

    }
}
