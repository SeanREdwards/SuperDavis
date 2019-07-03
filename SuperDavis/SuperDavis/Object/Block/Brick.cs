using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class Brick : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }

        private Vector2 location;
        public Vector2 Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPositionChanged?.Invoke(this, EventArgs.Empty); 
            }
        }
        public BrickStateMachine BrickStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int bumpTimer = 10;

        public event EventHandler OnPositionChanged;

        public Brick(Vector2 location)
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
            if (IsBumped)
            {
                if (bumpTimer > 5)
                    Location += new Vector2(0, -1f);
                else if (bumpTimer  > 0)
                    Location += new Vector2(0, 1f);
                else
                {
                    bumpTimer = 10;
                    IsBumped = false;
                }
                bumpTimer--;
            }
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BrickStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            BrickStateMachine = new BrickStateMachine(true);
        }

        
    }
}
