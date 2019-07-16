using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class BatProjectile : IProjectile
    {
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

        public FacingDirection FacingDirection { get; set; }

        private BatProjectileStateMachine BatProjectileStateMachine;
        private readonly ISprite projectile;

        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
 
        public BatProjectile(Vector2 location, FacingDirection facingDirection)
        {
            // initial state

            this.FacingDirection = facingDirection;
            Location = location;
            BatProjectileStateMachine = new BatProjectileStateMachine(false);
            projectile = BatProjectileStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectile.Width, (int)projectile.Height);
        }

        public void Update(GameTime gameTime)
        {

            BatProjectileStateMachine.Update(gameTime);
            if(FacingDirection == FacingDirection.Left)
                Location += new Vector2(Variables.Variable.BatProjLeftMovement, 0);
            else
                Location += new Vector2(Variables.Variable.BatProjRightMovement, 0);

            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectile.Width, (int)projectile.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BatProjectileStateMachine.Draw(spriteBatch, Location);
        }

        public void Explode()
        {
            BatProjectileStateMachine = new BatProjectileStateMachine(true);
        }
    }
}
