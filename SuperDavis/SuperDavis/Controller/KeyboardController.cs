using Microsoft.Xna.Framework.Input;
using SuperDavis.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SuperDavis.Controller
{
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> keyCommandDict;
        private readonly Keys[] previousKeys;

        public KeyboardController(params(Keys key, ICommand command)[] args)
        {
            previousKeys = new Keys[0];
            keyCommandDict = new Dictionary<Keys, ICommand> { };
            foreach((Keys key, ICommand command) in args)
            {
                keyCommandDict.Add(key, command);
            }
        }
        public void Update()
        {
            /* Prevent the repeated pressed, credited to grader */
            Keys[] currentKeys = Keyboard.GetState().GetPressedKeys();          
            foreach(Keys key in currentKeys)
            {
                if (keyCommandDict.ContainsKey(key) && !previousKeys.Contains(key))
                {
                    keyCommandDict[key].Execute();
                }
            }
            /*Test sequential repeated input*/
            //previousKeys = currentKeys;
        }
    }
}
