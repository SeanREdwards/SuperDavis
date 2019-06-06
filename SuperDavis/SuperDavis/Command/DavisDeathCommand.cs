using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisDeathCommand : ICommand
    {
        private readonly Davis davis;
        public DavisDeathCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisDeath();
        }
    }
}
