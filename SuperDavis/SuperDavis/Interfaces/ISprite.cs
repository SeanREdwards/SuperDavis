using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperDavis.Interfaces
{
    interface ISprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        float Width { get;}
        float Height { get;}
    }
}
