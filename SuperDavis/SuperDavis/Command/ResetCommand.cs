using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class ResetCommand : ICommand
    {
        private readonly IWorld world;
        public ResetCommand(IWorld worldClass)
        {
            world = worldClass;
        }
        public void Execute()
        {
            world.ResetGame();
        }
    }
}
