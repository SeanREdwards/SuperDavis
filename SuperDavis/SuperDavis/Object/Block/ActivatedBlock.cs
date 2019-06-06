using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class ActivatedBlock : IBlock
    {
        public Vector2 Location { get; set; }
        private ActivatedBlockStateMachine activatedBlockStateMachine;

        public ActivatedBlock(Vector2 location)
        {
            // initial state
            Location = location;
            activatedBlockStateMachine = new ActivatedBlockStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            activatedBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activatedBlockStateMachine.Draw(spriteBatch, Location);
        }
    }
}
