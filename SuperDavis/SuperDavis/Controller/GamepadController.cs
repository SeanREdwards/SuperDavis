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
    /* The Gamepad Controller is not needed, but still save for the future */
    class GamepadController : IController
    {
        private readonly Dictionary<Buttons, ICommand> buttonCommandDict;

        public GamepadController(SuperDavis superDavisClass)
        {
            SuperDavis superDavis = superDavisClass;
            buttonCommandDict = new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, new ExitCommand(superDavis)}
                // TBD
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
