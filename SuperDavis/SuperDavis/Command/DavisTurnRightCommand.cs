using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisTurnRightCommand : ICommand
    {
        private readonly Davis davis;
        public DavisTurnRightCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisTurnRight();
        }
    }
}
