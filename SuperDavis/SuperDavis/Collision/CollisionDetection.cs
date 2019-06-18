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
            CheckDavisBlockCollision(World.Davises, World.Blocks);
            CheckDavisItemCollision(World.Davises, World.Items);
            CheckDavisEnemyCollision(World.Davises, World.Enemies);
            CheckEnemyBlockCollision(World.Enemies, World.Blocks);
        }
                   
        private static void CheckDavisBlockCollision(IList<IDavis> davises, IList<IBlock> blocks)
        {
            foreach (IDavis davis in davises)
            {
                foreach(IBlock block in blocks)
                {
                    if (!block.Remove)
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, block.HitBox), davis.HitBox, block.HitBox);
                        DavisBlockCollisionHandler.HandleCollision(davis, block, side);
                    }
                   
                }
            }
        }

        private static void CheckDavisItemCollision(IList<IDavis> davises, IList<IItem> items)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IItem item in items)
                {
                    if (!item.Remove)
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, item.HitBox), davis.HitBox, item.HitBox);
                        DavisItemCollisionHandler.HandleCollision(davis, item, side);
                    }
                }
            }
        }

        private static void CheckDavisEnemyCollision(IList<IDavis> davises, IList<IEnemy> enemies)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IEnemy enemy in enemies)
                {
                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, enemy.HitBox), davis.HitBox, enemy.HitBox);
                    DavisEnemyCollisionHandler.HandleCollision(davis, enemy, side);
                }
            }
        }

        private static void CheckEnemyBlockCollision(IList<IEnemy> enemies, IList<IBlock> blocks)
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (IBlock block in blocks)
                {
                    if (!block.Remove)
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(enemy.HitBox, block.HitBox), enemy.HitBox, block.HitBox);
                        EnemyBlockCollisionHandler.HandleCollision(enemy, block, side);
                    }
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
