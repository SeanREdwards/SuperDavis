using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interface;
using SuperDavis.State.DavisState;
using SuperDavis.State.ItemStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Object.Item
{
    class Coin : IItem
    {
        public Vector2 Location { get; set; }
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
