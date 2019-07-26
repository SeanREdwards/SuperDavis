/*
 Class to create and represent walls of variable heighth/width
 @Author Sean Edwards
 */

namespace SuperDavis.Object.Block
{
    /*class Wall
    {
        public int Height { get; }
        public int Width { get; }
        private int X;
        private int Y;
        private ISprite wallSprite;
        public Vector2 Location { get; set; }
        public BrickStateMachine BrickStateMachine;

        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;


        public Wall(Vector2 location, int blocksHigh, int blocksWide)
        {
            // initial state
            Location = location;
            wallSprite = ItemSpriteFactory.Instance.CreateMiddleCastleBlock();
            Height = (int)wallSprite.Height * blocksHigh;
            Width = (int)wallSprite.Width * blocksWide;
            X = (int)Location.X;
            Y = (int)Location.Y;
            BrickStateMachine = new BrickStateMachine(false);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, this.Width, this.Height);
        }

        /*public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < wallSprite.Width; i++)
            {
                for (int j = 0; j < wallSprite.Height; j++)
                {
                    wallSprite.Draw(spriteBatch, new Vector2((int)Location.X + (wallSprite.Width * i), (int)Location.Y + (wallSprite.Height * j)));
                }
            }
        }
    }*/
}
