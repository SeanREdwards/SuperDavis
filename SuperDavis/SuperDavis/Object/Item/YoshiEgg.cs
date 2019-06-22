using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class YoshiEgg : IItem
    {
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly YoshiEggStateMachine yoshiEggStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }

        public YoshiEgg(Vector2 location)
        {
            // initial state
            Remove = false;
            Location = location;
            yoshiEggStateMachine = new YoshiEggStateMachine();
            item = yoshiEggStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                yoshiEggStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                yoshiEggStateMachine.Draw(spriteBatch, Location);
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
