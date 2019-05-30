# README FILE
1. Description
	Project is designed for CSE3902 SU19 class Sprint 2. In this sprint, we will create a lot objects, implementing their animation, and add keyboard control into the game.
	Some design pattern will be applied in this sprint, including Command Design Pattern, Factory Method Design Pattern (Singleton) and State Design Pattern (State pattern and State Machine).
2. Keybinding Manual
	```C#
            controllerList = new List<IController>()
            {
                {new KeyboardController
                (
                    (Keys.Q, new ExitCommand(this)),
                    (Keys.R, new ResetCommand(this)),
                    (Keys.A, new DavisTurnLeftCommand(davis)),
                    (Keys.D, new DavisTurnRightCommand(davis)),
                    (Keys.W, new DavisJumpCommand(davis)),
                    (Keys.S, new DavisCrouchCommand(davis)),
                    (Keys.Y, new DavisToDavisCommand(davis)),
                    (Keys.U, new DavisToWoodyCommand(davis)),
                    (Keys.I, new DavisToBatCommand(davis)),
                    (Keys.C, new ShowHiddenBlockCommand(hiddenBlock)),
                    (Keys.X, new BreakBrickCommand(brick)),
                    (Keys.Z, new UseQuestionBlockCommand(questionBlock))
                )}
            };
	```
	* Q : Exit the game
	* R : Reset the sprites to initial state
	* A : Make Character Turn left (Walk left if it is facing left)
	* D : Make Character Turn right (Walk right if it is facing right)
	* W : Make Character Jump (To static if it is crouching)
	* S : Make Character Crouch (To static if it is jumping)
	* Y : Change Character to Davis Sprite
	* U : Change Character to Woody Sprite
	* I : Change Character to Bat Sprite
	* C : Show hidden block
	* X : Break brick 
	* Z : Make question block used