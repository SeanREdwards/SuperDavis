using SuperDavis.Interface;
using SuperDavis.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisToBatCommand : ICommand
    {
        private readonly Davis davis;
        public DavisToBatCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisToBat();
        }
    }
}
