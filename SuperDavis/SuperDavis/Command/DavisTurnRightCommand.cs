using SuperDavis.Interface;
using SuperDavis.Object.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisTurnRightCommand : ICommand
    {
        private readonly Davis davis;
        public DavisTurnRightCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisTurnRight();
        }
    }
}
