# Readability code review - Jason Xu
1. Jason Xu
2. 6/21/2019
3. Sprint 4
4. CollisionHandler/GenerateSprite.cs/WorldCreator.cs
5. Jason Xu & Sean Edwards
6. 15 minutes
7. For example, in DavisBlockCollisionHandler.cs:
	```
	else if (block is QuestionBlock)
                    {
                        block.SpecialState();
                    }
                    else if (block is Brick)
                    {
                        if (davis.DavisStatus != DavisStatus.Davis)
                        {
                            block.SpecialState();
                            block.Remove = true;
                        }
                        else
                        {
                            block.IsBumped = true;
                        }
                    }
                    else if (block is MushroomBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.Items.Add(new Mushroom(new Vector2(block.Location.X, block.Location.Y - 10)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
                    }
                    else if (block is CoinBlock)
                    {
                        if (!block.IsBumped)
                        {
                            world.Items.Add(new Coin(new Vector2(block.Location.X, block.Location.Y - 40)));
                            block.SpecialState();
                            block.IsBumped = true;
                        }
				    }
	}
	```
	It is clear that I want to add different collision respond due to the type of blocks. Howeverm there is a bunches of magic numbers and repeated code,
	even though the readability is ok, the overall code quality is bad. I want to make all this data driven in the future.

	In new GenerateSprite.cs:
	```
	public GenerateSprite(Texture2D texture, List<Color> blinkColorList, float scale, SpriteEffects flipDirection, params Rectangle[] frameCoords)
    {
	 ...
	}
	```
	The function signature is clear, that we want to pass the different sprite features into the class. The readability is  ok, but it would be much nicer if
	we just pass our spriteRegistrar info into it to make it total data driven. Even though this would lower the readability.

	In the WorldCreator.cs:
	```
	    private void CreateObjects(IWorld worlds, string objects, string type, float x, float y)
        {
            objectDictionary.TryGetValue(objects, out Action<IWorld, string, float, float> buildObject);
            buildObject(worlds, type, x, y);
        }
	```
	So in here, if you click the reference of buildObject(worlds, type, x, y), you will not find any. This structure is good by getting rid of bunches switch statement,
	but the readability is kind of bad. It is a game of give and take. 
