using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class ExitCommand : ICommand
    {
        private readonly Game1 superDavis;
        public ExitCommand(Game1 superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.Exit();
        }
    }
}
