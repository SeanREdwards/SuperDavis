using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;

namespace SuperDavis.Command
{
    class DavisStaticCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisStaticCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            if(!(davis.DavisState is DavisJumpLeftState || davis.DavisState is DavisJumpRightState))
                davis.DavisStatic();
        }
    }
}
