using SuperDavis.Interfaces;
using SuperDavis.Object.Character;

namespace SuperDavis.Command
{
    class DavisCrouchCommand : ICommand
    {
        private readonly Davis davis;
        public DavisCrouchCommand(Davis davis)
        {
            this.davis = davis;
        }
        public void Execute()
        {
            davis.DavisCrouch();
        }
    }
}
