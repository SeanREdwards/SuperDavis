using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
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
            CheckDavisBlockCollision(World.Characters, World.Blocks, World);
            CheckDavisItemCollision(World.Characters, World.Items, World);
            CheckDavisEnemyCollision(World.Characters, World.Enemies, World);
            CheckEnemyBlockCollision(World.Enemies, World.Blocks);
            CheckProjectileBlockCollision(World.Projectiles, World.Blocks, World);
            CheckProjectileEnemyCollision(World.Projectiles, World.Enemies, World);
        }
                   
        private static void CheckDavisBlockCollision(IList<IDavis> davises, IList<IBlock> blocks, IWorld world)
        {
            foreach (IDavis davis in davises)
            {
                foreach(IBlock block in blocks)
                {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, block.HitBox), davis.HitBox, block.HitBox);
                        DavisBlockCollisionHandler.HandleCollision(davis, block, side, world);
                }
            }
        }

        private static void CheckDavisItemCollision(IList<IDavis> davises, IList<IItem> items, IWorld world)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IItem item in items)
                {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, item.HitBox), davis.HitBox, item.HitBox);
                        DavisItemCollisionHandler.HandleCollision(davis, item, side, world);
                }
            }
        }

        private static void CheckDavisEnemyCollision(IList<IDavis> davises, IList<IEnemy> enemies, IWorld world)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IEnemy enemy in enemies)
                {
                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, enemy.HitBox), davis.HitBox, enemy.HitBox);
                    DavisEnemyCollisionHandler.HandleCollision(davis, enemy, side, world);
                }
            }
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
            if (!((intersection.Width == 0) && (intersection.Height == 0)))
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
