1. Description
	This project is designed for Sprint 3 for CSE3902 class, including Level
Loading, collision detection and more controllers. An addtional mouse controller
feature has been added, binding to the key 'M'.  Another import feature is collision
detection. Plugs, a xml parser has been created in order to more the literals into
a xml file.
	In the game, character will have 4 states - davis, woody(with mushroom),
bat(with flower) and invincible(with star). When character is in the invincible status,
he will not die and will kill every enemy he collided into. However, this state has time
limit. There also has hidden block, which you can only trigger it by colliding it from its
bottom. Brick will break if you 'bumped' it from bottom. Question block will become
used when character collided from bottom as well. For enemy, the enemy will die only
if you 'stomp' it from top. From all other angle, the character will die.

2. Key Mappings
	For keyboard:
                      (Keys.Q, Exit),
                      (Keys.R, Reset),
                      (Keys.A, TurnLeft),
                      (Keys.D, TurnRight),
                      (Keys.W, Jump(Go up)),
                      (Keys.S, Crouch(Go down)),
                      (Keys.Y, Character change to Davis),
                      (Keys.U, Character chagne to Woody),
                      (Keys.I, Chatacter change to Bat),
                      (Keys.Left,TurnLeft),
                      (Keys.Right, TurnRight),
                      (Keys.Up, Jump(Go up)),
                      (Keys.Down, Crouch(Go down)),
                      (Keys.O, Character to Death),
                      (Keys.P, Character Special Attack),
                      (Keys.M, Toggle mouse control)
	For gamepad:
                      (Buttons.Start, Exit),
                      (Buttons.Back, Reset),
                      (Buttons.LeftThumbstickLeft, TurnLeft),
                      (Buttons.LeftThumbstickRight, TurnRight),
                      (Buttons.LeftThumbstickUp, Jump),
                      (Buttons.LeftThumbstickDown, Crouch),
                      (Buttons.X, DavisToDavis),
                      (Buttons.Y, DavisToWoody),
                      (Buttons.LeftTrigger, DavisToBat),
                      (Buttons.RightTrigger, DavisDeath),
                      (Buttons.A, DavisSpecialAttack),
                      (Buttons.B, ToggleMouseControl)	

3. Tag to Grade
	Sprint3Refactoring
