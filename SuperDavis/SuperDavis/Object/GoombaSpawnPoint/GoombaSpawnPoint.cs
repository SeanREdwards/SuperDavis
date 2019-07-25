using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;
using System;
using System.Collections.Generic;

namespace SuperDavis.Object.SpawnPoint
{
    class GoombaSpawnPoint : IBlock
    {
        public bool IsBumped { get; set; }
        public bool IsHidden { get; set; }
        public Rectangle HitBox { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }


        public Vector2 Location { get; set; }
        private readonly IWorld world;
        private readonly ISprite sprite;
        private int spawnTimeInterval = 100;
        private bool spawnFacingTick = true;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;

        public IList<IEnemy> EnemySpawnPool { get; set; }


        public GoombaSpawnPoint(Vector2 location, IWorld world)
        {
            // initial state
            this.world = world;
            Location = location;
            sprite = ItemSpriteFactory.Instance.CreateEmptyBlock();
            EnemySpawnPool = new List<IEnemy>()
            {
                (new Goomba(location, FacingDirection.Left)),
            };

        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (Math.Abs(world.Characters.Location.X - Location.X) < 250)
            {
                if (spawnTimeInterval == 0)
                {
                    Random random = new Random();
                    world.AddObject(EnemySpawnPool[0]);
                    EnemySpawnPool.RemoveAt(0);
                    var facingDirection = FacingDirection.Left;
                    if (spawnFacingTick)
                        facingDirection = FacingDirection.Right;
                    spawnFacingTick = !spawnFacingTick;
                    // Random location setup
                    EnemySpawnPool.Add(new Goomba(Location, facingDirection));
                    if (random.Next(2) <= 1)
                        world.Enemies[world.Enemies.Count - 1].Jump();
                    spawnTimeInterval = 100;
                }
                spawnTimeInterval--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void SpecialState()
        {

        }
    }
}
