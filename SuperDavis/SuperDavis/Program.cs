using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavisDemo
{
    static class Program
    {
        static void Main()
        {
            using (var game = new SuperDavis())
                game.Run();
        }
    }
}
