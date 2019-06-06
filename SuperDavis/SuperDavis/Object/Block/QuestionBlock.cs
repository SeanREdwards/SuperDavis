using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class QuestionBlock : IBlock
    {
        public Vector2 Location { get; set; }
        public QuestionBlockStateMachine QuestionBlockStateMachine;
        private ISprite block;
        public Rectangle HitBox { get; set; }

        public QuestionBlock(Vector2 location)
        {
            // initial state
            Location = location;
            QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
            block = QuestionBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, block.Width, block.Height);
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

        public void Reset()
        {
            QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
        }

    }
}
