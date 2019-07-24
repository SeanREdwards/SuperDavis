using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;

namespace SuperDavis.State.OtherState
{
    class RemoveState : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }
        private readonly IGameObject gameObject;
        private readonly ISprite sprite;
        private int timer;

        public RemoveState(IGameObject gameObject, ISprite sprite, int timer)
        {
            // GameObject to help change other properties for g.o. for the future use
            this.gameObject = gameObject;
            this.sprite = sprite;
            this.timer = timer;
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            sprite.Update(gameTime);
            if (timer > Variables.Variable.RemovalTimerCeiling)
                gameObject.Location += new Vector2(0, Variables.Variable.RemovalOffsetDown);
            else
                gameObject.Location += new Vector2(0, Variables.Variable.RemovalOffsetUp);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (timer >= 0)
            {
                sprite.Draw(spriteBatch, location);
            }
        }
    }
}
