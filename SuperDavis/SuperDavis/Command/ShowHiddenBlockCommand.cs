using SuperDavis.Interfaces;
using SuperDavis.Object.Block;

namespace SuperDavis.Command
{
    class ShowHiddenBlockCommand : ICommand
    {
        private HiddenBlock hiddenBlock;
        public ShowHiddenBlockCommand(HiddenBlock hiddenBlock)
        {
            this.hiddenBlock = hiddenBlock;
        }
        public void Execute()
        {
            hiddenBlock.UnhiddenBlock();
        }
    }
}
