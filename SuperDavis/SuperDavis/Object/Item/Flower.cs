using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Flower : IItem
    {
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly FlowerStateMachine flowerStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = 40;
        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;

        public Flower(Vector2 location)
        {
            // initial state
            IsAnimated = false;
            Location = location;
            flowerStateMachine = new FlowerStateMachine();
            item = flowerStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {

                flowerStateMachine.Update(gameTime);
                if (!IsAnimated)
                {
                    if (timer > 0)
                    {
                        Location += new Vector2(0, -0.35f);
                        timer--;
                    } else
                    {
                        timer = 50;
                        IsAnimated = true;
                    }
                }       


        }

        public void Draw(SpriteBatch spriteBatch)
        {

                flowerStateMachine.Draw(spriteBatch, Location);
        }


    }
}
