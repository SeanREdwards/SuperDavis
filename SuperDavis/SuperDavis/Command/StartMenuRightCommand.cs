using SuperDavis.Interfaces;
using SuperDavis.Sound;

namespace SuperDavis.Command
{
    class StartMenuRightCommand : ICommand
    {
        private readonly Game1 game;
        public StartMenuRightCommand(Game1 gameClass)
        {
            game = gameClass;
        }

        public void Execute()
        {
            if (game.HUD.CharacterSelect < 3)
                game.HUD.CharacterSelect++;
            Sounds.Instance.PlayCharacterSelection();

        }
    }
}
