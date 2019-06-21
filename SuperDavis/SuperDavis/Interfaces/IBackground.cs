using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperDavis.Interfaces
{
    interface IBackground
    { 
        Vector2 Location { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
