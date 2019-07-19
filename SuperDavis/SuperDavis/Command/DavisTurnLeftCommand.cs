using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;

namespace SuperDavis.Command
{
    class DavisTurnLeftCommand : ICommand
    {
        private readonly IDavis davis;
        private readonly IWorld world;
        public DavisTurnLeftCommand(IDavis davis, IWorld world)
        {
            this.world = world;
            this.davis = davis;
        }

        public void Execute()
        {
            if (davis.DavisState is DavisStaticLeftState || davis.DavisState is DavisWalkLeftState || davis.DavisState is DavisJumpLeftState)
                davis.Location += new Vector2(-3f, 0);
            davis.DavisTurnLeft();
        }
    }
}
