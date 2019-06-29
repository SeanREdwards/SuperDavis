using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisStaticCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisStaticCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.DavisStatic();
        }
    }
}
