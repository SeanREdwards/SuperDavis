using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.State.ItemStateMachine
{
    class QuestionBlockStateMachine
    {
        private readonly ISprite sprite;

        public QuestionBlockStateMachine(bool IsUsed)
        {
            if (!IsUsed)
            {
                sprite = ItemSpriteFactory.Instance.CreateQuestionMarkBlockAnimated();
            }
            else
            {
                sprite = ItemSpriteFactory.Instance.CreateActivatedBlock();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
