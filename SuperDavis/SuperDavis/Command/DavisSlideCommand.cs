using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class DavisSlideCommand : ICommand
    {
        private readonly IDavis davis;
        public DavisSlideCommand(IDavis davis)
        {
            this.davis = davis;
        }

        public void Execute()
        {
            davis.DavisSlide();
        }
    }
}
