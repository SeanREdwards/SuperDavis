using SuperDavis.Interface;
using SuperDavis.Object.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class ShowHiddenBlockCommand : ICommand
    {
        private HiddenBlock hiddenBlock;
        public ShowHiddenBlockCommand(HiddenBlock hiddenBlock)
        {
            this.hiddenBlock = hiddenBlock;
        }
        public void Execute()
        {
            hiddenBlock.UnhiddenBlock();
        }
    }
}
