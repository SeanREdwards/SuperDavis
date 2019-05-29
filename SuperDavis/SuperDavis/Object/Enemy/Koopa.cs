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
    class Koopa : IEnemy
    {
        public Vector2 Location { get; set; }
        private readonly KoopaStateMachine koopaStateMachine;

        public Koopa(Vector2 location)
        {
            // initial state
            Location = location;
            koopaStateMachine = new KoopaStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            koopaStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaStateMachine.Draw(spriteBatch, Location);
        }
    }
}
