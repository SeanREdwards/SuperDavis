using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisFreeFallCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisFreeFallCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.PhysicsState.ApplyForce(new Vector2(0, Variables.Variable.GRAVITY));
        }
    }
}
