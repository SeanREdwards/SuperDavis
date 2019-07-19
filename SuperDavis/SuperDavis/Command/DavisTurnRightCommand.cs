using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Physics;
using SuperDavis.State.DavisState;

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
            if (davis.DavisState is DavisStaticRightState || davis.DavisState is DavisWalkRightState || davis.DavisState is DavisJumpRightState)
                davis.Location += new Vector2(3f, 0);
            davis.DavisTurnRight();
        }
    }
}
