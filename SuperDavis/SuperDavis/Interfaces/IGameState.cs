using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperDavis.Interfaces
{
    interface IGameState
    {
        int Width { get; set; }
        int Height { get; set; }
        ISprite Sprite { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
