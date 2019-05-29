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

namespace SuperDavis.Object.Block
{
    class HiddenBlock : IBlock
    {
        public Vector2 Location { get; set; }
        private HiddenBlockStateMachine hiddenBlockStateMachine;

        public HiddenBlock(Vector2 location)
        {
            // initial state
            Location = location;
            hiddenBlockStateMachine = new HiddenBlockStateMachine(true);
        }

        public void Update(GameTime gameTime)
        {
            hiddenBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hiddenBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void UnhiddenBlock()
        {
            hiddenBlockStateMachine = new HiddenBlockStateMachine(false);
        }

    }
}
