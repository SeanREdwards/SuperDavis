using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;
using System.Collections.Generic;
using SuperDavis.Physics;
using SuperDavis.Object.Item;
using System;

namespace SuperDavis.Object.Character
{
    class Davis : IDavis
    {
        public float Mass { get; set; }
        private readonly CharacterDictionary charDict;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                OnPositionChanged?.Invoke(this, Tuple.Create(location, value));
                location = value;
            }
        }
        public bool FacingLeft { get; set; }
        public IDavisState DavisState { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        public IList<IProjectile> DavisProjectile { get; set; }

        public DavisStatus DavisStatus { get; set; }
        public DavisStatus PrevDavisStatus { get; set; }
        public Rectangle HitBox { get; set; }
        public int InvincibleTimer { get; set; }
        public ISprite Sprite { get; set; }

        public Davis(Vector2 location)
        {
            //Instantiate character dictionary
            charDict = new CharacterDictionary();

            // initial state
            InvincibleTimer = Variables.Variable.InvincibleTimer;
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
            FacingLeft = false;
            //PhysicsState = new FallState(this);
            //PhysicsState.ApplyForce(new Vector2(0, 0));
            Mass = 5f;
            Location = location;
            DavisProjectile = new List<IProjectile>()
            {
                (new BatProjectile(location,FacingLeft)),
                (new BatProjectile(location,FacingLeft))
            };
        }

        public void Update(GameTime gameTime)
        {
            //For seperating sprite from state
            Sprite.Update(gameTime);

            PhysicsState.Update(gameTime);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)Sprite.Width, (int)Sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //for seperating sprite from state.
            Sprite.Draw(spriteBatch, Location);

            //DavisState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisStatic()
        {
            DavisState.Static();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }
        public void DavisTurnLeft()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState))){
                Location += new Vector2(Variables.Variable.LeftDistance, 0);
                FacingLeft = true;
                DavisState.Left();
                Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
            }
        }

        public void DavisTurnRight()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                Location += new Vector2(Variables.Variable.RightDistance, 0);
                FacingLeft = false;
                DavisState.Right();
                Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
            }
        }

        public void DavisJump()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                /*if (!(PhysicsState is JumpState) && !(PhysicsState is FallState))
                    PhysicsState = new JumpState(this);
                    DavisState.Up();
                    Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
                    */
            }
        }

        public void DavisCrouch()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                DavisState.Down();
                Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
            }
        }

        public void DavisLand()
        {
            DavisState.Land();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

       /* public void TakeDamage()
        {
            DavisState.Death();
        }*/

        public void DavisToDavis()
        {
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        public void DavisToWoody()
        {
            DavisStatus = DavisStatus.Woody;
            DavisState = new DavisStaticRightState(this);
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        public void DavisToBat()
        {
            DavisStatus = DavisStatus.Bat;
            DavisState = new DavisStaticRightState(this);

            //DavisStatus.GetMethod().Name;
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        public void DavisDeath()
        {
            DavisState.Death();
            //Console.Out.WriteLine("Status: " + DavisStatus.ToString() + " State: " + DavisState.ToString());
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }

        public void DavisSpecialAttack()
        {
            DavisState.SpecialAttack();
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
        }
        public void DavisToInvincible()
        {
            /*
            PrevDavisStatus = DavisStatus;
            DavisStatus = DavisStatus.Invincible;
            DavisState = new DavisStaticRightState(this);
            */
        }
    }
}
