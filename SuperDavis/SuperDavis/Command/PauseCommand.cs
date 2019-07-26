using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class PauseCommand : ICommand
    {
        private readonly Game1 game;
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.PauseFlag = !game.PauseFlag;
        }
    }
}
