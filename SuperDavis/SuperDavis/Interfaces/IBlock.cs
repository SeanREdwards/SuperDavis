using Microsoft.Xna.Framework;

namespace SuperDavis.Interfaces
{

    interface IBlock : IGameObject
    {
        bool IsHidden { get; set; }
        void SpecialState();
        void Reset();
    }
}
