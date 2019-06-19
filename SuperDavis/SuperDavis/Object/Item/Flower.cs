using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Flower : IItem
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly FlowerStateMachine flowerStateMachine;
        public IGameObjectPhysicsState PhysicsState { get; set; }

        public Flower(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            flowerStateMachine = new FlowerStateMachine();
            item = flowerStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                flowerStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                flowerStateMachine.Draw(spriteBatch, Location);
        }

        public void Clear()
        {
            Remove = true;
        }

        public void Reset()
        {
            Remove = false;
        }
    }
}
