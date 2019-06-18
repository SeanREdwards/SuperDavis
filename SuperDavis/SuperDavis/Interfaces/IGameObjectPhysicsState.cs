using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Interfaces
{
    interface IGameObjectPhysicsState
    {
        void Jump();
        void Fall();
        void Stand();
        void WalkLeft();
        void WalkRight();
        void RunLeft();
        void RunRight();
        void Update(GameTime gameTime);
    }
}
