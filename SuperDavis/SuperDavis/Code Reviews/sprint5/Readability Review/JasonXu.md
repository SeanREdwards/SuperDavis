# Code Quality Review - Jason Xu
1. Jason Xu
2. 7/10/2019
3. Sprint 5
4. CollisionDetection.cs
5. Jason Xu
6. 10 minutes
7. 
	I applied the new collision detection mechanism into the game, which only checks the surrounding box of the moving object, however, the readability is kinda bad:
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
		The logic is quite complicated, you will need to first iterate through the moving object lists in world, and you will need to locate in the position of the world grid.
		Next you will need to get the reference of that thing, and then configure it into the factors so that the hitbox can be translated to the worldGrid size in some way.

		The structure is too bulky and hard to fix, we will go back to fix this pile of code once we have done main functional stuff.