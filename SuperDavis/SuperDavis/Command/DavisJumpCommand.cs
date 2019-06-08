using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisJumpCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisJumpCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisJump();
        }
    }
}
