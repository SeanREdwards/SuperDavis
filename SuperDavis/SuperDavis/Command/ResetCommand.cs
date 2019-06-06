using SuperDavis.Interfaces;
using SuperDavis.World;

namespace SuperDavis.Command
{
    class ResetCommand : ICommand
    {
        private readonly IWorldCreator world;
        public ResetCommand(IWorldCreator worldClass)
        {
            this.world = worldClass;
        }
        public void Execute()
        {
            world.ResetGame();
        }
    }
}
