using SuperDavis.Collision;
using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class StartCommand : ICommand
    {
        private readonly Game1 game;
        public StartCommand(Game1 gameClass)
        {
            game = gameClass;
        }

        public void Execute()
        {
            game.World = game.Momento.Load("boss-level.xml");
            //game.World = game.Momento.Load("demo-level.xml");
            game.CollisionDetection = new CollisionDetection(game.World);
            game.InitializeController();
        }
    }
}
