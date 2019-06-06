using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Flower : IItem
    {
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private readonly FlowerStateMachine flowerStateMachine;

        public Flower(Vector2 location)
        {
            // initial state
            Location = location;
            flowerStateMachine = new FlowerStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            flowerStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            flowerStateMachine.Draw(spriteBatch, Location);
        }
    }
}
