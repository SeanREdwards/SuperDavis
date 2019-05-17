using SuperDavisDemo.Interface;
using SuperDavisDemo.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperDavisDemo.SuperDavis;

namespace SuperDavisDemo.Command
{
    class LeftAndRightCommand : ICommand
    {
        private SuperDavis superDavis;
        public LeftAndRightCommand(SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.CreateRightSprite();
        }
    }
}
