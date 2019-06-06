using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class QuestionBlockStateMachine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public readonly ISprite Sprite;

        public QuestionBlockStateMachine(bool IsUsed)
        {
            if (!IsUsed)
            {
                Sprite = ItemSpriteFactory.Instance.CreateQuestionMarkBlockAnimated();
            }
            else
            {
                Sprite = ItemSpriteFactory.Instance.CreateActivatedBlock();
            }
            Width = Sprite.Width;
            Height = Sprite.Height;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
