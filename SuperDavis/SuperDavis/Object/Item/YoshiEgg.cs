﻿namespace SuperDavis.Object.Item
{
    /*class YoshiEgg : IItem
    {
        public float Mass { get; set; }
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly YoshiEggStateMachine yoshiEggStateMachine;
        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        public IGameObjectPhysics PhysicsState { get; set; }

        public YoshiEgg(Vector2 location)
        {
            // initial state

            Location = location;
            yoshiEggStateMachine = new YoshiEggStateMachine();
            item = yoshiEggStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {

            yoshiEggStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            yoshiEggStateMachine.Draw(spriteBatch, Location);
        }


    }*/
}
