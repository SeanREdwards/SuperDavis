using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.SpriteState.ItemStateMachine;
using SuperDavis.Factory;

namespace SuperDavis.Object.Block
{
    class RightGreenFloor : IBlock
    {

        public bool Remove { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysicsState PhysicsState { get; set; }

        private ISprite sprite;

        private readonly ActivatedBlockStateMachine activatedBlockStateMachine;

        public RightGreenFloor(Vector2 location)
        {
            // initial state
            Remove = false;
            IsHidden = false;
            Location = location;

            //Re-use of activatedBlockStateMachine since floor ultimately functions like an activated block.
            activatedBlockStateMachine = new ActivatedBlockStateMachine();

            sprite = ItemSpriteFactory.Instance.CreateRightGreenFloor();

            //Hitbox size for all green floor tiles is same size
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.Width, (int)sprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            //Floor doesn't need to be updated
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                sprite.Draw(spriteBatch, Location);
        }
        public void SpecialState()
        {
            // No nothing for current sprint
        }
        public void Reset()
        {
            // No nothing for current sprint
        }
    }
}

