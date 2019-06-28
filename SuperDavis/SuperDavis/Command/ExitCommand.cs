using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class ExitCommand : ICommand
    {
        private readonly Game1 game;
        public ExitCommand(Game1 gameClass)
        {
            game = gameClass;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
