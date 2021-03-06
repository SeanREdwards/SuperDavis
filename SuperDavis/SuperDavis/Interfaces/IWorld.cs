﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperDavis.Interfaces
{
    interface IWorld
    {
        Game1 Game { get; set; }
        float Width { get; }
        float Height { get; }
        HUD HUD { get; set; }
        IList<IGameObject>[][] WorldGrid { get; set; }
        IDavis Characters { get; set; }
        IList<IEnemy> Enemies { get; set; }
        HashSet<IItem> Items { get; set; }
        HashSet<IBlock> Blocks { get; set; }
        HashSet<IProjectile> Projectiles { get; set; }
        HashSet<IBackground> Backgrounds { get; set; }
        HashSet<IGameObject> ObjectToRemove { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

        IGameObject GetObject(IGameObject @object, int i, int j);

        void AddObject(IGameObject @object);
        void DecoratorReplacement(IGameObject prevObject, IGameObject newObject);

        void ResetGame();
        void Clear();
    }
}
