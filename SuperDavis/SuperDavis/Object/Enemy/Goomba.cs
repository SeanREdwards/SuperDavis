using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interface;
using SuperDavis.State.DavisState;
using SuperDavis.State.EnemyState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Object.Enemy
{
    class Goomba : IEnemy
    {
        public Vector2 Location { get; set; }
        private readonly GoombaStateMachine goombaStateMachine;

        public Goomba(Vector2 location)
        {
            // initial state
            Location = location;
            goombaStateMachine = new GoombaStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            goombaStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaStateMachine.Draw(spriteBatch, Location);
        }
    }
}
