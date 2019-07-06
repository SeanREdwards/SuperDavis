using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Star : IItem
    {
        public float Mass { get; set; }
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
 
        public Vector2 Location { get; set; }
        private readonly StarStateMachine starStateMachine;
        private readonly ISprite item;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = Variables.Variable.StarTimer;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;

        public Star(Vector2 location)
        {
            // initial state

            IsAnimated = false;
            Location = location;
            starStateMachine = new StarStateMachine();
            item = starStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {

                starStateMachine.Update(gameTime);
                if (!IsAnimated)
                {
                    if (timer > 0)
                    {
                        Location += new Vector2(0, Variables.Variable.StarOffsetDown);
                        timer--;
                    }
                    else
                    {
                        timer = Variables.Variable.StarTimer;
                        IsAnimated = true;
                    }
                }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

                starStateMachine.Draw(spriteBatch, Location);
        }


    }
}
