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
        
        private static void CheckCharactersSurroundingCollision(IList<IDavis> movers, IWorld world)
        {
            if (!world.TryGetObjects(out IList<IDavis> davis)) return;


            foreach(IDavis mover in movers)
            { 
                var i = (int)(mover.Location.X / Variables.Variable.UnitPixelSize);
                /* Could do WorldGrid[i].length, but since it is a "Grid", i doesn't matter, save space for iteration */
                var j = (int)(mover.Location.Y / Variables.Variable.UnitPixelSize);
                // Initialization for future use
                IList<IDavis> davisList = (world as World).GetObjects<IDavis>();

                IList<IDavis> davisList = new Hash

                IDavis moverObject;
                if (i > 0 && i < world.WorldGrid.Length && j > 0 && j < world.WorldGrid[0].Length)
                    foreach (IGameObject obj in world.WorldGrid[i][j])
                    { 
                        if (obj.Equals(mover))
                            moverObject = (IDavis)obj;
                    }

                for (int iOffset = -1; iOffset < 1; iOffset++)
                    for (int jOffset = -1; jOffset < 1; jOffset++)
                        if((i+iOffset) > 0 && (i+iOffset) < world.WorldGrid.Length && (j+jOffset) > 0 && (j+jOffset) < world.WorldGrid[0].Length)
                            if(world.WorldGrid[i+iOffset][j+jOffset].Count != 0)
                                foreach (IGameObject target in world.WorldGrid[i + iOffset][j + jOffset])
                                {
                                    if(!target.Equals(mover))
                                    {
                                        var side = GetCollisionSide(Rectangle.Intersect(moverObject.HitBox, target.HitBox), mover.HitBox, target.HitBox);
                                        System.Console.WriteLine(moverObject.HitBox + "/" + target.HitBox + side);
                                        if (target is IBlock) CheckDavisBlockCollision(moverObject, (IBlock)target, side, world);
                                        if (target is IItem) CheckDavisItemCollision(moverObject, (IItem)target, side, world);
                                        if (target is IEnemy) CheckDavisEnemyCollision(moverObject, (IEnemy)target, side, world);
                                    }
                                }
            }
        }
        private static void CheckDavisBlockCollision(IDavis davis, IBlock block, CollisionSide side, IWorld world)
        {
            DavisBlockCollisionHandler.HandleCollision(davis, block, side, world);
        }

        private static void CheckDavisItemCollision(IDavis davis, IItem item, CollisionSide side, IWorld world)
        {
            DavisItemCollisionHandler.HandleCollision(davis, item, side, world);
        }

        private static void CheckDavisEnemyCollision(IDavis davis, IEnemy enemy, CollisionSide side, IWorld world)
        {
            DavisEnemyCollisionHandler.HandleCollision(davis, enemy, side, world);
        }

        private static void CheckEnemyBlockCollision(IList<IEnemy> enemies, IList<IBlock> blocks)
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

        private static void CheckProjectileBlockCollision(IList<IProjectile> projectiles, IList<IBlock> blocks, IWorld world)
        {
            for (int i = 0; i < projectiles.Count ; i++)
            {
                foreach (IBlock block in blocks)
                {
                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(projectiles[i].HitBox, block.HitBox), projectiles[i].HitBox, block.HitBox);
                    ProjectileBlockCollisionHandler.HandleCollision(projectiles[i], side, world);
                }
            }
        }

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

        private static CollisionSide GetCollisionSide(Rectangle intersection, Rectangle HitBox1, Rectangle HitBox2)
        {
            CollisionSide side;
            if (!intersection.IsEmpty)
            {
                side = intersection.Width >= intersection.Height ? (HitBox1.Top <= HitBox2.Top ? CollisionSide.Top : CollisionSide.Bottom) : (HitBox1.Left <= HitBox2.Left ? CollisionSide.Left : CollisionSide.Right);
            }
            else
            {
                side = CollisionSide.None;
            }
            return side;
        }
    }
}
