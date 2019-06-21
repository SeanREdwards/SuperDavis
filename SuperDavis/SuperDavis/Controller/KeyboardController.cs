using Microsoft.Xna.Framework.Input;
using SuperDavis.Interfaces;
using System.Collections.Generic;
using System.Linq;

// Credit to Grader Dean Haleem! Thank you sooooooooooooo much
namespace SuperDavis.Controller
{
    class KeyboardController : IController
    {                                                                                                                                                   
        private readonly Dictionary<Keys, ICommand> keyPressedCommandDict;
        private readonly Dictionary<Keys, ICommand> keyReleasedCommandDict;
        private readonly List<Keys> pressedKeyList;
        private Keys[] previousKeys;

        public KeyboardController(params(Keys key, ICommand keyPressedCommand, ICommand keyReleasedCommand, bool holdKeyFlag)[] args)
        {
            previousKeys = new Keys[0];
            pressedKeyList = new List<Keys>();
            keyPressedCommandDict = new Dictionary<Keys, ICommand> { };
            keyReleasedCommandDict = new Dictionary<Keys, ICommand> { };
            foreach ((Keys key, ICommand keyPressedCommand, ICommand keyReleasedCommand, bool holdKeyFlag) in args)
            {
                keyPressedCommandDict.Add(key, keyPressedCommand);
                keyReleasedCommandDict.Add(key, keyReleasedCommand);
                if (holdKeyFlag)
                    pressedKeyList.Add(key);               
            }
        }
        public void Update()
        {
            /* Prevent the repeated pressed, credited to grader */
            Keys[] currentKeys = Keyboard.GetState().GetPressedKeys();
            // execute the pressed key command

            foreach(Keys key in keyReleasedCommandDict.Keys)
            {
                if(previousKeys.Contains(key) && !currentKeys.Contains(key))
                {
                    keyReleasedCommandDict[key].Execute();
                }
            }

            foreach (Keys key in currentKeys)
            {
                if (keyPressedCommandDict.ContainsKey(key))
                {
                    if (pressedKeyList.Contains(key) || !previousKeys.Contains(key))
                        keyPressedCommandDict[key].Execute();
                }
            }

            previousKeys = currentKeys;

        }
    }
}
