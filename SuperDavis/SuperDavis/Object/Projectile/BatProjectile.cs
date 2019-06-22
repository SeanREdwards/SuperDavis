using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;

namespace SuperDavis.Object.Item
{
    class BatProjectile : IProjectile
    {
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public Vector2 Location { get; set; }
        private BatProjectileStateMachine BatProjectileStateMachine;
        private readonly ISprite projectile;
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = 35;
        public BatProjectile(Vector2 location, bool FacingLeft)
        {
            // initial state
            Remove = false;
            this.FacingLeft = FacingLeft;
            Location = location;
            BatProjectileStateMachine = new BatProjectileStateMachine(false);
            projectile = BatProjectileStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectile.Width, (int)projectile.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
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
            }
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)projectile.Width, (int)projectile.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                BatProjectileStateMachine.Draw(spriteBatch, Location);
        }

        public void Explode()
        {
            BatProjectileStateMachine = new BatProjectileStateMachine(true);
        }

        public void Clear()
        {
            Remove = true;
        }
    }
}
