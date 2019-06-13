using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperDavis.Interfaces;
using System.Collections.Generic;


namespace SuperDavis.Controller
{
    /* The Gamepad Controller is not needed, but still save for the future */
    class GamepadController : IController
    {
        private readonly Dictionary<Buttons, ICommand> buttonCommandDict;

        public GamepadController(params (Buttons button, ICommand command)[] args)
        {
            buttonCommandDict = new Dictionary<Buttons, ICommand> { };
            foreach ((Buttons button, ICommand command) pairs in args)
            {
                buttonCommandDict.Add(pairs.button, pairs.command);
            }
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
