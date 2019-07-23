using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.Object.Scenery;
using SuperDavis.Object.SpawnPoint;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SuperDavis.Worlds
{
    class WorldCreator
    {   
        Dictionary<String, Action<IWorld, string, float, float>> objectDictionary;
        Dictionary<String, Action<float, float>> itemDictionary;
        Dictionary<String, Action<float, float>> blockDictionary;
        Dictionary<String, Action<float, float>> playerDictionary;
        Dictionary<String, Action<float, float>> enemyDictionary;
        Dictionary<String, Action<float, float>> backgroundDictionary;
        IWorld world;

    

        // Need to get rid of string classifier
        private void CreateObjectDictionary()
        {
            objectDictionary = new Dictionary<String, Action<IWorld, string, float, float>>
            {
                { Variables.Variable.Character, CreateCharacter },
                { Variables.Variable.Item, CreateItem },
                { Variables.Variable.Block, CreateBlock },
                { Variables.Variable.Enemy, CreateEnemy },
                { Variables.Variable.Scenery, CreateBackground }
            };
        }

        private void CreateItemDictionary()
        {
            itemDictionary = new Dictionary<String, Action<float, float>>
            {
                { nameof(Flower), (x, y) => world.AddObject(new Flower(new Vector2(x, y))) },
                { nameof(Coin), (x, y) => world.AddObject(new Coin(new Vector2(x, y))) },
                { nameof(Mushroom), (x, y) => world.AddObject(new Mushroom(new Vector2(x, y))) },
                { nameof(YoshiEgg), (x, y) => world.AddObject(new YoshiEgg(new Vector2(x, y))) },
                { nameof(Star), (x, y) => world.AddObject(new Star(new Vector2(x, y))) }
            };
        }

        private void CreateBlockDictionary()
        {
            blockDictionary = new Dictionary<String, Action<float, float>>
            {
                { nameof(HiddenBlock), (x, y) => world.AddObject(new HiddenBlock(new Vector2(x, y))) },
                { nameof(ActivatedBlock), (x, y) => world.AddObject(new ActivatedBlock(new Vector2(x, y))) },
                { nameof(MushroomBlock), (x, y) => world.AddObject(new MushroomBlock(new Vector2(x, y))) },
                { nameof(CoinBlock), (x, y) => world.AddObject(new CoinBlock(new Vector2(x, y))) },
                { nameof(StarBlock), (x, y) => world.AddObject(new StarBlock(new Vector2(x, y))) },
                { nameof(FlowerBlock), (x, y) => world.AddObject(new FlowerBlock(new Vector2(x, y))) },
                { nameof(Brick), (x, y) => world.AddObject(new Brick(new Vector2(x, y))) },
                { nameof(CoinBrick), (x, y) => world.AddObject(new CoinBrick(new Vector2(x, y))) },
                { nameof(QuestionBlock), (x, y) => world.AddObject(new QuestionBlock(new Vector2(x, y))) },
                { nameof(Pipe), (x, y) => world.AddObject(new Pipe(new Vector2(x, y))) },
                { nameof(LeftGreenFloor), (x,y) => world.AddObject(new LeftGreenFloor(new Vector2(x, y))) },
                { nameof(MiddleGreenFloor), (x,y) => world.AddObject(new MiddleGreenFloor(new Vector2(x, y))) },
                { nameof(RightGreenFloor), (x,y) => world.AddObject(new RightGreenFloor(new Vector2(x, y))) },
                { nameof(CastleBlock), (x,y) => world.AddObject(new CastleBlock(new Vector2(x, y))) },
                { nameof(GoombaSpawnPoint), (x,y) => world.AddObject(new GoombaSpawnPoint(new Vector2(x, y), world)) },
                { nameof(EmptyBlock), (x,y) => world.AddObject(new EmptyBlock(new Vector2(x, y))) },

            };
        }

        private void CreateEnemyDictionary()
        {
            enemyDictionary = new Dictionary<String, Action<float, float>>
            {
                { nameof(Goomba), (x, y) => world.AddObject(new Goomba(new Vector2(x, y), FacingDirection.Left))},
                { nameof(Koopa), (x, y) => world.AddObject(new Koopa(new Vector2(x, y))) }
            };
        }

        private void CreatePlayerDictionary()
        {
            playerDictionary = new Dictionary<String, Action<float, float>>
            {
                { nameof(Davis), (x, y) => world.AddObject(new Davis(new Vector2(x, y))) }
            };
        }

        private void CreateBackgroundDictionary()
        {
            backgroundDictionary = new Dictionary<String, Action<float, float>>
            {
                {nameof(Background), (x, y) => world.Backgrounds.Add(new Background(new Vector2(x, y))) },
                {nameof(GhostHouseAnimated), (x, y) => world.Backgrounds.Add(new GhostHouseAnimated(new Vector2(x, y))) }

            };
        }

        public IWorld CreateWorld(string levelFile, float width, float height, Game1 game)
        {
            IWorld worldObject = ParseAndLoad(levelFile, width, height, game);
            //world.InitializeWorldGrid();
            return worldObject;
        }

        private IWorld ParseAndLoad(string levelFile, float width, float height, Game1 game)
        {
            world = new World(width, height, game);
            CreateObjectDictionary();
            CreateItemDictionary();
            CreateBlockDictionary();
            CreateEnemyDictionary();
            CreatePlayerDictionary();
            CreateBackgroundDictionary();
            // Start to read xml file
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
