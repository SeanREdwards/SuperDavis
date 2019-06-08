using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisDeathCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisDeathCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisDeath();
        }
    }
}
