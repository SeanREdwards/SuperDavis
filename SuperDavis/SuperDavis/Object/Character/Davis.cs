using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.DavisState;
using System.Collections.Generic;
using SuperDavis.Physics;
using SuperDavis.Object.Item;
using System;
using SuperDavis.Sound;

namespace SuperDavis.Object.Character
{
    class Davis : IDavis
    {
        private readonly CharacterDictionary charDict;

        // Collision Detection Params
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
        public FacingDirection FacingDirection { get; set; }
        public IDavisState DavisState { get; set; }
        public IGameObjectPhysics PhysicsState { get; set; }
        public IList<IProjectile> DavisProjectile { get; set; }

        public DavisStatus DavisStatus { get; set; }
        public DavisStatus PrevDavisStatus { get; set; }
        public Rectangle HitBox { get; set; }

        public ISprite Sprite { get; set; }

        public Davis(Vector2 location)
        {
            PhysicsState = new FallState(this);
            //Instantiate character dictionary
            charDict = new CharacterDictionary();

            // initial state

            DavisStatus = DavisStatus.Invincible;
            DavisState = new DavisStaticRightState(this);
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());

            FacingDirection = FacingDirection.Right;
 
            //PhysicsState.ApplyForce(new Vector2(0, 0));

            Location = location;
            DavisProjectile = new List<IProjectile>()
            {
                (new BatProjectile(location,FacingDirection)),
                (new BatProjectile(location,FacingDirection))
            };
        }

        public void Update(GameTime gameTime)
        {
            Sprite = charDict.GetSprite(DavisStatus.ToString(), DavisState.ToString());
            DavisState.Update(gameTime);
            PhysicsState.Update(gameTime);
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)Sprite.Width, (int)Sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisStatic()
        {
            DavisState.Static();
        }
        public void DavisTurnLeft()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState))){
                FacingDirection = FacingDirection.Left;
                DavisState.Left();
            }
        }

        public void DavisTurnRight()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                FacingDirection = FacingDirection.Right;
                DavisState.Right();
            }
        }

        public void DavisJump()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                if (!(PhysicsState is JumpState) && !(PhysicsState is FallState))
                {
                    PhysicsState = new JumpState(this);
                    Sounds.Instance.SetJump();
                }
                DavisState.Up();
                Sounds.Instance.PlayJump();
            }
        }

        public void DavisCrouch()
        {
            if (!((DavisState is DavisDeathLeftState) || (DavisState is DavisDeathRightState)))
            {
                DavisState.Down();
            }
        }

        public void DavisLand()
        {
            DavisState.Land();
            PhysicsState = new FallState(this);
        }

        public void DavisSlide()
        {
            DavisState.Slide();
        }

       /* public void TakeDamage()
        {
            DavisState.Death();
        }*/


        public void DavisToDavis()
        {
            DavisStatus = DavisStatus.Davis;
            DavisState = new DavisStaticRightState(this);
        }

        public void DavisToWoody()
        {
            DavisStatus = DavisStatus.Woody;
            DavisState = new DavisStaticRightState(this);
        }

        public void DavisToBat()
        {
            DavisStatus = DavisStatus.Bat;
            DavisState = new DavisStaticRightState(this);
        }

        public void DavisDeath()
        {
            DavisState.Death();
            Sounds.Instance.Death.Play();
        }

        public void DavisSpecialAttack()
        {
            DavisState.SpecialAttack();
        }

    }
}
