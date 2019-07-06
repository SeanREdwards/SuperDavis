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

        public bool FacingLeft { get; set; }

        private BatProjectileStateMachine BatProjectileStateMachine;
        private readonly ISprite projectile;

        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
 
        public BatProjectile(Vector2 location, bool FacingLeft)
        {
            // initial state

            this.FacingLeft = FacingLeft;
            Location = location;
            BatProjectileStateMachine = new BatProjectileStateMachine(false);
            projectile = BatProjectileStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectile.Width, (int)projectile.Height);
        }

        public void Update(GameTime gameTime)
        {

            BatProjectileStateMachine.Update(gameTime);
            if(FacingLeft)
            {
                Location += new Vector2(-8f, 0);
            }
            else
            {
                Location += new Vector2(8f, 0);
            }
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
