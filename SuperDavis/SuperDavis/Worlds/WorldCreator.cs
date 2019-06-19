using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.Object.Scenery;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SuperDavis.Worlds
{
    class WorldCreator
    {
        /*public class CoordsObjectTuple
        {
            int x;
            int y;
            IGameObject gameObject;

            public CoordsObjectTuple(int x, int y, IGameObject gameObject)
            {
                this.x = x;
                this.y = y;
                this.gameObject = gameObject;
            }
        }
        public CoordsObjectTuple ObjectMap;*/
        public IGameObject[,] ObjectMap;
        

        Dictionary<String, Action<IWorld, string, float, float>> objectDictionary;
        Dictionary<String, Action<float, float>> itemDictionary;
        Dictionary<String, Action<float, float>> blockDictionary;
        Dictionary<String, Action<float, float>> playerDictionary;
        Dictionary<String, Action<float, float>> enemyDictionary;
        Dictionary<String, Action<float, float>> backgroundDictionary;
        IWorld world;

        private void CreateObjectDictionary()
        {
            objectDictionary = new Dictionary<String, Action<IWorld, string, float, float>>
            {
                { "Character", CreateCharacter },
                { "Item", CreateItem },
                { "Block", CreateBlock },
                { "Enemy", CreateEnemy },
                { "Scenery", CreateBackground }
            };
        }

        private void CreateItemDictionary()
        {
            itemDictionary = new Dictionary<String, Action<float, float>>
            {
                { "Flower", (x, y) => world.Items.Add(new Flower(new Vector2(x, y))) },
                { "Coin", (x, y) => world.Items.Add(new Coin(new Vector2(x, y))) },
                { "Mushroom", (x, y) => world.Items.Add(new Mushroom(new Vector2(x, y))) },
                { "YoshiEgg", (x, y) => world.Items.Add(new YoshiEgg(new Vector2(x, y))) },
                { "Star", (x, y) => world.Items.Add(new Star(new Vector2(x, y))) }
            };
        }

        private void CreateBlockDictionary()
        {
            blockDictionary = new Dictionary<String, Action<float, float>>
            {
                { "HiddenBlock", (x, y) => world.Blocks.Add(new HiddenBlock(new Vector2(x, y))) },
                { "ActivatedBlock", (x, y) => world.Blocks.Add(new ActivatedBlock(new Vector2(x, y))) },
                { "Brick", (x, y) => world.Blocks.Add(new Brick(new Vector2(x, y))) },
                { "QuestionBlock", (x, y) => world.Blocks.Add(new QuestionBlock(new Vector2(x, y))) },
                { "Pipe", (x, y) => world.Blocks.Add(new Pipe(new Vector2(x, y))) },
                { "LeftGreenFloor", (x,y) => world.Blocks.Add(new LeftGreenFloor(new Vector2(x, y))) },
                { "MiddleGreenFloor", (x,y) => world.Blocks.Add(new MiddleGreenFloor(new Vector2(x, y))) },
                { "RightGreenFloor", (x,y) => world.Blocks.Add(new RightGreenFloor(new Vector2(x, y))) }
            };
        }

        private void CreateEnemyDictionary()
        {
            enemyDictionary = new Dictionary<String, Action<float, float>>
            {
                { "Goomba", (x, y) => world.Enemies.Add(new Goomba(new Vector2(x, y))) },
                { "Koopa", (x, y) => world.Enemies.Add(new Koopa(new Vector2(x, y))) }
            };
        }

        private void CreateBackgroundDictionary()
        {
            backgroundDictionary = new Dictionary<String, Action<float, float>>
            {
                { "Background", (x, y) => world.Backgrounds.Add(new Background(new Vector2(x, y))) }
            };
        }

        private void CreatePlayerDictionary()
        {
            playerDictionary = new Dictionary<String, Action<float, float>>
            {
                { "Davis", (x, y) => world.Davises.Add(new Davis(new Vector2(x, y))) }
            };
        }

        public IWorld CreateWorld(string levelFile, int width, int height)
        {
            ObjectMap = new IGameObject[Variables.Variable.WindowsEdgeWidth / Variables.Variable.UnitPixelSize][Variables.Variable.WindowsEdgeHeight / Variables.Variable.UnitPixelSize];
            return ParseAndLoad(levelFile, width, height);
        }

        private IWorld ParseAndLoad(string levelFile, int width, int height)
        {
            world = new World(width, height);
            CreateObjectDictionary();
            CreateItemDictionary();
            CreateBlockDictionary();
            CreateEnemyDictionary();
            CreatePlayerDictionary();
            CreateBackgroundDictionary();

            XmlReader reader = XmlReader.Create("Content/level/" + levelFile);
            reader.ReadToFollowing("Object");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    string objects = reader.Name;
                    string type = reader.GetAttribute("Type");
                    float x = float.Parse(reader.GetAttribute("X"));
                    float y = float.Parse(reader.GetAttribute("Y"));
                    CreateObjects(world, objects, type, x, y);
                    
                }
            }
            return world;
        }

        private void CreateObjects(IWorld worlds, string objects, string type, float x, float y)
        {
            objectDictionary.TryGetValue(objects, out Action<IWorld, string, float, float> buildObject);
            buildObject(worlds, type, x, y);
        }

        private void CreateCharacter(IWorld worlds, string type, float x, float y)
        {
            playerDictionary.TryGetValue(type, out Action<float, float> buildPlayer);
            buildPlayer(x, y);
        }

        private void CreateItem(IWorld worlds, string type, float x, float y)
        {
            itemDictionary.TryGetValue(type, out Action<float, float> buildItem);
            buildItem(x, y);
        }

        private void CreateBlock(IWorld worlds, string type, float x, float y)
        {
            blockDictionary.TryGetValue(type, out Action<float, float> buildBlock);
            buildBlock(x, y);
        }

        private void CreateEnemy(IWorld worlds, string type, float x, float y)
        {
            enemyDictionary.TryGetValue(type, out Action<float, float> buildEnemy);
            buildEnemy(x, y);
        }

        private void CreateBackground(IWorld worlds, string type, float x, float y)
        {
            backgroundDictionary.TryGetValue(type, out Action<float, float> buildBackground);
            buildBackground(x, y);
        }
    }
}
