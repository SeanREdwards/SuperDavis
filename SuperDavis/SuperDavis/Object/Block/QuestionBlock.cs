using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class QuestionBlock : IBlock
    {
        public bool IsBumped { get; set; }
        public bool Remove { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public QuestionBlockStateMachine QuestionBlockStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public QuestionBlock(Vector2 location)
        {
            // initial state
            Remove = false;
            IsHidden = false;
            Location = location;
            QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
            block = QuestionBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                QuestionBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                QuestionBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            QuestionBlockStateMachine = new QuestionBlockStateMachine(true);
        }
    }
}
