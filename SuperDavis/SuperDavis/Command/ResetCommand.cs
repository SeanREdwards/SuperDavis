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
            world.HUD.score = Variable.score;
            world.HUD.coins = Variable.coins;
            world.HUD.lives = Variable.lives;
            world.HUD.worldText = Variable.worldText;
            world.HUD.time = Variable.time;
            world.ResetGame();
        }
    }
}
