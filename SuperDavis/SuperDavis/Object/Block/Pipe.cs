using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Block
{
    class Pipe : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        private readonly PipeStateMachine pipeStateMachine;
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
        public Pipe(Vector2 location)
        {
            // initial state
            IsHidden = false;
            Location = location;
            pipeStateMachine = new PipeStateMachine();
            block = pipeStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState() { }
    }
}
