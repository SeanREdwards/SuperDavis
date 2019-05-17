using SuperDavisDemo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavisDemo.Command
{
    class ExitCommand : ICommand
    {
        private SuperDavis superDavis;
        public ExitCommand(SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.Exit();
        }
    }
}
