# Jason Xu code quality review for sprint 3
1. Jason Xu
2. 6/13/19
3. Sprint 3
4. CollisionHandler/Objects/DavisState
5. Jason Xu/Sean Edwards
6. 20 minutes
7. 
		In MarioBlockCollisionHandler.cs, such switch statement exists:
		```
            switch (side)
            {
                case CollisionSide.Bottom:
                    davis.Location = new Vector2(davis.Location.X, block.Location.Y + block.HitBox.Height);
                    if (block is HiddenBlock)
                    {
                        block.SpecialState();
                    }
                    else if (block is QuestionBlock)
                    {
                        block.SpecialState();
                    }
                    else if (block is Brick)
                    {
                        block.SpecialState();
                        block.Remove = true;
                    }
                    break;
                case CollisionSide.Top:
                    //if not hidden block
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(davis.Location.X, block.Location.Y - davis.HitBox.Height);
                    }
                    break;
                case CollisionSide.Left:
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(block.Location.X - davis.HitBox.Width, davis.Location.Y);
                    }
                    break;
                case CollisionSide.Right:
                    if (!block.IsHidden)
                    {
                        davis.Location = new Vector2(block.Location.X + block.HitBox.Width, davis.Location.Y);
                    }
                    break;
                case CollisionSide.None:
                    break;
            }
		```
		As mentioned in the class, such behavior it is not optimal. A better way is to create a list and search the pair to implement it. Some duplicated code could be combined together.
		Same thing happens to MarioEnemyCollisionHandler.cs and MarioItemCollisionHandler.cs. Also, in CollisionDetection.cs, the check collision statement are taking same implementation,
		We could have combine them together using function pointer or IGameObject parameter.

		In Object classes, for example, in ActivatedBlock.cs:
		```
		    public void Draw(SpriteBatch spriteBatch)
			{
				 if (!Remove)
					activatedBlockStateMachine.Draw(spriteBatch, Location);
			}
		```
		This decreases the cohesion of the code. Instead, we could let the world class to control which object should be drawn and which one shouldn't. According to grader Gen Xu, he suggested
		a way that while we are iterating through the game object list, we could have created a list including the object should be deleted. Thus this problem could be sloved.

		In DavisState, for example, DavisCrouchLeftState.cs:
		```
		public void Update(GameTime gameTime)
        {
            if (davis.DavisStatus == DavisStatus.Invincible)
            {
                davis.InvincibleTimer--;
                if (davis.InvincibleTimer <= 0)
                {
                    davis.DavisStatus = davis.PrevDavisStatus;
                    davis.DavisState.Static();
                    davis.InvincibleTimer = Variables.Variable.InvincibleTimer;
                }
            }
            Sprite.Update(gameTime);
        }
		```
		This is bad, it decreases the cohesion and increase the coupling of the code. A better way to solve it is to change the object in the Character list in the world generator. That when mario
		is invincible, replace the object in the list to invincible davis, after a certain amount of time, restore it back. Those suggestion would be implemented in the future sprite.
	