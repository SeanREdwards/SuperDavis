using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Interface
{
    interface IGameObject
    {
        Vector2 Location { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spritebatch);
    }
}
