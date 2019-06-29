using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Interfaces;

namespace SuperDavis.Controller
{
    class MouseController : IController
    {
         private Game1 game;
         public MouseController(Game1 game)
         {
            this.game = game;
         }

         public void Update()
         {
            MouseState mouseState = Mouse.GetState();
            foreach (IDavis davis in game.World.Characters) { 
                davis.Location = new Vector2(mouseState.X, mouseState.Y);
            }
         }
    }
}
