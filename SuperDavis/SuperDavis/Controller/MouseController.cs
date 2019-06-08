using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                foreach (IDavis davis in game.World.Davises) { 
                  davis.Location = new Vector2(mouseState.X, mouseState.Y);
                }
            }

    }

}
