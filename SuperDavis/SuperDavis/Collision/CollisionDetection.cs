using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using SuperDavis.Object.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CheckMarioBlockCollision(World.Davises, World.Blocks);
            CheckMarioItemCollision(World.Davises, World.Items);
            CheckMarioEnemyCollision(World.Davises, World.Enemies);
        }
                   

        private static void CheckMarioBlockCollision(IList<IDavis> davises, IList<IBlock> blocks)
        {
            foreach (IDavis davis in davises)
            {
                foreach(IBlock block in blocks)
                {
                    if (!block.Remove)
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, block.HitBox), davis.HitBox, block.HitBox);
                        MarioBlockCollisionHandler.HandleCollision(davis, block, side);
                    }
                   
                }
            }
        }

        private static void CheckMarioItemCollision(IList<IDavis> davises, IList<IItem> items)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IItem item in items)
                {
                    if (!item.Remove)
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, item.HitBox), davis.HitBox, item.HitBox);
                        MarioItemCollisionHandler.HandleCollision(davis, item, side);
                    }

                }
            }
        }

        private static void CheckMarioEnemyCollision(IList<IDavis> davises, IList<IEnemy> enemies)
        {
            foreach (IDavis davis in davises)
            {
                foreach (IEnemy enemy in enemies)
                {

                    CollisionSide side = GetCollisionSide(Rectangle.Intersect(davis.HitBox, enemy.HitBox), davis.HitBox, enemy.HitBox);
                    MarioEnemyCollisionHandler.HandleCollision(davis, enemy, side);

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
