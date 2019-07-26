using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Block
{
    class QuestionBlock : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }

        public QuestionBlockStateMachine QuestionBlockStateMachine;
        private readonly ISprite block;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                OnPositionChanged?.Invoke(this, Tuple.Create(location, value));
                location = value;
            }
        }

        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public QuestionBlock(Vector2 location)
        {
            // initial state
            IsHidden = false;
            Location = location;
            QuestionBlockStateMachine = new QuestionBlockStateMachine(false);
            block = QuestionBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            QuestionBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            QuestionBlockStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            QuestionBlockStateMachine = new QuestionBlockStateMachine(true);
        }
    }
}
