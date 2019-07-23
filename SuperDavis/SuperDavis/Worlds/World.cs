using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Collision;
using SuperDavis.Interfaces;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.Physics;
using SuperDavis.Sound;
using System;
using System.Collections.Generic;
using static SuperDavis.Object.Character.Davis;

namespace SuperDavis.Worlds
{
    class World : IWorld
    {
        public float Width { get; }
        public float Height { get; }

        public IList<IGameObject>[][] WorldGrid { get; set; }
        public HashSet<IGameObject> ObjectToRemove { get; set; }

        public IDavis Characters { get; set; }
        public HashSet<IItem> Items { get; set; }
        public HashSet<IBlock> Blocks { get; set; }
        public IList<IEnemy> Enemies { get; set; }
        public HashSet<IProjectile> Projectiles { get; set; }
        public HashSet<IBackground> Backgrounds { get; set; }

        private readonly Game1 game;
        public float UNIT_SIZE = Variables.Variable.UnitPixelSize;
        public int WorldGridWidth, WorldGridHeight;

        public World(float width, float height, Game1 game)
        {
            Width = width;
            Height = height;
            this.game = game;

            /* Initialize WorldGrid - 2 Dimensional Array */
            WorldGridWidth = (int)(Width / UNIT_SIZE);
            WorldGridHeight = (int)(Height / UNIT_SIZE);
            WorldGrid = new List<IGameObject>[WorldGridWidth][];
            for (int i = 0; i < WorldGridWidth; i++)
            {
                WorldGrid[i] = new List<IGameObject>[WorldGridHeight];
            }
            for (int i = 0; i < WorldGridWidth; i++)
                for (int j = 0; j < WorldGridHeight; j++)
                    WorldGrid[i][j] = new List<IGameObject>();

            /* Lists Initialization */
            //Characters = new List<IDavis>();
            Items = new HashSet<IItem>();
            Blocks = new HashSet<IBlock>();
            Enemies = new List<IEnemy>();
            Projectiles = new HashSet<IProjectile>();
            Backgrounds = new HashSet<IBackground>();
            ObjectToRemove = new HashSet<IGameObject>();

            //Play Level Music
            Sounds.Instance.MusicInstance.Play();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IBackground background in Backgrounds)
                background.Update(gameTime);
            Characters.Update(gameTime);
            foreach (IItem item in Items)
                item.Update(gameTime);
            foreach (IBlock block in Blocks)
                block.Update(gameTime);
            foreach (IProjectile projectile in Projectiles)
            {
                projectile.Update(gameTime);
                if (projectile.IsExploded)
                {
                    var davis = Characters;
                    if (davis.DavisProjectile.Count < 3)
                        davis.DavisProjectile.Add(new BatProjectile(Characters.Location - new Vector2(0, 30f), Characters.FacingDirection));
                    ObjectToRemove.Add(projectile);
                }
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update(gameTime);
                EnemyAI(enemy);
            }

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
            if (Characters != null)
                Characters.Draw(spriteBatch);
        }

        public void RemoveObject()
        {
            foreach (IGameObject removeObject in ObjectToRemove)
            {
                if (removeObject is IDavis)
                    Characters = null;
                if (removeObject is IItem)
                    Items.Remove((IItem)removeObject);
                if (removeObject is IBlock)
                    Blocks.Remove((IBlock)removeObject);
                if (removeObject is IEnemy)
                    Enemies.Remove((IEnemy)removeObject);
                if (removeObject is IProjectile)
                    Projectiles.Remove((IProjectile)removeObject);

                /* Check remove items in World Grid*/
                WorldGrid[(int)(removeObject.Location.X / UNIT_SIZE)][(int)(removeObject.Location.Y / UNIT_SIZE)].Remove(removeObject);
            }
            ObjectToRemove.Clear();
        }

        public IGameObject GetObject(IGameObject @object, int i, int j)
        {
            var k = WorldGrid[i][j].IndexOf(@object);
            if ( k > -1)
                return WorldGrid[i][j][k];                
            else
                return null;            
        }

        public void AddObject(IGameObject @object)
        {
            //Code to add object          
            if (@object is IDavis)
                Characters = (Davis)@object;
            if (@object is IItem)
                Items.Add(@object as IItem);
            if (@object is IEnemy)
                Enemies.Add(@object as IEnemy);
            if (@object is IBlock)
                Blocks.Add(@object as IBlock);
            if (@object is IProjectile)
                Projectiles.Add(@object as IProjectile);

            var i = (int)(@object.Location.X / UNIT_SIZE);
            var j = (int)(@object.Location.Y / UNIT_SIZE);

            if (i == -1 && j >= 0 && j <= WorldGridHeight )
                WorldGrid[0][j].Add(@object);
            else if (!IsIndexOutOfBounds(i, j))
                WorldGrid[i][j].Add(@object);

            @object.OnPositionChanged += Object_OnPositionChanged;
        }

        private void Object_OnPositionChanged(object sender, Tuple<Vector2, Vector2> e)
        {
            var @object = (sender as IGameObject);
            // Change the position of the obj in the world grid
            var oldLocationX = (int)(e.Item1.X / UNIT_SIZE);
            var oldLocationY = (int)(e.Item1.Y / UNIT_SIZE);
            var newLocationX = (int)(e.Item2.X / UNIT_SIZE);
            var newLocationY = (int)(e.Item2.Y / UNIT_SIZE);
            if (!IsIndexOutOfBounds(oldLocationX, oldLocationY))
                if (!IsIndexOutOfBounds(newLocationX, newLocationY))
                {
                    if (newLocationX != oldLocationX || newLocationY != oldLocationY)
                    {
                        WorldGrid[oldLocationX][oldLocationY].Remove(@object);
                        WorldGrid[newLocationX][newLocationY].Add(@object);
                    }
                }
                else
                    WorldGrid[oldLocationX][oldLocationY].Remove(@object);

        }

        public void DecoratorReplacement(IGameObject prevObject, IGameObject newObject)
        {
            var LocationX = (int)(prevObject.Location.X / UNIT_SIZE);
            var LocationY = (int)(prevObject.Location.Y / UNIT_SIZE);
            WorldGrid[LocationX][LocationY].Remove(prevObject);
            WorldGrid[LocationX][LocationY].Add(newObject);

            prevObject.OnPositionChanged -= Object_OnPositionChanged;
            newObject.OnPositionChanged += Object_OnPositionChanged;
        }

        public void ResetGame()
        {
            Characters = null;
            Blocks.Clear();
            Enemies.Clear();
            Items.Clear();
            Projectiles.Clear();
            Backgrounds.Clear();
            ObjectToRemove.Clear();
            for (int i = 0; i < WorldGridWidth; i++)
                for (int j = 0; j < WorldGridHeight; j++)
                    if (WorldGrid[i][j].Count > 0)
                        WorldGrid[i][j].Clear();

            WorldCreator worldCreator = new WorldCreator();
            game.World = worldCreator.CreateWorld(Variables.Variable.LevelOne, Variables.Variable.level11Width, Variables.Variable.level11Height, game);
            game.collisionDetection = new CollisionDetection(game.World);
            game.InitializeController();
        }

        public bool IsIndexOutOfBounds(int x, int y)
        {
            return !(x >= 0 && x < WorldGridWidth && y >= 0 && y < WorldGridHeight);
        }

        /* Enemy AI Helper Class */
        public void EnemyAI(IEnemy enemy)
        {
            if (enemy is Koopa && Math.Abs(Characters.Location.X - enemy.Location.X) < 200 && !(enemy.PhysicsState is JumpState) && !(enemy.PhysicsState is FallState) && !enemy.Dead)
                enemy.Jump();
        }
    }
}
