using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using System.Collections.Generic;

namespace SuperDavis.Interfaces
{
    interface IWorldCreator
    {
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
        
        /* For command control and reset*/
        Davis davis { get; set; }
        HiddenBlock hiddenBlock { get; set; }
        QuestionBlock questionBlock { get; set; }
        Brick brick { get; set; }
    }
}
