using System.Collections.Generic;

namespace SuperDavis.Interfaces
{
    public enum DavisStatus { Davis, Woody, Bat, Invincible };
    interface IDavis : IGameObject
    {
        bool FacingLeft { get; set; }
        int InvincibleTimer { get; set; }
        IDavisState DavisState { get; set; }
        DavisStatus DavisStatus { get; set; }
        DavisStatus PrevDavisStatus { get; set; }
        IList<IProjectile> DavisProjectile { get; set; }
        void DavisStatic();
        void DavisTurnLeft();
        void DavisTurnRight();
        void DavisJump();
        void DavisCrouch();
        void DavisLand();
        void DavisToDavis();
        void DavisToWoody();
        void DavisToBat();
        void DavisToInvincible();
        void DavisDeath();
        void DavisSpecialAttack();
    }
}
