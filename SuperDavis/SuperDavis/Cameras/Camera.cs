using Microsoft.Xna.Framework;
using SuperDavis.Interfaces;

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
            var davis = world.Characters;
            {
                if (davis.Location.X <= width / Variables.Variable.CameraDivisor)
                {
                    matrix = Matrix.CreateTranslation(new Vector3(- width / Variables.Variable.CameraDivisor, - height / Variables.Variable.CameraDivisor, 0)) * Matrix.CreateTranslation(new Vector3(width * Variables.Variable.CameraModifier, height * Variables.Variable.CameraModifier, 0));
                }
                else if (davis.Location.X >= world.Width * Variables.Variable.CameraWorldWidthMultiplier - width / Variables.Variable.CameraDivisor)// right edge of screen, can change later on8
                {
                    matrix = Matrix.CreateTranslation(new Vector3(- world.Width * Variables.Variable.CameraWorldWidthMultiplier + width / Variables.Variable.CameraDivisor, - height / Variables.Variable.CameraDivisor , 0)) * Matrix.CreateTranslation(new Vector3(width * Variables.Variable.CameraModifier, height * Variables.Variable.CameraModifier, 0));
                }
                else
                {
                    matrix = Matrix.CreateTranslation(new Vector3(-davis.Location.X, -height / Variables.Variable.CameraDivisor, 0)) * Matrix.CreateTranslation(new Vector3(width * Variables.Variable.CameraModifier, height * Variables.Variable.CameraModifier, 0));
                }
            }
            return matrix;
        }
    }
}
