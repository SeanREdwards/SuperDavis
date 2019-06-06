using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.ItemStateMachine
{
    class BrickStateMachine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ISprite Sprite;

        public BrickStateMachine(bool IsBroken)
        {
            if (!IsBroken)
            {
                Sprite = ItemSpriteFactory.Instance.CreateBrickBlock();
            }
            else
            {
                Sprite = ItemSpriteFactory.Instance.CreateEmptyBlock();              
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
