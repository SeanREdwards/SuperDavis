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
    class QuestionBlock : IBlock
    {
        public Vector2 Location { get; set; }
        public QuestionBlockStateMachine QuestionBlockStateMachine;

        public QuestionBlock(Vector2 location)
        {
            // initial state
            Location = location;
            QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
        }

        public void Update(GameTime gameTime)
        {
            QuestionBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            QuestionBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void UseQuestionBlock()
        {
            QuestionBlockStateMachine = new QuestionBlockStateMachine(true);
        }
    }
}
