using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using System.Collections.Generic;

namespace SuperDavis.Interfaces
{
    interface IWorld
    {
        int Width { get; set; }
        int Height { get; set; }
        IList<IDavis> Davises { get; set; }
        IList<IEnemy> Enemies { get; set; }
        IList<IItem> Items { get; set; }
        IList<IBlock> Blocks { get; set; }
        // May need it in the future
        //IList<IBackground> Backgrounds { get; set; }
        //IList<IProjectile> Projectiles { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void ResetGame();
    }
}
