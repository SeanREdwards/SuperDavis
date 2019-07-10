using SuperDavis.Interfaces;
using SuperDavis.Variables;

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
            Variable.coins = 0;
            Variable.score = 0;
            Variable.time = 400;
            Variable.lives = 3;
            world.ResetGame();
        }
    }
}
