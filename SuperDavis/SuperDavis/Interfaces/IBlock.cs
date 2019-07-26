namespace SuperDavis.Interfaces
{
    interface IBlock : IGameObject
    {
        bool IsBumped { get; set; }
        bool IsHidden { get; set; }

        void SpecialState();

    }
}
