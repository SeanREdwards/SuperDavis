using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperDavis.Interfaces
{
    interface IWorld
    {
        float Width { get; set; }
        float Height { get; set; }
        IList<IDavis> Davises { get; set; }
        IList<IEnemy> Enemies { get; set; }
        IList<IItem> Items { get; set; }
        IList<IBlock> Blocks { get; set; }
        IList<IBackground> Backgrounds { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void ResetGame();
    }
}
