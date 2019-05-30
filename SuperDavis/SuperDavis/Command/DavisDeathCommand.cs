using SuperDavis.Interface;
using SuperDavis.Object.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisDeathCommand : ICommand
    {
        private readonly Davis davis;
        public DavisDeathCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisDeath();
        }
    }
}
