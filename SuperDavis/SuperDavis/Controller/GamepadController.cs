﻿namespace SuperDavis.Controller
{
    /*
    class GamepadController : IController
    {
        private readonly Dictionary<Buttons, ICommand> buttonCommandDict;

        public GamepadController(params (Buttons button, ICommand command)[] args)
        {
            buttonCommandDict = new Dictionary<Buttons, ICommand> { };
            foreach ((Buttons button, ICommand command) in args)
            {
                buttonCommandDict.Add(button, command);
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
    }*/
}
