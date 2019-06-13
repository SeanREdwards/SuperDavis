using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class QuestionBlockStateMachine : IGameState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ISprite Sprite { get; set; }

        public QuestionBlockStateMachine(bool isUsed)
        {
            if (!isUsed)
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
