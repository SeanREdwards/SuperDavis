using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisToBatCommand : ICommand
    {
        private readonly Davis davis;
        public DavisToBatCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisToBat();
        }
    }
}
