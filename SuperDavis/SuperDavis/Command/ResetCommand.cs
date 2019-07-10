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
        HUD.score = Variable.score;
        HUD.coins = Variable.coins;
        HUD.lives = Variable.lives;
        HUD.worldText = Variable.worldText;
        HUD.time = Variable.time;
        world.ResetGame();
        }
    }
}
