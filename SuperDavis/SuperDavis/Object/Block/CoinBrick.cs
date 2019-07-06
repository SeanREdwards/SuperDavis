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
        public Vector2 Location { get; set; }
        public BrickStateMachine BrickStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int bumpTimer = Variables.Variable.BumpTime;
        public int CoinCounter = Variables.Variable.CoinBrickCounter;
        public event EventHandler OnPositionChanged;
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
            if (IsBumped)
            {
                if (bumpTimer > Variables.Variable.BumpTimeHalf)
                    Location += new Vector2(0, Variables.Variable.BumpShiftDown);
                else if (bumpTimer  > 0)
                    Location += new Vector2(0, Variables.Variable.BumpShiftUp);
                else
                {
                    bumpTimer = Variables.Variable.BumpTime;
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
