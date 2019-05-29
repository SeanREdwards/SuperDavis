﻿using SuperDavis.Interface;
using SuperDavis.Object.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class DavisJumpCommand : ICommand
    {
        private readonly Davis davis;
        public DavisJumpCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisJump();
        }
    }
}