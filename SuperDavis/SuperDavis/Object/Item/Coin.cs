using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Coin : IItem
    {
        public float Mass { get; set; }
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly CoinStateMachine coinStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = Variables.Variable.CoinTimer;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;

        public Coin(Vector2 location)
        {
            // initial state

            IsAnimated = false;
            Location = location;
            coinStateMachine = new CoinStateMachine();
            item = coinStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {

            coinStateMachine.Update(gameTime);
            if (!IsAnimated)
            {
                if (timer > 10)
                {
                    Location += new Vector2(0, Variables.Variable.CoinOffsetDown);
                    timer--;
                } else if (timer > 0)
                {
                    Location += new Vector2(0, Variables.Variable.CoinOffsetUp);
                    timer--;
                }
                else
                {
                    timer = Variables.Variable.CoinTimer;
                    IsAnimated = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            coinStateMachine.Draw(spriteBatch, Location);
        }
    }


}

