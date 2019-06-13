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
        //public IGameObject[][] LocationMap;

        Dictionary<String, Action<IWorld, string, float, float>> objectDictionary;
        Dictionary<String, Action<float, float>> itemDictionary;
        Dictionary<String, Action<float, float>> blockDictionary;
        Dictionary<String, Action<float, float>> playerDictionary;
        Dictionary<String, Action<float, float>> enemyDictionary;
        Dictionary<String, Action<float, float>> backgroundDictionary;
        IWorld world;

        private void CreateObjectDictionary()
        {
            objectDictionary = new Dictionary<String, Action<IWorld, string, float, float>>();
            //objectDictionary.Add("Level", Create);
            objectDictionary.Add("Character", CreateCharacter);
            objectDictionary.Add("Item", CreateItem);
            objectDictionary.Add("Block", CreateBlock);
            objectDictionary.Add("Enemy", CreateEnemy);
            objectDictionary.Add("Scenery", CreateBackground);
        }

        private void CreateItemDictionary()
        {
            itemDictionary = new Dictionary<String, Action<float, float>>();
            itemDictionary.Add("Flower", (x,y) => world.Items.Add(new Flower(new Vector2(x, y))));
            itemDictionary.Add("Coin", (x,y) => world.Items.Add(new Coin(new Vector2(x, y))));
            itemDictionary.Add("Mushroom", (x, y) => world.Items.Add(new Mushroom(new Vector2(x, y))));
            itemDictionary.Add("YoshiEgg", (x, y) => world.Items.Add(new YoshiEgg(new Vector2(x, y))));
            itemDictionary.Add("Star", (x, y) => world.Items.Add(new Star(new Vector2(x, y))));
        }

        private void CreateBlockDictionary()
        {
            blockDictionary = new Dictionary<String, Action<float, float>>();
            blockDictionary.Add("HiddenBlock", (x, y) => world.Blocks.Add(new HiddenBlock(new Vector2(x, y))));
            blockDictionary.Add("ActivatedBlock", (x, y) => world.Blocks.Add(new ActivatedBlock(new Vector2(x, y))));
            blockDictionary.Add("Brick", (x, y) => world.Blocks.Add(new Brick(new Vector2(x, y))));
            blockDictionary.Add("QuestionBlock", (x, y) => world.Blocks.Add(new QuestionBlock(new Vector2(x, y))));
            blockDictionary.Add("Pipe", (x, y) => world.Blocks.Add(new Pipe(new Vector2(x, y))));
        }

        private void CreateEnemyDictionary()
        {
            enemyDictionary = new Dictionary<String, Action<float, float>>();
            enemyDictionary.Add("Goomba", (x, y) => world.Enemies.Add(new Goomba(new Vector2(x, y))));
            enemyDictionary.Add("Koopa", (x, y) => world.Enemies.Add(new Koopa(new Vector2(x, y))));
        }

        private void CreateBackgroundDictionary()
        {
            backgroundDictionary = new Dictionary<String, Action<float, float>>();
            backgroundDictionary.Add("Background", (x, y) => world.Backgrounds.Add(new Background(new Vector2(x, y))));
        }

        private void CreatePlayerDictionary()
        {
            playerDictionary = new Dictionary<String, Action<float, float>>();
            playerDictionary.Add("Davis", (x, y) => world.Davises.Add(new Davis(new Vector2(x, y))));
        }

        public IWorld CreateWorld(string levelFile, int width, int height)
        {
            return ParseAndLoad(levelFile, width, height);
        }

        /* private IWorld ParseAndLoad(string levelFile, int width, int height, Game1 game)
         {
             world = new World(width, height, game);
             CreateObjectDictionary();
             CreateItemDictionary();
             CreateBlockDictionary();
             CreateEnemyDictionary();
             CreatePlayerDictionary();
             CreateBackgroundDictionary();

             XmlReader reader = XmlReader.Create("Content/level/" + levelFile);
             while (reader.Read())
             {
                 if (reader.NodeType == XmlNodeType.Element)
                 {
                     string objects = reader.Name;
                     string type = reader.GetAttribute("Type");
                    float x = float.Parse(reader.GetAttribute("X"));
                    float y = float.Parse(reader.GetAttribute("Y"));
                     if(objects.Contains("Level"))
                     {

                     }
                     else
                     {
                         CreateObjects(world, objects, type, x, y);
                     }
                 }
             }
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
         }*/

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
            Action<IWorld, string, float, float> buildObject;
            objectDictionary.TryGetValue(objects, out buildObject);
            buildObject(worlds, type, x, y);
        }

        private void CreateCharacter(IWorld worlds, string type, float x, float y)
        {
            Action<float, float> buildPlayer;
            playerDictionary.TryGetValue(type, out buildPlayer);
            buildPlayer(x, y);
        }

        private void CreateItem(IWorld worlds, string type, float x, float y)
        {
            Action<float, float> buildItem;
            itemDictionary.TryGetValue(type, out buildItem);
            buildItem(x, y);
        }

        private void CreateBlock(IWorld worlds, string type, float x, float y)
        {
            Action<float, float> buildBlock;
            blockDictionary.TryGetValue(type, out buildBlock);
            buildBlock(x, y);
        }

        private void CreateEnemy(IWorld worlds, string type, float x, float y)
        {
            Action<float, float> buildEnemy;
            enemyDictionary.TryGetValue(type, out buildEnemy);
            buildEnemy(x, y);
        }

        private void CreateBackground(IWorld worlds, string type, float x, float y)
        {
            Action<float, float> buildBackground;
            backgroundDictionary.TryGetValue(type, out buildBackground);
            buildBackground(x, y);
        }
    }
}
