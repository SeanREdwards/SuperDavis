using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Mushroom : IItem
    {
        public Vector2 Location { get; set; }
        private readonly MushroomStateMachine mushroomStateMachine;

        public Mushroom(Vector2 location)
        {
            // initial state
            Location = location;
            mushroomStateMachine = new MushroomStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            mushroomStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mushroomStateMachine.Draw(spriteBatch, Location);
        }
    }
}
