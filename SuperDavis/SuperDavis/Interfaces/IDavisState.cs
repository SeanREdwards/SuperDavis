namespace SuperDavis.Interfaces
{
    interface IDavisState : IGameState
    {

        void Static();
        void Left();
        void Right();
        void Up();
        void Down();
        void Death();
        void SpecialAttack();
    }
}
