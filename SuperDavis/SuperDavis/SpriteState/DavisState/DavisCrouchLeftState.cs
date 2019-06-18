﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.SpriteState.DavisState
{
    class DavisCrouchLeftState : IDavisSpriteState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisCrouchLeftState(IDavis davis)
        {
            this.davis = davis;
            switch(davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    Sprite = DavisSpriteFactory.Instance.CreateDavisCrouchLeft();
                    break;
                case DavisStatus.Woody:
                    Sprite = DavisSpriteFactory.Instance.CreateWoodyCrouchLeft();
                    break;
                case DavisStatus.Bat:
                    Sprite = DavisSpriteFactory.Instance.CreateBatCrouchLeft();
                    break;
                case DavisStatus.Invincible:
                    Sprite = DavisSpriteFactory.Instance.CreateBatSpecialAttackOneLeft();
                    break;
                default:
                    break;
            }
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Static()
        {
            davis.DavisSpriteState = new DavisStaticLeftState(davis);
        }

        public void Left()
        {
            davis.DavisSpriteState = new DavisStaticLeftState(davis);
        }

        public void Right()
        {
            davis.DavisSpriteState = new DavisStaticRightState(davis);
        }

        public void Up()
        {
            davis.DavisSpriteState = new DavisStaticLeftState(davis);
        }

        public void Down()
        {
            // Do nothing
        }

        public void Death()
        {
            davis.DavisSpriteState = new DavisDeathLeftState(davis);
        }

        public void SpecialAttack()
        {
            davis.DavisSpriteState = new DavisSpecialAttackLeftState(davis);
        }

        public void Update(GameTime gameTime)
        {
            if (davis.DavisStatus == DavisStatus.Invincible)
            {
                davis.InvincibleTimer--;
                if (davis.InvincibleTimer <= 0)
                {
                    davis.DavisStatus = davis.PrevDavisStatus;
                    davis.DavisSpriteState.Static();
                    davis.InvincibleTimer = Variables.Variable.InvincibleTimer;
                }
            }
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}