using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using SuperDavis.Sound;
using System;

namespace SuperDavis.State.EnemyState
{
    class JulianPowerPunchState : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }

        private int timer = Variables.Variable.JulianPowerPunchTimer;

        private readonly Julian julian;
        public JulianPowerPunchState(ISprite sprite, Julian julian)
        {
            this.Sprite = sprite;
            this.julian = julian;
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            timer--;

            if (timer % 24 == 0)
            {
                Sounds.Instance.PlayJulianShootBullet();
                Random random = new Random();
                julian.JulianProjectile.Clear();
                julian.JulianProjectile.Add(new JulianProjectile(julian.Location + new Vector2(0, 30f + random.Next(10)), julian.FacingDirection));
                julian.World.AddObject(julian.JulianProjectile[0]);
                julian.JulianProjectile.RemoveAt(0);
            }
            if (timer == 0)
            {
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
