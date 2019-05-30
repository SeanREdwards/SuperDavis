using SuperDavis.Interface;
using SuperDavis.Object.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisSpecialAttackCommand : ICommand
    {
        private readonly Davis davis;
        public DavisSpecialAttackCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisSpecialAttack();
        }
    }
}
