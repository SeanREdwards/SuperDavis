# Code Quality Review - Jason Xu
1. Jason Xu
2. 6/28/2019
3. Sprint 4
4. CollisionDetection.cs / Davis.cs
5. Jason Xu
6. 15mins
7. A performance issue has been rised in the collisionDetection.cs file, where:
```
        private static void CheckProjectileEnemyCollision(IList<IProjectile> projectiles, IList<IEnemy> enemies, IWorld world)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                foreach (IEnemy enemy in enemies)
                {
                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(projectiles[i].HitBox, enemy.HitBox), projectiles[i].HitBox, enemy.HitBox);
                    ProjectileEnemyCollisionHandler.HandleCollision(projectiles[i], enemy, side, world);
                }
            }
        }
```
	In here, the nested for each loop actually adding some unneccessary function call, the profiling of this mechanism is actually pretty bad. Also, we can use
	delegates to determine different function call since ProjectileEnemyCollisionHandler.HandleCollision(projectiles[i], enemy, side, world); in different detection could 
	has same structure of (IGameObject, IGameObject, side, world)

	In Davis.cs:
```
        public void Update(GameTime gameTime)
        {
            //For seperating sprite from state
            Sprite.Update(gameTime);

            PhysicsState.Update(gameTime);
            //HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)Sprite.Width, (int)Sprite.Height);
        }
```
	Due to the problem mentioned above, the moving objects get_Hit_Box get call to many times, the complexity of the code is increased by a huge amount. Talking of changing it in 
	other way.