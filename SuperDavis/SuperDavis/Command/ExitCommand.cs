using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class ExitCommand : ICommand
    {
        private readonly Game1 superDavis;
        public ExitCommand(Game1 superDavisClass)
        {
            this.superDavis = superDavisClass;
        }
        public void Execute()
        {
            superDavis.Exit();
        }
    }
}
