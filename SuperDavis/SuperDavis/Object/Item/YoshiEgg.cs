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
    class YoshiEgg : IItem
    {
        public Vector2 Location { get; set; }
        private readonly YoshiEggStateMachine yoshiEggStateMachine;

        public YoshiEgg(Vector2 location)
        {
            // initial state
            Location = location;
            yoshiEggStateMachine = new YoshiEggStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            yoshiEggStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            yoshiEggStateMachine.Draw(spriteBatch, Location);
        }
    }
}
