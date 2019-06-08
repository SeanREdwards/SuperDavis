using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class YoshiEgg : IItem
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private ISprite item;

        private YoshiEggStateMachine yoshiEggStateMachine;

        public YoshiEgg(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            yoshiEggStateMachine = new YoshiEggStateMachine();
            item = yoshiEggStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, item.Width, item.Height);
        }

        public void Update(GameTime gameTime)
        {
            yoshiEggStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                yoshiEggStateMachine.Draw(spriteBatch, Location);
            }
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
