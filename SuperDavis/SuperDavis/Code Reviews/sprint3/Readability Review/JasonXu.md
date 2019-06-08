# Readability code review - Jason Xu
1. Jason Xu
2. 6/7/2019
3. Sprint 3
4. WorldCreator.cs/ World.cs/ Collision
5. Jason Xu
6. 15 mins
7. WorldCreator.cs in the class, I use some nested switch class to detemine which type of objects we are creating:
	```
        private static void CreateObjects(IWorld world, string objects, string type, float x, float y)
        {
            switch (objects)
            {
                case "Character":
                    CreateCharacter(world, type, x, y);
                    break;
                case "Item":
                    CreateItem(world, type, x, y);
                    break;
                case "Block":
                    CreateBlock(world, type, x, y);
                    break;
                case "Enemy":
                    CreateEnemy(world, type, x, y);
                    break;
                case "Scenery":
                    CreateBackground(world, type, x, y);
                    break;
                default:
                    break;
            }
        }
	```
	It's easy to read, but as the professor mentioned in class, it's not best practice, what we should do is to pair a list of creating method.

	World.cs
	It's easy to understand that I created lists to iterate through all the objects in the list：
	```
	        public void Update(GameTime gameTime)
        {
            foreach (IBackground background in Backgrounds)
            {
                background.Update(gameTime);
            }
            foreach (IDavis character in Davises)
            {
                character.Update(gameTime);
            }
            foreach (IItem item in Items)
            {
                item.Update(gameTime);
            }
            foreach (IBlock block in Blocks)
            {
                block.Update(gameTime);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
        }
	```

	CollisionDetection.cs
	Different collision handler uses same pattern, nested foreach, it's not optimal, we will fix it in the refactoring:	
	```
		foreach (IDavis davis in davises)
            {
                foreach (IEnemy enemy in enemies)
                {

                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, enemy.HitBox), davis.HitBox, enemy.HitBox);
                    MarioEnemyCollisionHandler.HandleCollision(davis, enemy, side);

                }
            }
	```

	MarioBlockCollision.cs
	In the code it listed out the location detemination when collision happens, it's good to have comment, also, the handling of blocks 
	is quite clear as well.