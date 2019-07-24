namespace SuperDavis.Interfaces
{
    interface IEnemy : IGameObject
    {
        FacingDirection FacingDirection { get; set; }
        bool Dead { get; set; }
        void Jump();
        void TakeDamage();
        void ChangeDirection();
    }
}
