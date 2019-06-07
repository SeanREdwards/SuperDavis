using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class ActivatedBlock : IBlock
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get ; set ; }
        private ISprite block;

        private ActivatedBlockStateMachine activatedBlockStateMachine;

        public ActivatedBlock(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            activatedBlockStateMachine = new ActivatedBlockStateMachine();
            block = activatedBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, block.Width, block.Height);
        }

        public void Update(GameTime gameTime)
        {
            activatedBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                activatedBlockStateMachine.Draw(spriteBatch, Location);
            }
        }

        public void Reset() { }
    }
}
