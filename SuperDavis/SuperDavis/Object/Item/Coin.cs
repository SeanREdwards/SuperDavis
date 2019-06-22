using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Coin : IItem
    {
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get;set; }
        private readonly ISprite item;
        private readonly CoinStateMachine coinStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = 20;
        public Coin(Vector2 location)
        {
            // initial state
            Remove = false;
            IsAnimated = false;
            Location = location;
            coinStateMachine = new CoinStateMachine();
            item = coinStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
            {
                coinStateMachine.Update(gameTime);
                if (!IsAnimated)
                {
                    if (timer > 10)
                    {
                        Location += new Vector2(0, -3f);
                        timer--;
                    }else if(timer > 0)
                    {
                        Location += new Vector2(0, 3f);
                        timer--;
                    }                    
                    else
                    {
                        timer = 20;
                        IsAnimated = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                coinStateMachine.Draw(spriteBatch, Location);
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
