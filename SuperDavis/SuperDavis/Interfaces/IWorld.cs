using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperDavis.Interfaces
{
    interface IWorld
    {
        float Width { get; }
        float Height { get; }

        IList<IGameObject>[][] WorldGrid { get; set; }
        HashSet<IDavis> Characters { get; set; }
        HashSet<IEnemy> Enemies { get; set; }
        HashSet<IItem> Items { get; set; }
        HashSet<IBlock> Blocks { get; set; }
        HashSet<IProjectile> Projectiles { get; set; }
        HashSet<IBackground> Backgrounds { get; set; }
        HashSet<IGameObject> ObjectToRemove { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

        void InitializeWorldGrid();
        IGameObject GetObject(IGameObject @object, int i, int j);

        void AddObject(IGameObject @object);

        void ResetGame();
    }
}
