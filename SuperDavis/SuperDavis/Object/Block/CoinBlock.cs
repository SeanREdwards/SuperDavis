using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class CoinBlock : IBlock
    {
        public bool IsBumped { get; set; }
        public bool Remove { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public CoinBlockStateMachine CoinBlockStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public CoinBlock(Vector2 location)
        {
            // initial state
            Remove = false;
            IsHidden = false;
            Location = location;
            CoinBlockStateMachine = new CoinBlockStateMachine(false);
            block = CoinBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                CoinBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                CoinBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            CoinBlockStateMachine = new CoinBlockStateMachine(true);
        }
    }
}
