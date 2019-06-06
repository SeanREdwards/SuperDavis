using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

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
