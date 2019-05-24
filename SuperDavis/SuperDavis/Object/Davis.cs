using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interface;
using SuperDavis.State.DavisState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Object
{
    class Davis : IDavis
    {
        public IDavisState DavisState { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }

        public Davis()
        {
            // initial state
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
            Location = new Vector2(100, 100);
        }

        public void Update(GameTime gameTime)
        {
            DavisState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisTurnLeft()
        {
            this.DavisState.Left();
        }

        public void DavisTurnRight()
        {
            this.DavisState.Right();
        }

        public void DavisJump()
        {
            throw new NotImplementedException();
        }

        public void DavisCrouch()
        {
            throw new NotImplementedException();
        }

        public void DavisToDavis()
        {
            throw new NotImplementedException();
        }

        public void DavisToWoody()
        {
            throw new NotImplementedException();
        }

        public void DavisToBat()
        {
            throw new NotImplementedException();
        }

        public void DavisDead()
        {
            throw new NotImplementedException();
        }
    }
}
