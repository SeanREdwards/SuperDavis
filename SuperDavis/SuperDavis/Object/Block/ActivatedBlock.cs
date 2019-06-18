using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.SpriteState.ItemStateMachine;

namespace SuperDavis.Object.Block
{
    class ActivatedBlock : IBlock
    {
        public bool Remove { get; set; }
        public bool IsHidden { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get ; set ; }
        public IGameObjectPhysicsState PhysicsState { get; set; }

        private readonly ISprite block;
        private readonly ActivatedBlockStateMachine activatedBlockStateMachine;

        public ActivatedBlock(Vector2 location)
        {
            // initial state
            Remove = false;
            IsHidden = false;
            Location = location;
            activatedBlockStateMachine = new ActivatedBlockStateMachine();
            block = activatedBlockStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                activatedBlockStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                activatedBlockStateMachine.Draw(spriteBatch, Location);
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
