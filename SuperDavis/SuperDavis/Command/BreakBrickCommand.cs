using SuperDavis.Interfaces;
using SuperDavis.Object.Block;

namespace SuperDavis.Command
{
    class BreakBrickCommand : ICommand
    {
        private Brick brick;
        public BreakBrickCommand(Brick brick)
        {
            this.brick = brick;
        }
        public void Execute()
        {
            brick.BreakBrick();
        }
    }
}
