using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisSpecialAttackCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisSpecialAttackCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.DavisSpecialAttack();
        }
    }
}
