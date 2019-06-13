using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisToWoodyCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisToWoodyCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisToWoody();
        }
    }
}
