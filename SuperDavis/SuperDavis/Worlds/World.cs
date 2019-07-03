using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Collision;
using SuperDavis.Interfaces;
using System.Collections.Generic;

namespace SuperDavis.Worlds
{
    class World : IWorld
    {
        public IList<IGameObject>[][] WorldGrid { get; set; }
        public IList<IGameObject> ObjectToRemove { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IList<IDavis> Characters { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IBlock> Blocks { get; set; }
        public IList<IEnemy> Enemies { get; set; }
        public IList<IProjectile> Projectiles { get; set; }
        public IList<IBackground> Backgrounds { get; set; }

        private readonly Game1 game;

        public World(float width, float height, Game1 game)
        {
            Width = width;
            Height = height;
            this.game = game;
            /* Initialize WorldGrid - 2 Dimensional Array */
            WorldGrid = new IList<IGameObject>[(int)Width / Variables.Variable.UnitPixelSize][]; 
            // i = 200; j = 27
            for(int i = 0; i < (int)Width / Variables.Variable.UnitPixelSize; i++)
            {
                WorldGrid[i] = new List<IGameObject>[(int)Height / Variables.Variable.UnitPixelSize];
            }
            for (int i = 0; i < WorldGrid.Length; i++)
                for (int j = 0; j < WorldGrid[i].Length; j++)
                    WorldGrid[i][j] = new List<IGameObject>();

            /* Lists Initialization */
            Characters = new List<IDavis>();
            Items = new List<IItem>();
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemy>();
            Projectiles = new List<IProjectile>();
            Backgrounds = new List<IBackground>();
            ObjectToRemove = new List<IGameObject>();
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

            if (ObjectToRemove.Count != 0)
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
                    if( i == (int) item.Location.X / Variables.Variable.UnitPixelSize)
                    {
                        var j = (int) item.Location.Y / Variables.Variable.UnitPixelSize;
                        WorldGrid[i][j].Add(item);
                    }
                foreach (IBlock block in Blocks)
                    if (i == (int) block.Location.X / Variables.Variable.UnitPixelSize)
                    {
                        
                        var j = (int) block.Location.Y / Variables.Variable.UnitPixelSize;                  
                        WorldGrid[i][j].Add(block);
                    }
                foreach (IProjectile projectile in Projectiles)
                    if (i == (int) projectile.Location.X / Variables.Variable.UnitPixelSize)
                    {
                        var j = (int) projectile.Location.Y / Variables.Variable.UnitPixelSize;
                        WorldGrid[i][j].Add(projectile);
                    }
                foreach (IEnemy enemy in Enemies)
                    if (i == (int) enemy.Location.X / Variables.Variable.UnitPixelSize)
                    {
                        var j = (int) enemy.Location.Y / Variables.Variable.UnitPixelSize;
                        WorldGrid[i][j].Add(enemy);
                    }
                foreach (IDavis character in Characters)
                    if (i == (int) character.Location.X / Variables.Variable.UnitPixelSize)
                    {
                        var j = (int) character.Location.Y / Variables.Variable.UnitPixelSize;
                        WorldGrid[i][j].Add(character);                       
                    }
            }
            for (int i = 0; i < WorldGrid.Length; i++)
                for (int j = 0; j < WorldGrid[i].Length; j++)
                {
                    if(WorldGrid[i][j].Count>0)
                    System.Console.WriteLine(WorldGrid[i][j][0]);
                }
                    
                    
        }

        public void RemoveObject()
        {
            foreach(IGameObject removeObject in ObjectToRemove)
            {
                if(removeObject is IDavis)
                    Characters.Remove((IDavis)removeObject);
                else if (removeObject is IItem)
                    Items.Remove((IItem)removeObject);
                else if (removeObject is IBlock)
                    Blocks.Remove((IBlock)removeObject);
                else if (removeObject is IEnemy)
                    Enemies.Remove((IEnemy)removeObject);
                else if (removeObject is IProjectile)
                    Projectiles.Remove((IProjectile)removeObject);

                /* Check remove items in World Grid*/
                for(int i = 0; i < WorldGrid.Length; i++)
                    for(int j = 0; j < WorldGrid[i].Length; j++)
                    {
                        var index = WorldGrid[i][j].IndexOf(removeObject);
                        if (index > -1)
                            WorldGrid[i][j].RemoveAt(index);
                    }
            }
            ObjectToRemove.Clear();
        }

        public void AddObject<T>(T @object) where T : IGameObject
        {
            //Code to add object



            @object.OnPositionChanged += object_OnPositionChanged;
        }

        private void object_OnPositionChanged(object sender, System.EventArgs e)
        {
            var @object = (sender as IGameObject);

            //Code to change position in array
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
