using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class Brick : IBlock
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public BrickStateMachine BrickStateMachine;
        private ISprite block;
        public Rectangle HitBox { get; set; }

        public Brick(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            BrickStateMachine = new BrickStateMachine(false);
            block = BrickStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, block.Width, block.Height);
        }

        public void Update(GameTime gameTime)
        {
            BrickStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                BrickStateMachine.Draw(spriteBatch, Location);
            }
        }

        public void BreakBrick()
        {
            BrickStateMachine = new BrickStateMachine(true);
        }

        public void Reset()
        {
            BrickStateMachine = new BrickStateMachine(false);
        }


    }
}
