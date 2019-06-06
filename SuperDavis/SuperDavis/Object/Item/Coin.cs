using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Coin : IItem
    {
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private readonly CoinStateMachine coinStateMachine;

        public Coin(Vector2 location)
        {
            // initial state
            Location = location;
            coinStateMachine = new CoinStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            coinStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           coinStateMachine.Draw(spriteBatch, Location);
        }
    }
}
