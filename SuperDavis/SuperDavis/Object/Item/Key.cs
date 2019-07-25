using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Item
{
    class Key : IItem
    {
        public float Mass { get; set; }
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly KeyStateMachine KeyStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = Variables.Variable.KeyTimer;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;

        public Key(Vector2 location)
        {
            // initial state

            IsAnimated = false;
            Location = location;
            KeyStateMachine = new KeyStateMachine();
            item = KeyStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {

            KeyStateMachine.Update(gameTime);
            if (!IsAnimated)
            {
                if (timer > 10)
                {
                    Location += new Vector2(0, Variables.Variable.KeyOffsetDown);
                    timer--;
                }
                else if (timer > 0)
                {
                    Location += new Vector2(0, Variables.Variable.KeyOffsetUp);
                    timer--;
                }
                else
                {
                    timer = Variables.Variable.KeyTimer;
                    IsAnimated = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            KeyStateMachine.Draw(spriteBatch, Location);
        }
    }


}

