using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Block
{
    class CoinBrick : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public IGameObjectState BrickStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

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

        public int CoinCounter = 5;
        public CoinBrick(Vector2 location)
        {
            // initial state
            IsHidden = false;
            IsBumped = false;
            Location = location;
            BrickStateMachine = new BrickStateMachine(false);
            block = BrickStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            BrickStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BrickStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            BrickStateMachine = new BrickStateMachine(true);
        }

        /*public void Bumped()
        {
            //BrickStateMachine = new CoinBrickBumpStateMachine(false, this);
        }*/

    }
}
