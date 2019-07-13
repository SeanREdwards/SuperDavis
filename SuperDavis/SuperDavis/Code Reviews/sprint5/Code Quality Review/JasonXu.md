# Code Quality Review - Jason Xu
1. Jason Xu
2. 7/12/2019
3. Sprint 5
4. CollisionDetection.cs, JumpState.cs
5. 10 minutes
6. in CollisionDetection.cs, 
```
        private static void CheckCharactersSurroundingBox(HashSet<IDavis> movers, IWorld world)
        {
            foreach(IDavis mover in movers)
            { 
                var i = (int)(mover.Location.X / (world as World).UNIT_SIZE);
                var j = (int)(mover.Location.Y / (world as World).UNIT_SIZE);
                if (!(world as World).IsIndexOutOfBounds(i, j))
                {
                    // Get instance of character reference in the World Grid
                    IDavis moverObject = (IDavis)world.GetObject(mover, i, j);
  
                    if (moverObject != null)
                    {
                        int hitBoxWidthScaleFactor = (int)(moverObject.HitBox.Width / (world as World).UNIT_SIZE) + 1;
                        int hitBoxHeightScaleFactor = (int)(moverObject.HitBox.Height / (world as World).UNIT_SIZE) + 1;
                        int offsetFactor = Variables.Variable.offsetRange; // Magic number here!

                        for (int iOffset = -offsetFactor*hitBoxWidthScaleFactor; iOffset < (offsetFactor+1) * hitBoxWidthScaleFactor; iOffset++)
                              for (int jOffset = -offsetFactor*hitBoxHeightScaleFactor; jOffset < (offsetFactor+1) * hitBoxHeightScaleFactor; jOffset++)
                                   if (!(world as World).IsIndexOutOfBounds(i + iOffset, j + jOffset))
                                        if (world.WorldGrid[i + iOffset][j + jOffset].Count != 0)
                                            for(int k = 0; k < world.WorldGrid[i+iOffset][j+jOffset].Count; k++)
                                            {
                                                var target = world.WorldGrid[i + iOffset][j + jOffset][k];
                                                if (!target.Equals(mover) && (target is IBlock || target is IItem || target is IEnemy))
                                                {
                                                    var side = GetCollisionSide(Rectangle.Intersect(moverObject.HitBox, target.HitBox), moverObject.HitBox, target.HitBox);
                                                    if (side != CollisionSide.None)
                                                    {
                                                        if (target is IBlock) DavisBlockCollisionHandler.HandleCollision(moverObject, (IBlock)target, side, world);
                                                        if (target is IItem) DavisItemCollisionHandler.HandleCollision(moverObject, (IItem)target, side, world);
                                                        if (target is IEnemy) DavisEnemyCollisionHandler.HandleCollision(moverObject, (IEnemy)target, side, world);
                                                    }
                                                }
                                            }
                    }
                }
            }
        }
	```

	The cyclomatic complexity is super high, due to the multiple nested if loop. A better way is to split them into world.cs and worldCreator.cs to increase its cohesion, however,
	the performance will not change a lot. It is a setback for applying new mechanism.

	In jumpState.cs,
	```
	    class JumpState : IGameObjectPhysics
    {

        private IGameObject gameObject;
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public JumpState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            Velocity =  new Vector2(0, Variables.Variable.JumpVelocity);
            Acceleration = new Vector2(0, Variables.Variable.JumpVelocityDecayRate);
            MaxVelocity = new Vector2(0, Variables.Variable.JumpVelocityMin);
        }

        public void Update(GameTime gameTime)
        {
            gameObject.Location -= Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Velocity.Y < MaxVelocity.Y)
            {
                Velocity = new Vector2(Velocity.X, 0);
                gameObject.PhysicsState = new FallState(gameObject);
            }
        }
    }
	```

	I finally decide to go back the previous setting is because the applyforce mechanism is hard to cooperate with collision detection. The design is kinda bad cuz the parameter is 
	actually magic number instead of object-oriented numbers. The coupling is bad due to this design. I have made the velocity editable to avoid this kind of problems.