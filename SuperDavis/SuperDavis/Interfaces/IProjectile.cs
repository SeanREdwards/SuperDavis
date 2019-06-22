namespace SuperDavis.Interfaces
{
    interface IProjectile : IGameObject
    {
        bool FacingLeft { get; set; }
        void Explode();
        void Clear();
    }
}
