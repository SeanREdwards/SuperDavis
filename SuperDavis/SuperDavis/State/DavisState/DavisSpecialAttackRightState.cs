﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interfaces;

namespace SuperDavis.State.DavisState
{
    class DavisSpecialAttackRightState : IDavisState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly IDavis davis;
        public ISprite Sprite { get; set; }

        public DavisSpecialAttackRightState(IDavis davis)
        {
            this.davis = davis;
            switch (davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    Sprite = DavisSpriteFactory.Instance.CreateDavisSpecialAttackOneRight();
                    break;
                case DavisStatus.Woody:
                    Sprite = DavisSpriteFactory.Instance.CreateWoodySpecialAttackOneRight();
                    break;
                case DavisStatus.Bat:
                    Sprite = DavisSpriteFactory.Instance.CreateBatSpecialAttackOneRight();
                    break;
                case DavisStatus.Invincible:
                    Sprite = DavisSpriteFactory.Instance.CreateBatSpecialAttackOneRight();
                    break;
                default:
                    break;
            }
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Static()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }
        public void Left()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
        }

        public void Right()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Up() { }

        public void Down()
        {
            davis.DavisState = new DavisStaticRightState(davis);
        }

        public void Death()
        {
            davis.DavisState = new DavisDeathRightState(davis);
        }

        public void SpecialAttack()
        {
            //Do Nothing.
        }

        public void Update(GameTime gameTime)
        {
            if (davis.DavisStatus == DavisStatus.Invincible)
            {
                davis.InvincibleTimer--;
                if (davis.InvincibleTimer <= 0)
                {
                    davis.DavisStatus = davis.PrevDavisStatus;
                    davis.DavisState.Static();
                    davis.InvincibleTimer = 100;
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
