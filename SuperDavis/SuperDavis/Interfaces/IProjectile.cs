namespace SuperDavis.Interfaces
{
    interface IProjectile : IGameObject
    {
        FacingDirection FacingDirection { get; set; }
        void Explode();
    }
}
