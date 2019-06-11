namespace SuperDavis.Interfaces
{
     interface IEnemy : IGameObject
    {
        bool Dead { get; set; }
        void TakeDamage();
        void Reset();
    }
}
