﻿using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisToDavisCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisToDavisCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.DavisToDavis();
        }
    }
}
