using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interface;
using SuperDavis.State.DavisState;
using SuperDavis.State.ItemStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Object.Item
{
    class HealthMushroom : IItem
    {
        public Vector2 Location { get; set; }
        private readonly HealthMushroomStateMachine healthMushroomStateMachine;

        public HealthMushroom(Vector2 location)
        {
            // initial state
            Location = location;
            healthMushroomStateMachine = new HealthMushroomStateMachine();
        }

        public void Update(GameTime gameTime)
        {
            healthMushroomStateMachine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            healthMushroomStateMachine.Draw(spriteBatch, Location);
        }
    }
}
