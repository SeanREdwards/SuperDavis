using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Character;
using SuperDavis.Worlds;
using System.Collections.Generic;

namespace SuperDavis.Collision
{
    class CollisionDetection
    {
        public enum CollisionSide { Top, Bottom, Left, Right, None};
        public IWorld World { get; }

        public CollisionDetection(IWorld world)
        {
            this.World = world;
        }

        /* CheckCollisions */
        public void CheckCollisions()
        {
            /*
             * Mover List： Character, item, projectile, enemy
             * Was thinking about just checking mover &  target, but we need to add those in a new list, which is a waste
             */
            CheckCharactersSurroundingCollision(World.Characters, World);

            CheckEnemyBlockCollision(World.Enemies, World.Blocks);
            CheckProjectileBlockCollision(World.Projectiles, World.Blocks, World);
            CheckProjectileEnemyCollision(World.Projectiles, World.Enemies, World);
        }
        
        private static void CheckCharactersSurroundingCollision(HashSet<IDavis> movers, IWorld world)
        {
            foreach(IDavis mover in movers)
            { 
                var i = (int)(mover.Location.X / (world as World).UNIT_SIZE);
                var j = (int)(mover.Location.Y / (world as World).UNIT_SIZE);

                if (CheckIndexOutOfBounds(i, j, world))
                {
                    // Get instance of character reference in the World Grid
                    IDavis moverObject = (IDavis)world.GetObject(mover, i, j);
  
                    if (moverObject != null)
                    {
                        int hitBoxWidthScaleFactor = (int)(moverObject.HitBox.Width / (world as World).UNIT_SIZE) + 1;
                        int hitBoxHeightScaleFactor = (int)(moverObject.HitBox.Height / (world as World).UNIT_SIZE) + 1;
                        int offsetFactor = 3; // Magic number here!

                        for (int iOffset = -offsetFactor*hitBoxWidthScaleFactor; iOffset < offsetFactor * hitBoxWidthScaleFactor; iOffset++)
                                for (int jOffset = -offsetFactor*hitBoxHeightScaleFactor; jOffset < offsetFactor * hitBoxHeightScaleFactor; jOffset++)
                                {
                                    if (CheckIndexOutOfBounds(i + iOffset, j + jOffset, world))
                                        if (world.WorldGrid[i + iOffset][j + jOffset].Count != 0)
                                            foreach (IGameObject target in world.WorldGrid[i + iOffset][j + jOffset])
                                            {
                                                if (!target.Equals(mover))
                                                {
                                                    var side = GetCollisionSide(Rectangle.Intersect(moverObject.HitBox, target.HitBox), moverObject.HitBox, target.HitBox);                                                  
                                                    if (target is IBlock) CheckCharacterBlockCollision(moverObject, (IBlock)target, side, world);
                                                    if (target is IItem) CheckCharacterItemCollision(moverObject, (IItem)target, side, world);
                                                    if (target is IEnemy) CheckCharacterEnemyCollision(moverObject, (IEnemy)target, side, world);
                                                }
                                            }
                                }
                    }
                }
            }
        }
        private static void CheckCharacterBlockCollision(IDavis davis, IBlock block, CollisionSide side, IWorld world)
        {
            DavisBlockCollisionHandler.HandleCollision(davis, block, side, world);
        }

        private static void CheckCharacterItemCollision(IDavis davis, IItem item, CollisionSide side, IWorld world)
        {
            DavisItemCollisionHandler.HandleCollision(davis, item, side, world);
        }

        private static void CheckCharacterEnemyCollision(IDavis davis, IEnemy enemy, CollisionSide side, IWorld world)
        {
            DavisEnemyCollisionHandler.HandleCollision(davis, enemy, side, world);
        }

        private static void CheckEnemyBlockCollision(HashSet<IEnemy> enemies, HashSet<IBlock> blocks)
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (IBlock block in blocks)
                {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(enemy.HitBox, block.HitBox), enemy.HitBox, block.HitBox);
                        EnemyBlockCollisionHandler.HandleCollision(enemy, block, side);
                }
            }
        }

        /*private static void CheckItemBlockCollision(IList<IItem> items, IList<IBlock> blocks, IWorld world)
        {
            foreach (IItem item in items)
            {
                foreach (IBlock block in blocks)
                {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(item.HitBox, block.HitBox), item.HitBox, block.HitBox);
                        ItemBlockCollisionHandler.HandleCollision(item, block, side, world);
                }
            }
        }*/

        private static void CheckProjectileBlockCollision(HashSet<IProjectile> projectiles, HashSet<IBlock> blocks, IWorld world)
        {
            foreach (IProjectile projectile in projectiles)
            {
                foreach (IBlock block in blocks)
                {
                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(projectile.HitBox, block.HitBox), projectile.HitBox, block.HitBox);
                    ProjectileBlockCollisionHandler.HandleCollision(projectile, side, world);
                }
            }
        }

        private static void CheckProjectileEnemyCollision(HashSet<IProjectile> projectiles, HashSet<IEnemy> enemies, IWorld world)
        {
            foreach(IProjectile projectile in projectiles)
            {
                foreach (IEnemy enemy in enemies)
                {
                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(projectile.HitBox, enemy.HitBox), projectile.HitBox, enemy.HitBox);
                    ProjectileEnemyCollisionHandler.HandleCollision(projectile, enemy, side, world);
                }
            }
        }

        /* Helper Method*/
        private static CollisionSide GetCollisionSide(Rectangle intersection, Rectangle HitBox1, Rectangle HitBox2)
        {
            CollisionSide side;
            if (!intersection.IsEmpty)
                side = intersection.Width >= intersection.Height ? (HitBox1.Top <= HitBox2.Top ? CollisionSide.Top : CollisionSide.Bottom) : (HitBox1.Left <= HitBox2.Left ? CollisionSide.Left : CollisionSide.Right);
            else
                side = CollisionSide.None;
            return side;
        }

        private static bool CheckIndexOutOfBounds(int x, int y, IWorld world)
        {
            return (x > 0 && x < (world as World).WorldGridWidth && y > 0 && y < (world as World).WorldGridHeight);
        }
    }
}
