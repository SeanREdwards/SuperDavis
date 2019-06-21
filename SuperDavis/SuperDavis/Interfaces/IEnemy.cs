namespace SuperDavis.Interfaces
{
    interface IEnemy : IGameObject
    {
        bool FacingLeft { get; set; }
        bool Dead { get; set; }
        void TakeDamage();
    }
}
