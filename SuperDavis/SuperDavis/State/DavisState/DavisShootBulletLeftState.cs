using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisShootBulletLeftState : IDavisState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }
        private int specialAttackTimer;
        public DavisShootBulletLeftState(IDavis davis)
        {
            this.davis = davis;
            if (davis.DavisStatus == DavisStatus.Davis)
                specialAttackTimer = Variables.Variable.DavisShootBulletTimer;
            else if (davis.DavisStatus == DavisStatus.Woody)
                specialAttackTimer = Variables.Variable.WoodyShootBulletTimer;
            else if (davis.DavisStatus == DavisStatus.Bat)
                specialAttackTimer = Variables.Variable.BatShootBulletTimer;
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
        }

        public void Left()
        {

        }

        public void Right()
        {

        }

        public void Up() { }

        public void Down()
        {

        }

        public void Land()
        {
        }
        public void Death()
        {
            davis.DavisState = new DavisDeathLeftState(davis);
        }

        public void SpecialAttack()
        {
            davis.DavisState = new DavisSpecialAttackLeftState(davis);
        }

        public void ShootBullet()
        {

        }

        public void Update(GameTime gameTime)
        {
            davis.Sprite.Update(gameTime);
            if (specialAttackTimer == 0)
                davis.DavisState.Static();
            specialAttackTimer--;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            davis.Sprite.Draw(spriteBatch, location);
        }
    }
}
