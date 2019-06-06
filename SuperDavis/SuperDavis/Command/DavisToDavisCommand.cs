using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisToDavisCommand : ICommand
    {
        private readonly Davis davis;
        public DavisToDavisCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisToDavis();
        }
    }
}
