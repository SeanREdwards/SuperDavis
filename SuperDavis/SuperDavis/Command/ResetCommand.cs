using SuperDavis.Interfaces;
using SuperDavis.World;

namespace SuperDavis.Command
{
    class ResetCommand : ICommand
    {
        private readonly WorldCreator world;
        public ResetCommand(WorldCreator worldClass)
        {
            this.world = worldClass;
        }
        public void Execute()
        {
            world.ResetGame();
        }
    }
}
