# Code Quality review - Jason Xu
1. Jason Xu
2. 5/30/2019
3. Sprint 2
4. State/Factory/SuperDavis.cs
5. Sean Edwards, Jason Xu
6. 20 Mins
7. 
	1. SuperDavis.cs
		Some code smell exists in this class. “Excessive use of literals” happens since the code hard-coding the initial location of the objects.
		```
		private void InitializeObject()
        {
            davis = new Davis(new Vector2(WindowsEdgeWidth / 2, WindowsEdgeHeight / 2));
            flower = new Flower(new Vector2(100, 100));
            coin = new Coin(new Vector2(200,100));
            mushroom = new Mushroom(new Vector2(300, 100));
            yoshiEgg = new YoshiEgg(new Vector2(400, 100));
            star = new Star(new Vector2(500, 100));
            hiddenBlock = new HiddenBlock(new Vector2(100, 200));
            activatedBlock = new ActivatedBlock(new Vector2(200, 200));
            brick = new Brick(new Vector2(300, 200));
            questionBlock = new QuestionBlock(new Vector2(400, 200));
            pipe = new Pipe(new Vector2(500, 200));
            goomba = new Goomba(new Vector2(100, 300));
            koopa = new Koopa(new Vector2(200, 300));
        }
		```
		This could be fixed in sprint 3, when the world generator is applied, we can move all of this location into a xml or csv file.
		This situation also happens in factory classes, which we will improve them in next sprint.

	2. ItemSpriteFactory.cs
		The parameter in the code is not very descriptive.
		```
		public void Load(ContentManager content)
        {
            blocksAndPipes = content.Load<Texture2D>("BlockSprites/Blocks&Pipes");
            blocksAndPipesTwo = content.Load<Texture2D>("BlockSprites/Blocks&Pipes2");
            brickBlocks = content.Load<Texture2D>("BlockSprites/BrickBlock");
        }
		```
		Since the blockAndPipes also includes other texture.

	3. State
		We applied state pattern for davis states since it includes a lot of state transition, while applying state machine for items and blocks.
		It's a good practice since the still item will not need a lot of state changes, and state machine will save us a lot of work from creating
		a bunch of classes.

