using SuperDavis.Interface;
using SuperDavis.Object.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class BreakBrickCommand : ICommand
    {
        private Brick brick;
        public BreakBrickCommand(Brick brick)
        {
            this.brick = brick;
        }
        public void Execute()
        {
            brick.BreakBrick();
        }
    }
}
