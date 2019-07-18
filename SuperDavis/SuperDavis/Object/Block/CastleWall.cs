using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Block
{
    class CastleWall 
    {
        public int Height { get; }
        public int Width { get; }
        private int X;
        private int Y;
        private ISprite wallSprite;
        public Vector2 Location { get; set; }
        public BrickStateMachine BrickStateMachine;
        private readonly ISprite block;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int bumpTimer = Variables.Variable.BumpTime;
        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        public CastleWall(Vector2 location)
        {
            // initial state
            Location = location;
            Height = 160;
            Width = 32;
            X = (int)Location.X;
            Y = (int)Location.Y;
            BrickStateMachine = new BrickStateMachine(false);
            wallSprite = ItemSpriteFactory.Instance.CreateMiddleCastleBlock();
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, this.Width, this.Height);
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            wallSprite.Draw(spriteBatch, Location);
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 1)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 2)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 3)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 4)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 5)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 6)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 7)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 8)));
            wallSprite.Draw(spriteBatch, new Vector2((int)Location.X, (int)Location.Y + (wallSprite.Height * 9)));
        }
    }
}
