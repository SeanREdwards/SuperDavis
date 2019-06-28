using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisTurnLeftCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisTurnLeftCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.DavisTurnLeft();
        }
    }
}
