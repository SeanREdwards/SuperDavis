using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Block
{
    class CastleDoor : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private ISprite block;
        private DoorStateMachine doorStateMachine;


        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                OnPositionChanged?.Invoke(this, Tuple.Create(location, value));
                location = value;
            }
        }

        public CastleDoor(Vector2 location)
        {
            // initial state
            IsHidden = false;
            Location = location;
            block = ItemSpriteFactory.Instance.CreateCastleDoorOpened();
            doorStateMachine = new DoorStateMachine(block);

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)block.Width, (int)block.Height);
        }

        public void Update(GameTime gameTime)
        {
            doorStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            doorStateMachine.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {
            // No nothing for current sprint
        }

        /*public void OpenDoor()
        {
            block = ItemSpriteFactory.Instance.CreateCastleDoorOpened();
            doorStateMachine = new DoorStateMachine(block);
        }*/
    }
}
