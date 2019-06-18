using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.SpriteState.DavisState;
using SuperDavis.Factory;
using System.Collections.Generic;
using SuperDavis.PhysicsState;

namespace SuperDavis.Object.Character
{
    class Davis : IDavis
    {
        public bool Remove { get; set; }
        public IDavisSpriteState DavisSpriteState { get; set; }
        public IGameObjectPhysicsState PhysicsState { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }
        public DavisStatus PrevDavisStatus { get; set; }
        public Rectangle HitBox { get; set; }
        public int InvincibleTimer { get; set; }
    
        public Davis(Vector2 location)
        {
            // initial state
            InvincibleTimer = Variables.Variable.InvincibleTimer;
            DavisStatus = DavisStatus.Davis;
            DavisSpriteState = new DavisStaticRightState(this);
            PhysicsState = new JumpState(this);
            Location = location;
        }

        public void Update(GameTime gameTime)
        {
            DavisSpriteState.Update(gameTime);
            PhysicsState.Update(gameTime);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)DavisSpriteState.Width, (int)DavisSpriteState.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DavisSpriteState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisStatic()
        {
            DavisSpriteState.Static();
        }
        public void DavisTurnLeft()
        {
            if (!((DavisSpriteState is DavisDeathLeftState) || (DavisSpriteState is DavisDeathRightState))){
                Location += new Vector2(-2, 0);
            }
            DavisSpriteState.Left();
        }

        public void DavisTurnRight()
        {
            if (!((DavisSpriteState is DavisDeathLeftState) || (DavisSpriteState is DavisDeathRightState)))
            {
                Location += new Vector2(2, 0);
            }
            DavisSpriteState.Right();
        }

        public void DavisJump()
        {
            if (!((DavisSpriteState is DavisDeathLeftState) || (DavisSpriteState is DavisDeathRightState)))
            {
                if (!(PhysicsState is JumpState))
                    PhysicsState = new JumpState(this);
            }
            DavisSpriteState.Up();
        }

        public void DavisCrouch()
        {
            if (!((DavisSpriteState is DavisDeathLeftState) || (DavisSpriteState is DavisDeathRightState)))
            {
                
            }
            DavisSpriteState.Down();
        }

        public void DavisToDavis()
        {
            DavisStatus = DavisStatus.Davis;
            DavisSpriteState = new DavisStaticRightState(this);
        }

        public void DavisToWoody()
        {
            DavisStatus = DavisStatus.Woody;
            DavisSpriteState = new DavisStaticRightState(this);
        }

        public void DavisToBat()
        {
            DavisStatus = DavisStatus.Bat;
            DavisSpriteState = new DavisStaticRightState(this);
        }

        public void DavisDeath()
        {
            DavisSpriteState.Death();
        }

        public void DavisSpecialAttack()
        {
            DavisSpriteState.SpecialAttack();
        }
        public void DavisToInvincible()
        {
            PrevDavisStatus = DavisStatus;
            DavisStatus = DavisStatus.Invincible;
            DavisSpriteState = new DavisStaticRightState(this);
        }

        public void Reset()
        {
            DavisStatus = DavisStatus.Davis;
            DavisSpriteState = new DavisStaticRightState(this);
            Location = new Vector2(Variables.Variable.WindowsEdgeWidth/2 , Variables.Variable.WindowsEdgeHeight/2);
        }
    }
}
