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
    class AnimateCommand : ICommand
    {
        private SuperDavis superDavis;
        public AnimateCommand(SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.CreateAnimateSprite();
        }
    }
}
