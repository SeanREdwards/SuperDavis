using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class ResetCommand : ICommand
    {
        private readonly Game1 superDavis;
        public ResetCommand(Game1 superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.ResetGame();
        }
    }
}
