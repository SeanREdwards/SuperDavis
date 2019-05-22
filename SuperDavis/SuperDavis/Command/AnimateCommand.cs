﻿using SuperDavis.Interface;
using SuperDavis.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperDavis.SuperDavis;

namespace SuperDavis.Command
{
    class AnimateCommand : ICommand
    {
        private SuperDavis superDavis;
        public AnimateCommand(SuperDavis superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.CreateAnimateSprite();
        }
    }
}
