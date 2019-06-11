using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Mushroom : IItem
    {
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private ISprite item;

        private MushroomStateMachine mushroomStateMachine;

        public Mushroom(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            mushroomStateMachine = new MushroomStateMachine();
            item = mushroomStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, item.Width, item.Height);
        }

        public void Update(GameTime gameTime)
        {
            mushroomStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
            {
                mushroomStateMachine.Draw(spriteBatch, Location);
            }
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
