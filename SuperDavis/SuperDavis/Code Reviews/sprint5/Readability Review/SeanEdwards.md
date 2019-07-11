# Code Quality Review - Sean Edwards
1. Sean Edwards
2. 7/10/2019
3. Sprint 5
4. StandingState.cs
5. Jason Xu
6. 10 minutes
7.I looked at the StandingState.cs as Jason changed the physics states into 3 major categories:
Standing, Jumping, and Falling.
The code for the physics state swapping is pretty simplisitc in that state gets created which stores
velocity/acceleration information and how much it moves the game object currently in that phsyics state
(here how quickly) the game object falls. The Update method is the driver that updates the object location,
based on the stored state information.
        ```public FallState(IGameObject gameObjectClass)
        {
            gameObject = gameObjectClass;
            Velocity = new Vector2(0, Variables.Variable.FallVelocity);
            Acceleration = new Vector2(0, Variables.Variable.FallVelocityIncreaseRate);
            MaxVelocity = new Vector2(0, Variables.Variable.FallVelocityMax);
        }
        public void Update(GameTime gameTime)
        {
            gameObject.Location += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / Variables.Variable.PhysicsDivisor);
            Velocity *= Acceleration;
            if (Velocity.Y > MaxVelocity.Y)
            {
                Velocity = new Vector2(Velocity.X, MaxVelocity.Y);
            }
        }```