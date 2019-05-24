using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Factory;
using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.State.DavisState
{
    class DavisStaticRightState : IDavisState
    {
        // Needed?
        public int Width { get; set; }
        public int Height { get; set; }

        private IDavis davis;
        private ISprite sprite;

        public DavisStaticRightState(IDavis davis)
        {
            this.davis = davis;
            switch(davis.DavisStatus)
            {
                case DavisStatus.Davis:
                    sprite = DavisSpriteFactory.Instance.CreateDavisStaticRightSprite();
                    break;
                case DavisStatus.Woody:
                    sprite = DavisSpriteFactory.Instance.CreateWoodyStaticRightSprite();
                    break;
                case DavisStatus.Bat:
                    sprite = DavisSpriteFactory.Instance.CreateBatStaticRightSprite();
                    break;
                case DavisStatus.Invincible:
                    // TBD;
                    break;
                default:
                    break;
            }
            // Needed?
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Static() { }
        public void Left()
        {
            davis.DavisState = new DavisStaticLeftState(davis);
        }

        public void Right()
        {
            davis.DavisState = new DavisWalkRightState(davis);
        }

        public void Up()
        {
            //davis.DavisState = new DavisJumpRightState(davis);
        }

        public void Down()
        {
            //davis.DavisState = new DavisCrouchRightState(davis);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
