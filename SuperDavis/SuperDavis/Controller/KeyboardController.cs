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
        private Dictionary<Keys, ICommand> keyCommandDict;
        private Keys[] previousKeys;

        public KeyboardController(SuperDavis superDavisClass)
        {
            previousKeys = new Keys[0];
            SuperDavis superDavis = superDavisClass;
            keyCommandDict = new Dictionary<Keys, ICommand>
            {
                { Keys.Q, new ExitCommand(superDavis)},
                { Keys.W, new StaticCommand(superDavis)},
                { Keys.E, new AnimateCommand(superDavis)},
                { Keys.R, new UpAndDownCommand(superDavis)},
                { Keys.T, new LeftAndRightCommand(superDavis)}
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
