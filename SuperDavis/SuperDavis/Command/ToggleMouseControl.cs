using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class ToggleMouseControl : ICommand
    {
        private readonly Game1 game;
        public ToggleMouseControl(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.IsMouseControllerOn = !game.IsMouseControllerOn;
        }
    }
}
