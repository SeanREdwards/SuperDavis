using Microsoft.Xna.Framework;

namespace SuperDavis.Interfaces
{

    interface IBlock : IGameObject
    {
        void SpecialState();
        void Reset();
    }
}
