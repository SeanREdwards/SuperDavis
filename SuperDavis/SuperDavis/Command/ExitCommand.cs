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
        private readonly SuperDavis superDavis;
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
