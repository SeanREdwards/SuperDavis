using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisTurnRightCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisTurnRightCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisTurnRight();
        }
    }
}
