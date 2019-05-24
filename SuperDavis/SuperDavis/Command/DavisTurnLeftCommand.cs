using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisTurnLeftCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisTurnLeftCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisTurnLeft();
        }
    }
}
