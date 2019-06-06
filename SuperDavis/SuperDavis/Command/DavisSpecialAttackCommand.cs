using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisSpecialAttackCommand : ICommand
    {
        private readonly Davis davis;
        public DavisSpecialAttackCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisSpecialAttack();
        }
    }
}
