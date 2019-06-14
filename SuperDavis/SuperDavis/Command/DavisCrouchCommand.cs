using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisCrouchCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisCrouchCommand(IDavis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisCrouch();
        }
    }
}
