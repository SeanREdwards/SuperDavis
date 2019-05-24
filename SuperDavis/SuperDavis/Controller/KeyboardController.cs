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
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> keyCommandDict;
        private Keys[] previousKeys;

        public KeyboardController(SuperDavis superDavisClass)
        {
            previousKeys = new Keys[0];
            SuperDavis superDavis = superDavisClass;
            IDavis davis = superDavis.Davis;
            keyCommandDict = new Dictionary<Keys, ICommand>
            {
                { Keys.Q, new ExitCommand(superDavis)},
                { Keys.A, new DavisTurnLeftCommand(davis)},
                { Keys.D, new DavisTurnRightCommand(davis)}
            };
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
            previousKeys = currentKeys;
        }
    }
}
