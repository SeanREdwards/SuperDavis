using SuperDavis.Interface;
using SuperDavis.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisToDavisCommand : ICommand
    {
        private readonly Davis davis;
        public DavisToDavisCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisToDavis();
        }
    }
}
