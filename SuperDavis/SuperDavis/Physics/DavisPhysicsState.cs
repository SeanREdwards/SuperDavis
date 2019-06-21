using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Physics
{
    class DavisPhysicsState : IGameObjectPhysics
    {
        private readonly IDavis davis;
        public float HorizontalVelocity { get; set; }
        public float VerticalVelocity { get; set; }
        public float HorizontalAcceleration { get; set; }
        public float VerticalAcceleration { get; set; }
        private readonly float gravity;
        private readonly float friction;

        public DavisPhysicsState(IDavis davis)
        {
            this.davis = davis;
            HorizontalVelocity = 0;
            VerticalVelocity = 0;
            gravity = 10f;
            friction = 3f;
            HorizontalVelocity = gravity;
            VerticalAcceleration = 0;
        }

        public void ApplyForce(Vector2 forceVector)
        {
            VerticalAcceleration = forceVector.Y + gravity;
            if (forceVector.X > 0)
                HorizontalAcceleration = forceVector.X - friction;
            else if (forceVector.X < 0)
                HorizontalAcceleration = forceVector.X + friction;
            else
                HorizontalAcceleration = 0;
        }
        public void Update(GameTime gameTime)
        {
            HorizontalVelocity = HorizontalAcceleration * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50;
            VerticalVelocity = VerticalAcceleration * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50; 
            davis.Location += new Vector2(HorizontalVelocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 50, VerticalVelocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            Console.WriteLine(HorizontalVelocity);
            Console.WriteLine(VerticalVelocity);
        }
    }
}
