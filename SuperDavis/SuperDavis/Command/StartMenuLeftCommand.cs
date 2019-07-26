using SuperDavis.Collision;
using SuperDavis.Interfaces;
using SuperDavis.Sound;

namespace SuperDavis.Command
{
    class StartMenuLeftCommand : ICommand
    {
        private readonly Game1 game;
        public StartMenuLeftCommand(Game1 gameClass)
        {
            game = gameClass;
        }

        public void Execute()
        {
            if (game.HUD.CharacterSelect > 1)
                game.HUD.CharacterSelect--;
            Sounds.Instance.PlayCharacterSelection();
        }
    }
}
