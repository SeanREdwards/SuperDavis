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
    class ActivatedBlock : IBlock
    {
        public Vector2 Location { get; set; }
        private ActivatedBlockStateMachine activatedBlockStateMachine;

        public ActivatedBlock(Vector2 location)
        {
            // initial state
            Location = location;
            activatedBlockStateMachine = new ActivatedBlockStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            activatedBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activatedBlockStateMachine.Draw(spriteBatch, Location);
        }
    }
}
