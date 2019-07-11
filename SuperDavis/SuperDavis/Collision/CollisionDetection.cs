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
            CheckCharactersSurroundingBox(World.Characters, World);
            CheckEnemySurroundingBox(World.Enemies, World);
            CheckProjectileSurroundingBox(World.Projectiles, World);
            //CheckItemSurroundingBox(World.Items, World);
        }
        
        private static void CheckCharactersSurroundingBox(HashSet<IDavis> movers, IWorld world)
        {
            foreach(IDavis mover in movers)
            { 
                var i = (int)(mover.Location.X / (world as World).UNIT_SIZE);
                var j = (int)(mover.Location.Y / (world as World).UNIT_SIZE);
                if (!(world as World).IsIndexOutOfBounds(i, j))
                {
                    // Get instance of character reference in the World Grid
                    IDavis moverObject = (IDavis)world.GetObject(mover, i, j);
  
                    if (moverObject != null)
                    {
                        int hitBoxWidthScaleFactor = (int)(moverObject.HitBox.Width / (world as World).UNIT_SIZE) + 1;
                        int hitBoxHeightScaleFactor = (int)(moverObject.HitBox.Height / (world as World).UNIT_SIZE) + 1;
                        int offsetFactor = Variables.Variable.offsetRange; // Magic number here!

                        for (int iOffset = -offsetFactor*hitBoxWidthScaleFactor; iOffset < (offsetFactor+1) * hitBoxWidthScaleFactor; iOffset++)
                              for (int jOffset = -offsetFactor*hitBoxHeightScaleFactor; jOffset < (offsetFactor+1) * hitBoxHeightScaleFactor; jOffset++)
                                   if (!(world as World).IsIndexOutOfBounds(i + iOffset, j + jOffset))
                                        if (world.WorldGrid[i + iOffset][j + jOffset].Count != 0)
                                            for(int k = 0; k < world.WorldGrid[i+iOffset][j+jOffset].Count; k++)
                                            {
                                                var target = world.WorldGrid[i + iOffset][j + jOffset][k];
                                                if (!target.Equals(mover) && (target is IBlock || target is IItem || target is IEnemy))
                                                {
                                                    var side = GetCollisionSide(Rectangle.Intersect(moverObject.HitBox, target.HitBox), moverObject.HitBox, target.HitBox);
                                                    if (side != CollisionSide.None)
                                                    {
                                                        if (target is IBlock) DavisBlockCollisionHandler.HandleCollision(moverObject, (IBlock)target, side, world);
                                                        if (target is IItem) DavisItemCollisionHandler.HandleCollision(moverObject, (IItem)target, side, world);
                                                        if (target is IEnemy) DavisEnemyCollisionHandler.HandleCollision(moverObject, (IEnemy)target, side, world);
                                                    }
                                                }
                                            }
                    }
                }
            }
        }

        private static void CheckEnemySurroundingBox(HashSet<IEnemy> movers, IWorld world)
        {
            foreach (IEnemy mover in movers)
            {
                var i = (int)(mover.Location.X / (world as World).UNIT_SIZE);
                var j = (int)(mover.Location.Y / (world as World).UNIT_SIZE);
                if (!(world as World).IsIndexOutOfBounds(i, j))
                {
                    // Get instance of character reference in the World Grid
                    IEnemy moverObject = (IEnemy)world.GetObject(mover, i, j);

                    if (moverObject != null)
                    {
                        int hitBoxWidthScaleFactor = (int)(moverObject.HitBox.Width / (world as World).UNIT_SIZE) + 1;
                        int hitBoxHeightScaleFactor = (int)(moverObject.HitBox.Height / (world as World).UNIT_SIZE) + 1;
                        int offsetFactor = Variables.Variable.offsetRange; // Magic number here!

                        for (int iOffset = -offsetFactor * hitBoxWidthScaleFactor; iOffset < (offsetFactor + 1) * hitBoxWidthScaleFactor; iOffset++)
                            for (int jOffset = -offsetFactor * hitBoxHeightScaleFactor; jOffset < (offsetFactor + 1) * hitBoxHeightScaleFactor; jOffset++)
                                if (!(world as World).IsIndexOutOfBounds(i + iOffset, j + jOffset))
                                    if (world.WorldGrid[i + iOffset][j + jOffset].Count != 0)
                                        for (int k = 0; k < world.WorldGrid[i + iOffset][j + jOffset].Count; k++)
                                        {
                                            var target = world.WorldGrid[i + iOffset][j + jOffset][k];
                                            if (!target.Equals(mover) && (target is IBlock))
                                            {
                                                var side = GetCollisionSide(Rectangle.Intersect(moverObject.HitBox, target.HitBox), moverObject.HitBox, target.HitBox);
                                                if (target is IBlock) EnemyBlockCollisionHandler.HandleCollision(moverObject, (IBlock)target, side);
                                            }
                                        }
                    }
                }
            }
        }

        private static void CheckProjectileSurroundingBox(HashSet<IProjectile> movers, IWorld world)
        {
            foreach (IProjectile mover in movers)
            {
                var i = (int)(mover.Location.X / (world as World).UNIT_SIZE);
                var j = (int)(mover.Location.Y / (world as World).UNIT_SIZE);
                if (!(world as World).IsIndexOutOfBounds(i, j))
                {
                    // Get instance of character reference in the World Grid
                    IProjectile moverObject = (IProjectile)world.GetObject(mover, i, j);

                    if (moverObject != null)
                    {
                        int hitBoxWidthScaleFactor = (int)(moverObject.HitBox.Width / (world as World).UNIT_SIZE) + 1;
                        int hitBoxHeightScaleFactor = (int)(moverObject.HitBox.Height / (world as World).UNIT_SIZE) + 1;
                        int offsetFactor = Variables.Variable.offsetRange; // Magic number here!

                        for (int iOffset = -offsetFactor * hitBoxWidthScaleFactor; iOffset < (offsetFactor + 1) * hitBoxWidthScaleFactor; iOffset++)
                            for (int jOffset = -offsetFactor * hitBoxHeightScaleFactor; jOffset < (offsetFactor + 1) * hitBoxHeightScaleFactor; jOffset++)
                                if (!(world as World).IsIndexOutOfBounds(i + iOffset, j + jOffset))
                                    if (world.WorldGrid[i + iOffset][j + jOffset].Count != 0)
                                        for (int k = 0; k < world.WorldGrid[i + iOffset][j + jOffset].Count; k++)
                                        {
                                            var target = world.WorldGrid[i + iOffset][j + jOffset][k];
                                            if (!target.Equals(mover) && (target is IBlock || target is IEnemy))
                                            {
                                                var side = GetCollisionSide(Rectangle.Intersect(moverObject.HitBox, target.HitBox), moverObject.HitBox, target.HitBox);
                                                if (side != CollisionSide.None)
                                                {
                                                    if (target is IBlock) ProjectileBlockCollisionHandler.HandleCollision(moverObject, side, world);
                                                    if (target is IEnemy) ProjectileEnemyCollisionHandler.HandleCollision(moverObject, (IEnemy)target, side, world);
                                                }
                                            }
                                        }
                    }
                }
            }
        }

        // TBD: item collision detection

        /* Helper Method */
        private static CollisionSide GetCollisionSide(Rectangle intersection, Rectangle HitBox1, Rectangle HitBox2)
        {
            CollisionSide side;
            if (!intersection.IsEmpty)
                side = intersection.Width >= intersection.Height ? (HitBox1.Top <= HitBox2.Top ? CollisionSide.Top : CollisionSide.Bottom) : (HitBox1.Left <= HitBox2.Left ? CollisionSide.Left : CollisionSide.Right);
            else
                side = CollisionSide.None;
            return side;
        }
    }
}
