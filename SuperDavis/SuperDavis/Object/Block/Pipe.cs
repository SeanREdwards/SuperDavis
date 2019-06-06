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
        private ISprite block;
        public Rectangle HitBox { get; set; }
        public Pipe(Vector2 location)
        {
            // initial state
            Location = location;
            pipeStateMachine = new PipeStateMachine();
            block = pipeStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, block.Width, block.Height);
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
