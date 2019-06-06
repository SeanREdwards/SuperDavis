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
        public IWorldCreator World { get; set; }

        public CollisionDetection(IWorldCreator world)
        {
            this.World = world;
        }

        /* CheckCollisions */
        public void CheckCollisions()
        {
            CheckMarioBlockCollision(World.Davises,World.Blocks);
        }

        //Since we haven't have a created the level file, it can not use surrounding checking
        //Comment out for future use
        /*
        private void CheckMarioSurroundingBlock()
        {
            IBlock block = new Brick(new Vector2(0, 0));
            float davisLocationX = World.davis.Location.X;
            float davisLocationY = World.davis.Location.Y;
            int blocksWidth = block.HitBox.Width;
            int blocksHeight = block.HitBox.Height;
            int blockIndexX = (int)Math.Floor(davisLocationX / blocksWidth);
            int blockIndexY = (int)Math.Floor(davisLocationY / blocksHeight);
            for (int blockIndexOffsetX = -2; blockIndexOffsetX <= 2; blockIndexOffsetX++)
            {
                for (int blockIndexOffsetY = -2; blockIndexOffsetY <= 2; blockIndexOffsetY++)
                {
                    CheckMarioBlockCollision(blockIndexX + blockIndexOffsetX, blockIndexY + blockIndexOffsetY);
                }
            }

        }
        */
        

        private void CheckMarioBlockCollision(IList<IDavis> Davises, IList<IBlock> Blocks)
        {
            /*bool marioIsInHorizontalScope = blockIndexX >= 0 && blockIndexX < World.Width;
            bool marioIsInVerticalScope = blockIndexY >= 0 && blockIndexY < World.Height;
            if (marioIsInHorizontalScope && marioIsInVerticalScope)
            {
                IBlock block = World.Blocks[blockIndexX][blockIndexY];
                Rectangle marioHitbox = World.Mario.Rectangle;
                if (block != null)
                {
                    Rectangle blockHitbox = block.Rectangle;
                    Rectangle intersection = Rectangle.Intersect(marioHitbox, blockHitbox);

                    if (!intersection.IsEmpty)
                    {
                        CollisionSide side = GetCollisionSide(intersection, marioHitbox, blockHitbox);
                        MarioBlockCollisionHandler.HandleCollision(World.Mario, block, side, superMarioBro);
                    }
                }
            }*/
            foreach (IDavis Davis in Davises)
            {
                foreach(IBlock Block in Blocks)
                {
                    if (Davis.HitBox.Intersects(Block.HitBox))
                    {
                        CollisionSide side = GetCollisionSide(Rectangle.Intersect(Davis.HitBox, Block.HitBox), Davis.HitBox, Block.HitBox);
                        MarioCollisionHandler.HandleCollision(Davis, Block, side);
                    }
                }
            }
        }

        private CollisionSide GetCollisionSide(Rectangle intersection, Rectangle HitBox1, Rectangle HitBox2)
        {
            CollisionSide side;
            if (intersection != null)
            {
                if (intersection.Width >= intersection.Height)
                {
                    if (HitBox1.Top <= HitBox2.Top)
                    {
                        side = CollisionSide.Top;
                    }
                    else
                    {
                        side = CollisionSide.Bottom;
                    }
                }
                else
                {
                    if (HitBox1.Left <= HitBox2.Left)
                    {
                        side = CollisionSide.Left;
                    }
                    else
                    {
                        side = CollisionSide.Right;
                    }
                }
            }
            else
            {
                side = CollisionSide.None;
            }
            System.Console.WriteLine(side);
            return side;
        }
    }
}
