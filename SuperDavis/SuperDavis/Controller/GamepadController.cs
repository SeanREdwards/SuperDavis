using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Command;
using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Controller
{
    class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> buttonCommandDict;

        public GamepadController(SuperDavis superDavisClass)
        {
            SuperDavis superDavis = superDavisClass;
            buttonCommandDict = new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, new ExitCommand(superDavis)},
                { Buttons.A, new StaticCommand(superDavis)},
                { Buttons.B, new AnimateCommand(superDavis)},
                { Buttons.X, new UpAndDownCommand(superDavis)},
                { Buttons.Y, new LeftAndRightCommand(superDavis)}
            };
        }
        public void Update()
        {
            // TBD : Previous Click Button Set
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            foreach (KeyValuePair<Buttons, ICommand> buttonCommandPair in buttonCommandDict)
            {
                if (gamepadState.IsButtonDown(buttonCommandPair.Key))
                {
                    buttonCommandPair.Value.Execute();
                }
            }
        }
    }
}
