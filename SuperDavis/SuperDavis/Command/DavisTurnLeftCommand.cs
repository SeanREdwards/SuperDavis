using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisTurnLeftCommand : ICommand
    {
        private readonly Davis davis;
        public DavisTurnLeftCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisTurnLeft();
        }
    }
}
