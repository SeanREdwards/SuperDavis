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

        public HiddenBlock(Vector2 location)
        {
            // initial state
            Location = location;
            HiddenBlockStateMachine = new HiddenBlockStateMachine(true);
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

    }
}
