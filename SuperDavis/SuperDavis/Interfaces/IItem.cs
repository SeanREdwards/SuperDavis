namespace SuperDavis.Interfaces
{
    interface IItem : IGameObject
    {
        bool IsAnimated { get; set; }
        bool FacingLeft { get; set; }
        void Clear();
    }
}
