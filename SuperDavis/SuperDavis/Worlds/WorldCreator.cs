using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using SuperDavis.Object.Character;
using SuperDavis.Object.Enemy;
using SuperDavis.Object.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SuperDavis.Worlds
{
    static class WorldCreator
    {
        private const int unitPixels = 16;

        public class ObjectInfo
        {
            public string Name { get; set; }
            public int XCoords { get; set; }
            public int YCoords { get; set; }
        }

        public static IWorld CreateWorld(string levelFile, int width, int height, Game1 game)
        {
            return ParseAndLoad(levelFile, width, height, game);
        }

        //TODO if we want to use for csv
        /*  Idea from: https://joshclose.github.io/CsvHelper/examples 
         private IWorld ParseAndLoad(string levelFile, int Width, int Height, Game1 game)
         {
             using (var reader = new StreamReader("Content\\Level\\test_level.csv"))
             using (var csv = new CsvReader(reader))
             {
                 csv.Configuration.IgnoreBlankLines = false;
                 var ObjRecords = new List<ObjectInfo>();
                 while(csv.Read())
                 {
                     //csv.GetRecord < "Davis" >
                 }
             }
             return null;
         }

         */

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
            switch (objects)
            {
                case "Character":
                    CreateCharacter(world, type, x, y);
                    break;
                case "Item":
                    CreateItem(world, type, x, y);
                    break;
                case "Block":
                    CreateBlock(world, type, x, y);
                    break;
                case "Enemy":
                    CreateEnemy(world, type, x, y);
                    break;
                default:
                    break;
            }
        }

        private static void CreateCharacter(IWorld world, string type, float x, float y)
        {
            switch (type)
            {
                case "Davis":
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
                case "Flower":
                    world.Items.Add(new Flower(new Vector2(x, y)));
                    break;
                case "Coin":
                    world.Items.Add(new Coin(new Vector2(x, y)));
                    break;
                case "Mushroom":
                    world.Items.Add(new Mushroom(new Vector2(x, y)));
                    break;
                case "YoshiEgg":
                    world.Items.Add(new YoshiEgg(new Vector2(x, y)));
                    break;
                case "Star":
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
                case "HiddenBlock":
                    world.Blocks.Add(new HiddenBlock(new Vector2(x, y)));
                    break;
                case "ActivatedBlock":
                    world.Blocks.Add(new ActivatedBlock(new Vector2(x, y)));
                    break;
                case "Brick":
                    world.Blocks.Add(new Brick(new Vector2(x, y)));
                    break;
                case "QuestionBlock":
                    world.Blocks.Add(new QuestionBlock(new Vector2(x, y)));
                    break;
                case "Pipe":
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
                case "Goomba":
                    world.Enemies.Add(new Goomba(new Vector2(x, y)));
                    break;
                case "Koopa":
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
              case "Background":
                    //TBD
                  //world.Background.Add(new Background(new Vector2(x, y)));
                break;
              default:
                break;
            }
        }
    }
}
