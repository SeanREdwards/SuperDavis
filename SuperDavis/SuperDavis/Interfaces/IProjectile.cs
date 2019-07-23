namespace SuperDavis.Interfaces
{
    interface IProjectile : IGameObject
    {
        bool IsExploded { get; set; }
        FacingDirection FacingDirection { get; set; }
        void Explode();
    }
}
