using SuperDavis.Interfaces;
using SuperDavis.Physics;

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
            if(!(davis.PhysicsState is FlyingKneeState))
                davis.DavisSpecialAttack();
        }
    }
}
