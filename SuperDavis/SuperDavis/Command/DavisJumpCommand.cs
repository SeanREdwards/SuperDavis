using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisJumpCommand : ICommand
    {
        private readonly Davis davis;
        public DavisJumpCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisJump();
        }
    }
}
