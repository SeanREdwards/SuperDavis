using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.State.OtherState
{
    class RemoveState : IGameState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ISprite Sprite { get; set; }
        private readonly IGameObject gameObject;
        private readonly ISprite sprite;
        private int timer;

        public RemoveState(IGameObject gameObject, ISprite sprite, int timer)
        {
            this.gameObject = gameObject;
            this.sprite = sprite;
            this.timer = timer;
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            sprite.Update(gameTime);
            //gameObject.Location += new Vector2(0, 2);

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (timer >= 0)
            {
                sprite.Draw(spriteBatch,location);
            }
        }

    }
}
