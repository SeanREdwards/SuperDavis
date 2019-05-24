using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisTurnRightCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisTurnRightCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisTurnRight();
        }
    }
}
