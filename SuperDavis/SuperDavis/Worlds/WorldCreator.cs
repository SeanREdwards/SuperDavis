using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using SuperDavis.Object.Scenery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SuperDavis.Worlds
{
    class WorldCreator
    {
        static Dictionary<String, Action<IWorld, string, float, float>> objectDictionary;
        static Dictionary<String, Action<IWorld, string, float, float>> itemDictionary;
        static Dictionary<String, Action<IWorld, string, float, float>> characterDictionary;
        static Dictionary<String, Action<IWorld, string, float, float>> enemyDictionary;

        public WorldCreator(){
        }

        private static Dictionary <String, Action<IWorld, string, float, float>> CreateObjectDictionary(){
            Dictionary<String, Action<IWorld, string, float, float>> objDictionary = new Dictionary<String, Action<IWorld, string, float, float>>();
            objDictionary.Add("Character", CreateCharacter);
            objDictionary.Add("Item", CreateItem);
            objDictionary.Add("Block", CreateBlock);
            objDictionary.Add("Enemy", CreateEnemy);
            objDictionary.Add("Scenery", CreateBackground);
            return objDictionary;
        }

        private static Dictionary<String, Action <IWorld>> CreateItemDictionary()
        {
            Dictionary<String, Action <IWorld>> itemDictionary = new Dictionary<String, Action <IWorld>>();
            //itemDictionary.Add("Flower", );
            //world.Items.Add(new Flower(new Vector2(x, y)));
            return itemDictionary;
        }


        public static IWorld CreateWorld(string levelFile, int width, int height, Game1 game)
        {
            return ParseAndLoad(levelFile, width, height, game);
        }

        private static IWorld ParseAndLoad(string levelFile, int width, int height, Game1 game)
        {
            IWorld world = new World(width,height,game);
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

        private static void CreateObjects(IWorld world, string objects, string type, float x, float y)
        {
            objectDictionary = CreateObjectDictionary();
            Action<IWorld, string, float, float> buildObject;
            objectDictionary.TryGetValue(objects, out buildObject);
            buildObject(world, type, x, y);
        }

        private static void CreateCharacter(IWorld world, string type, float x, float y)
        {
            switch (type)
            {
                case nameof(Davis):
                    world.Davises.Add(new Davis(new Vector2(x, y)));
                    break;
                default:
                    break;
            }

        }

        private static void CreateItem(IWorld world, string type, float x, float y)
        {
            switch (type)
            {
                case nameof(Flower):
                    world.Items.Add(new Flower(new Vector2(x, y)));
                    break;
                case nameof(Coin):
                    world.Items.Add(new Coin(new Vector2(x, y)));
                    break;
                case nameof(Mushroom):
                    world.Items.Add(new Mushroom(new Vector2(x, y)));
                    break;
                case nameof(YoshiEgg):
                    world.Items.Add(new YoshiEgg(new Vector2(x, y)));
                    break;
                case nameof(Star):
                    world.Items.Add(new Star(new Vector2(x, y)));                
                    break;
                default:
                    break;
            }
        }

        private static void CreateBlock(IWorld world, string type, float x, float y)
        {
            switch (type)
            {
                case nameof(HiddenBlock):
                    world.Blocks.Add(new HiddenBlock(new Vector2(x, y)));
                    break;
                case nameof(ActivatedBlock):
                    world.Blocks.Add(new ActivatedBlock(new Vector2(x, y)));
                    break;
                case nameof(Brick):
                    world.Blocks.Add(new Brick(new Vector2(x, y)));
                    break;
                case nameof(QuestionBlock):
                    world.Blocks.Add(new QuestionBlock(new Vector2(x, y)));
                    break;
                case nameof(Pipe):
                    world.Blocks.Add(new Pipe(new Vector2(x, y)));
                    break;
                default:
                    break;
            }
        }

        private static void CreateEnemy(IWorld world, string type, float x, float y)
        {
            switch (type)
            {
                case nameof(Goomba):
                    world.Enemies.Add(new Goomba(new Vector2(x, y)));
                    break;
                case nameof(Koopa):
                    world.Enemies.Add(new Koopa(new Vector2(x, y)));
                    break;
                default:
                    break;
            }
        }



        private static void CreateBackground(IWorld world, string type, float x, float y)
        {
            switch (type)
            {
              case nameof(Background):
                    world.Backgrounds.Add(new Background(new Vector2(x, y)));
                break;
              default:
                break;
            }
        }
    }
}
