using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;
using SuperDavis.Physics;

namespace SuperDavis.State.EnemyState
{
    class JulianMetaAttackState : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

        private int timer;

        private readonly Julian julian;
        public JulianMetaAttackState(ISprite sprite, Julian julian)
        {
            timer = Variables.Variable.JulianMetaAttackTimer;
            this.Sprite = sprite;
            this.julian = julian;
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            timer--;
            if (timer <= 0)
            {
                julian.Location += new Vector2(0, 487f);
                julian.PhysicsState = new StandingState(julian);
                if (julian.FacingDirection == FacingDirection.Left)
                {
                    julian.Sprite = EnemySpriteFactory.Instance.CreateJulianWalkLeft();
                }
                else
                {
                    julian.Sprite = EnemySpriteFactory.Instance.CreateJulianWalkRight();
                }
                julian.JulianStateMachine = new JulianStateMachine(julian.Sprite);
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
