using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;
using SuperDavis.Object.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int spawnTimeInterval = 20;
        private bool spawnFacingTick = true;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;

        public IList<IEnemy> EnemySpawnPool { get; set; }


        public GoombaSpawnPoint(Vector2 location, IWorld world)
        {
            // initial state
            this.world = world;
            Location = location;
            sprite = ItemSpriteFactory.Instance.CreateSkullBlock();
            EnemySpawnPool = new List<IEnemy>()
            {
                (new Goomba(location, FacingDirection.Left)),
            };

        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if(Math.Abs(world.Characters.Location.X - Location.X) < 50)
            {
                if (spawnTimeInterval == 0)
                {
                    world.AddObject(EnemySpawnPool[0]);
                    EnemySpawnPool.RemoveAt(0);
                    var facingDirection = FacingDirection.Left;
                    if (spawnFacingTick)
                        facingDirection = FacingDirection.Right;
                    spawnFacingTick = !spawnFacingTick;
                    EnemySpawnPool.Add(new Goomba(Location, facingDirection));
                    spawnTimeInterval = 20;
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
