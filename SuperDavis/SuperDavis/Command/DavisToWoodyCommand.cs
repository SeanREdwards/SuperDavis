﻿using SuperDavis.Interface;
using SuperDavis.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisToWoodyCommand : ICommand
    {
        private readonly Davis davis;
        public DavisToWoodyCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisToWoody();
        }
    }
}
