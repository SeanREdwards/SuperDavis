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
        public Vector2 Location { get; set; }
        public BrickStateMachine BrickStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int bumpTimer = 10;
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

        public void Bump()
        {
            for(int i =0; i<30;i++)
            {
                Location += new Vector2(0, -0.5f);
            }
            for(int i = 0; i<30;i++ )
            {
                Location += new Vector2(0, 0.5f);
            }
        }
    }
}
