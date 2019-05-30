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
    class Star : IItem
    {
        public Vector2 Location { get; set; }
        private readonly StarStateMachine starStateMachine;

        public Star(Vector2 location)
        {
            // initial state
            Location = location;
            starStateMachine = new StarStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            starStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            starStateMachine.Draw(spriteBatch, Location);
        }
    }
}
