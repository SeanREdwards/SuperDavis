using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class Pipe : IBlock
    {
        public Vector2 Location { get; set; }
        private PipeStateMachine pipeStateMachine;

        public Pipe(Vector2 location)
        {
            // initial state
            Location = location;
            pipeStateMachine = new PipeStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            pipeStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeStateMachine.Draw(spriteBatch, Location);
        }
    }
}
