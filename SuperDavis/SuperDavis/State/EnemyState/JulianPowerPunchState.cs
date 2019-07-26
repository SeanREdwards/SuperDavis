using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;

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
            if (timer == 0)
                julian.Walk();
                
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
