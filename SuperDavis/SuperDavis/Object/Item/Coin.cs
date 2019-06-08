using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Coin : IItem
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get;set; }
        private ISprite item;

        private CoinStateMachine coinStateMachine;

        public Coin(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            coinStateMachine = new CoinStateMachine();
            item = coinStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, item.Width, item.Height);
        }

        public void Update(GameTime gameTime)
        {
            coinStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                coinStateMachine.Draw(spriteBatch, Location);
            }
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
