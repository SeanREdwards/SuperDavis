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
    class Pipe : IBlock
    {
        public Vector2 Location { get; set; }
        private PipeStateMachine pipeStateMachine;

        public Pipe(Vector2 location)
        {
            // initial state
            Location = location;
            pipeStateMachine = new PipeStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            pipeStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeStateMachine.Draw(spriteBatch, Location);
        }
    }
}
