using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Collision;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using static SuperDavis.Object.Character.Davis;

namespace SuperDavis.Worlds
{
    class World : IWorld
    {
        public float Width { get; }
        public float Height { get; }

        public HashSet<IGameObject>[][] WorldGrid { get; set; }
        public HashSet<IGameObject> ObjectToRemove { get; set; }
        public HashSet<IDavis> Characters { get; set; }
        public HashSet<IItem> Items { get; set; }
        public HashSet<IBlock> Blocks { get; set; }
        public HashSet<IEnemy> Enemies { get; set; }
        public HashSet<IProjectile> Projectiles { get; set; }
        public HashSet<IBackground> Backgrounds { get; set; }

        private readonly Game1 game;
        public int UNIT_SIZE = Variables.Variable.UnitPixelSize;
        public int WorldGridWidth, WorldGridHeight;

        public World(float width, float height, Game1 game)
        {
            Width = width;
            Height = height;
            this.game = game;

            /* Initialize WorldGrid - 2 Dimensional Array */
            WorldGridWidth = (int)Width / UNIT_SIZE;
            WorldGridHeight = (int)Height / UNIT_SIZE;
            WorldGrid = new HashSet<IGameObject>[WorldGridWidth][];
            for (int i = 0; i < WorldGridWidth; i++)
            {
                WorldGrid[i] = new HashSet<IGameObject>[WorldGridHeight];
            }
            for (int i = 0; i < WorldGridWidth; i++)
                for (int j = 0; j < WorldGridHeight; j++)
                    WorldGrid[i][j] = new HashSet<IGameObject>();

            /* Lists Initialization */
            Characters = new HashSet<IDavis>();
            Items = new HashSet<IItem>();
            Blocks = new HashSet<IBlock>();
            Enemies = new HashSet<IEnemy>();
            Projectiles = new HashSet<IProjectile>();
            Backgrounds = new HashSet<IBackground>();
            ObjectToRemove = new HashSet<IGameObject>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IBackground background in Backgrounds)
                background.Update(gameTime);
            foreach (IDavis character in Characters)
                character.Update(gameTime);
            foreach (IItem item in Items)
                item.Update(gameTime);
            foreach (IBlock block in Blocks)
                block.Update(gameTime);
            foreach (IProjectile projectile in Projectiles)
                projectile.Update(gameTime);
            foreach (IEnemy enemy in Enemies)
                enemy.Update(gameTime);

            if (ObjectToRemove.Count > 0)
                RemoveObject();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBackground background in Backgrounds)
                background.Draw(spriteBatch);
            foreach (IItem item in Items)
                item.Draw(spriteBatch);
            foreach (IBlock block in Blocks)
                block.Draw(spriteBatch);
            foreach (IProjectile projectile in Projectiles)
                projectile.Draw(spriteBatch);
            foreach (IEnemy enemy in Enemies)
                enemy.Draw(spriteBatch);
            foreach (IDavis character in Characters)
                character.Draw(spriteBatch);
        }

        public void InitializeWorldGrid()
        {
            for (int i = 0; i < WorldGrid.Length; i++)
            {
                foreach (IItem item in Items)
                    if (i == (int)item.Location.X / UNIT_SIZE)
                    {
                        var j = (int)item.Location.Y / UNIT_SIZE;
                        WorldGrid[i][j].Add(item);
                    }
                foreach (IBlock block in Blocks)
                    if (i == (int)block.Location.X / UNIT_SIZE)
                    {

                        var j = (int)block.Location.Y / UNIT_SIZE;
                        WorldGrid[i][j].Add(block);
                    }
                foreach (IProjectile projectile in Projectiles)
                    if (i == (int)projectile.Location.X / UNIT_SIZE)
                    {
                        var j = (int)projectile.Location.Y / UNIT_SIZE;
                        WorldGrid[i][j].Add(projectile);
                    }
                foreach (IEnemy enemy in Enemies)
                    if (i == (int)enemy.Location.X / UNIT_SIZE)
                    {
                        var j = (int)enemy.Location.Y / UNIT_SIZE;
                        WorldGrid[i][j].Add(enemy);
                    }
                foreach (IDavis character in Characters)
                    if (i == (int)character.Location.X / UNIT_SIZE)
                    {
                        var j = (int)character.Location.Y / UNIT_SIZE;
                        WorldGrid[i][j].Add(character);
                    }
            }

        }

        public void RemoveObject()
        {
            foreach (IGameObject removeObject in ObjectToRemove)
            {
                if (removeObject is IDavis)
                    Characters.Remove((IDavis)removeObject);
                if (removeObject is IItem)
                    Items.Remove((IItem)removeObject);
                if (removeObject is IBlock)
                    Blocks.Remove((IBlock)removeObject);
                if (removeObject is IEnemy)
                    Enemies.Remove((IEnemy)removeObject);
                if (removeObject is IProjectile)
                    Projectiles.Remove((IProjectile)removeObject);

                /* Check remove items in World Grid*/
                for (int i = 0; i < WorldGrid.Length; i++)
                    for (int j = 0; j < WorldGrid[i].Length; j++)
                        if (WorldGrid[i][j].Contains(removeObject))
                            WorldGrid[i][j].Remove(removeObject);
            }
            ObjectToRemove.Clear();
        }

        public IGameObject GetObject(IGameObject @object, int i, int j)
        {
            if (WorldGrid[i][j].TryGetValue(@object, out IGameObject returnObject))
                return returnObject;                
            else
                return null;            
        }

        public void AddObject(IGameObject @object)
        {
            //Code to add object
            if (@object is IDavis)
                Characters.Add(@object as IDavis);



            @object.OnPositionChanged += object_OnPositionChanged;
        }

        private void object_OnPositionChanged(object sender, Vector2 e)
        {
            var @object = (sender as IGameObject);
            // Change the position of the obj in the world grid
            var i = (int)(e.X / UNIT_SIZE);
            var j = (int)(e.Y / UNIT_SIZE);
            WorldGrid[i][j].Remove(@object);

            // Code to add new position in the WorldGrid
            i = (int)(@object.Location.X / UNIT_SIZE);
            j = (int)(@object.Location.Y / UNIT_SIZE);
            WorldGrid[i][j].Add(@object);
        }

        public void ResetGame()
        {
            Characters.Clear();
            Blocks.Clear();
            Enemies.Clear();
            Items.Clear();
            Projectiles.Clear();
            Backgrounds.Clear();
            ObjectToRemove.Clear();
            WorldGrid.Initialize();
            WorldCreator worldCreator = new WorldCreator();
            game.World = worldCreator.CreateWorld("level1-1.xml", Variables.Variable.WindowsEdgeWidth, Variables.Variable.WindowsEdgeHeight, game);
            game.collisionDetection = new CollisionDetection(game.World);
            game.InitializeController();
        }
    }
}
