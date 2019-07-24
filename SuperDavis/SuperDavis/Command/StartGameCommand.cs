using SuperDavis.Collision;
using SuperDavis.Interfaces;

namespace SuperDavis.Command
{
    class StartGameCommand : ICommand
    {
        private readonly Game1 game;
        public StartGameCommand(Game1 gameClass)
        {
            game = gameClass;
        }

        public void Execute()
        {
            game.World = game.Momento.Load("demo-level.xml");
            game.CollisionDetection = new CollisionDetection(game.World);
            System.Console.WriteLine("sadf");
            game.InitializeController();
        }
    }
}
