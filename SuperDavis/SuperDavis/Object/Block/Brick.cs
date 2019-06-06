using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class Brick : IBlock
    {
        public Vector2 Location { get; set; }
        public BrickStateMachine BrickStateMachine;

        public Brick(Vector2 location)
        {
            // initial state
            Location = location;
            BrickStateMachine = new BrickStateMachine(false);
        }

        public void Update(GameTime gameTime)
        {
            BrickStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BrickStateMachine.Draw(spriteBatch, Location);
        }

        public void BreakBrick()
        {
            BrickStateMachine = new BrickStateMachine(true);
        }
    }
}
