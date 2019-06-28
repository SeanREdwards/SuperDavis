using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisToBatCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisToBatCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.DavisToBat();
        }
    }
}
