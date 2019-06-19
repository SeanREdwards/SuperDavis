using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

namespace SuperDavis.Physics
{

    class StandingState : IGameObjectPhysics
    {
        // Idea, by passing different igameobject, implement different 
        // param for jumping, using lists
        public StandingState(IGameObject gameObjectClass)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
