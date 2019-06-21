# Readability code review - Jason Xu
1. Jason Xu
2. 5/29/2019
3. Sprint 2
4. Factorys/GenerateSprite.cs/Coordinates
5. Sean Edwards
6. 20 Mins
7. 
	1. Factorys:
		Overall it's a typical design of factory and singleton, it's readable and easy
	to understand. However, since we used the coordinate system to locate our sprites,
	a list of magic number has to be included. For example:

	```C#
		public ISprite CreateDavisWalkRightSprite()
	    {
			coordinateList = new List<Coordinate>() { new Coordinate(258, 0, 38, 80), new Coordinate(338, 0, 38, 80),
			    new Coordinate(421, 0, 35, 80), new Coordinate(502, 0, 34, 80), new Coordinate(582, 0, 35, 80) };
			return Create(davisRightZero);
		}
	```

		The readability of the magic number is always bad. Since it's sprint 2, we didn't 
	import a way to set those coordinates into a file. However, we will solve this in
	the future sprints. Our idea is to create a class named createObjects, which will
	read in all the stuff including their coordinates.
		
		For the item sprite factory, the naming convention would be confusing, since 
	the sprite sheet of block includes the item sprites as well, we will work on this 
	for the refactoring stage.

	```C#
		private Texture2D blocksAndPipes;
		private Texture2D blocksAndPipesTwo;
		private Texture2D brickBlocks;
	```

		Like the code shown above, the 'blocksAndPipes' actually includes the sprites of
	coin and flower as well.

	2. GenerateSprite.cs
		The readability is good, it's easy to understand that it's importing a list of 
	parameter instead of what we have done for sprint 0.

	3. Coordinates.cs
		This is a helper class for generate a 4 parameter pair for the list we sent to 
	GenerateSprite. We could use something like 'param' in the future to get rid of this.

