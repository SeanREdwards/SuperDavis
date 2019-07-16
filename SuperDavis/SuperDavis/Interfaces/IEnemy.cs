namespace SuperDavis.Interfaces
{
    interface IEnemy : IGameObject
    {
        FacingDirection FacingDirection { get; set;}
        bool Dead { get; set; }
        void TakeDamage();
    }
}
