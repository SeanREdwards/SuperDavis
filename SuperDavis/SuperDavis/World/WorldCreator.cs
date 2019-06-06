using CsvHelper;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.World
{
    class WorldCreator
    {
        private const int unitPixels = 16;

        public class ObjectInfo
        {
            public string Name { get; set; }
            public int XCoords { get; set; }
            public int YCoords { get; set; }
        }

        public IWorld CreateWorld(Game1 game, int width, int height)
        {
            // TBD
            return null;
        }

        /* Idea from: https://joshclose.github.io/CsvHelper/examples */
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
            /*TBD*/
            return null;
        }


    }
}
