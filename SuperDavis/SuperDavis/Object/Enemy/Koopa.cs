using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.SpriteState.EnemyState;
using SuperDavis.SpriteState.OtherState;

namespace SuperDavis.Object.Enemy
{
    class Koopa : IEnemy
    {
        public bool FacingLeft { get; set; }
        public bool Remove { get; set; }
        public bool Dead { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite enemy;
        private IGameObjectSpriteState koopaStateMachine;
        public IGameObjectPhysicsState PhysicsState { get; set; }

        public Koopa(Vector2 location)
        {
            // initial state
            Remove = false;
            Dead = false;
            FacingLeft = true;
            Location = location;
            koopaStateMachine = new KoopaStateMachine(this);
            enemy = koopaStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)(int)enemy.Width, (int)enemy.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (!Remove)
                koopaStateMachine.Update(gameTime);
            if (FacingLeft)
                Location += new Vector2(-1f, 0);
            else
                Location += new Vector2(1f, 0);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)enemy.Width, (int)enemy.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Remove)
                koopaStateMachine.Draw(spriteBatch, Location);
        }

        public void TakeDamage()
        {
            Dead = true;
            koopaStateMachine = new KoopaStateMachine(this);
            koopaStateMachine = new RemoveState(this, koopaStateMachine.Sprite, 100);
        }
        public void Reset() {
            Dead = false;
            koopaStateMachine = new KoopaStateMachine(this);
        }
    }
}
