# Code Quality Review - Jason Xu
1. Jason Xu
2. 7/25/2019
3. Sprint 6
4. HUD.cs / PhysicsState
5. Jason Xu
6. 10 minutes
7.
```
        public void StartMenuContext(GameTime gameTime, SpriteFont font, SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            if (this.CharacterSelect == 1)
                DavisSpriteFactory.Instance.CreateDavisWalkRightSprite().Draw(spriteBatch, new Vector2(350, 450));
            else if (CharacterSelect == 2)
                DavisSpriteFactory.Instance.CreateWoodyWalkRightSprite().Draw(spriteBatch, new Vector2(600, 450));
            else
                DavisSpriteFactory.Instance.CreateBatWalkRightSprite().Draw(spriteBatch, new Vector2(850, 450));

            spriteBatch.DrawString(font, "SuperDavis - Team Shoryuken", new Vector2(50, 50), Color.White);
            DavisSpriteFactory.Instance.CreateDavisPortrait().Draw(spriteBatch, new Vector2(300, 300));
            DavisSpriteFactory.Instance.CreateWoodyPortrait().Draw(spriteBatch, new Vector2(550, 300));
            DavisSpriteFactory.Instance.CreateBatPortrait().Draw(spriteBatch, new Vector2(800, 300));
            spriteBatch.DrawString(font, "Press Space To Start", new Vector2(450, 550), Color.White);
        }
```
	First of all, too much literals are adding into the hud class, we may not have time to make all magic number data-driven so it's kinda bad.
	Second, the method is basically disposing the spriteBatch and redraw it everytime, it may cause some performance issues.

```
        public JumpState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            Velocity = new Vector2(0, Variables.Variable.JumpVelocity);
            Acceleration = new Vector2(0, Variables.Variable.JumpVelocityDecayRate);
            MaxVelocity = new Vector2(0, Variables.Variable.JumpVelocityMin);
        }
```
	Notice, different class are using same jumpStatePhysics. So currently we just import some magic number in it. However, a better practice is
	to create a dictionary, including character's parameter, and the system will load this parameters due to its class. This is much easier to maintain
	and modify in the future. 

	Actually, this kind of problem is important, a series of dictionary is needed in case of the project getting larger and larger.



