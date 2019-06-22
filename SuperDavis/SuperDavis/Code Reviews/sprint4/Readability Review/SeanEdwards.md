# Readability code review - Sean Edwards
1. Sean Edwards
2. 6/21/2019
3. Sprint 4
4. JumpState.cs
5. Jason Xu
6. 10 minutes
7. There were a few physics files to choose from for this code review so I focused on the Jump state 
since Jason had talked about some early issues he was having with the physics for jumping so I figured
looking at the readability of this code could help in the future so that we could avoid similiar issues.

Mainly I was looking for duplicated code, cycolmatic complexity, and excessive use of literals. There 
was no duplicated code, cyclomatic complexity was kept to a minimum due to only one if statement, and 
while most variables appear to be more data driven due to the Variable object, there is a literal
used (the integer 50 which after discussing with Jason he included because it made things "look smoother").
If this number is important he should data drive it and add it to his variable class.

```
        public void Update(GameTime gameTime)
        {
            gameObject.Location -= new Vector2(0, JumpVelocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50);
            JumpVelocity *= JumpVelocityDecayRate;
            if (JumpVelocity < JumpVelocityMin)
            {
                JumpVelocity = 0;
                gameObject.PhysicsState = new FallState(gameObject);
            }
        }
```
Otherwise the logic makes sense. The velocity vector gets set and is updated based on game time, with the delocity weight
building over time, once the velocity reachs a number less than the set velicty minimum it is then set back to 0 and the 
fall state is entered, making it so that the character rises and falls.