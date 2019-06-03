using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class ResetCommand : ICommand
    {
        private readonly Game1 superDavis;
        public ResetCommand(Game1 superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.ResetGame();
        }
    }
}
