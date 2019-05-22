using SuperDavis.Interface;
using SuperDavis.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperDavis.SuperDavis;

namespace SuperDavis.Command
{
    class StaticCommand : ICommand
    {
        private SuperDavis superDavis;
        public StaticCommand(SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.CreateStaticSprite();
        }
    }
}
