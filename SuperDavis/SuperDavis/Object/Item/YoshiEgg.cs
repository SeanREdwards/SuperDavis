using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class YoshiEgg : IItem
    {
        public Vector2 Location { get; set; }
        private readonly YoshiEggStateMachine yoshiEggStateMachine;

        public YoshiEgg(Vector2 location)
        {
            // initial state
            Location = location;
            yoshiEggStateMachine = new YoshiEggStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            yoshiEggStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            yoshiEggStateMachine.Draw(spriteBatch, Location);
        }
    }
}
