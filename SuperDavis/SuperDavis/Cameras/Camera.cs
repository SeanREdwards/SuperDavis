using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Cameras
{
    class Camera
    {
        private readonly int width, height;
        private readonly IWorld world;
        private Matrix matrix;
        public Camera(IWorld world, int width, int height)
        {
            this.world = world;
            this.width = width;
            this.height = height;

        }

        public Matrix Draw()
        {
            foreach (IDavis davis in world.Davises)
            {
                if (davis.Location.X <= width / 2)
                {
                    matrix = Matrix.CreateTranslation(new Vector3(- width / 2, - height / 2 , 0)) * Matrix.CreateTranslation(new Vector3(width * 0.5f, height * 0.5f, 0));
                }
                else if (davis.Location.X >= world.Width * 4 - width / 2)// right edge of screen, can change later on8
                {
                    matrix = Matrix.CreateTranslation(new Vector3(- world.Width * 4 + width / 2, - height / 2 , 0)) * Matrix.CreateTranslation(new Vector3(width * 0.5f, height * 0.5f, 0));
                }
                else
                {
                    matrix = Matrix.CreateTranslation(new Vector3(-davis.Location.X, -height / 2, 0)) * Matrix.CreateTranslation(new Vector3(width * 0.5f, height * 0.5f, 0));
                }
            }
            return matrix;
        }

    }
}
