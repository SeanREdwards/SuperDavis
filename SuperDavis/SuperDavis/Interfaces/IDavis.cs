namespace SuperDavis.Interfaces
{
    public enum DavisStatus { Davis, Woody, Bat, Invincible };
    interface IDavis : IGameObject
    {
        IDavisState DavisState { get; set; }
        DavisStatus DavisStatus { get; set; }
        void DavisTurnLeft();
        void DavisTurnRight();
        void DavisJump();
        void DavisCrouch();
        void DavisToDavis();
        void DavisToWoody();
        void DavisToBat();
        void DavisToInvincible();
        void DavisDeath();
        void DavisSpecialAttack();
        void Reset();
    }
}
