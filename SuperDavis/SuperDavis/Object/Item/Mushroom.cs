using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class Mushroom : IItem
    {
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly MushroomStateMachine mushroomStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = 40;
        public Mushroom(Vector2 location)
        {
            // initial state
            Remove = false;
            IsAnimated = false;
            Location = location;
            mushroomStateMachine = new MushroomStateMachine();
            item = mushroomStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
            {
                mushroomStateMachine.Update(gameTime);
                if (!IsAnimated)
                {
                    if (timer > 0)
                    {
                        Location += new Vector2(0, -0.35f);
                        timer--;
                    }
                    else
                    {
                        timer = 50;
                        IsAnimated = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                mushroomStateMachine.Draw(spriteBatch, Location);
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
