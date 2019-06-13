namespace SuperDavis.Interfaces
{
    interface IDavisState : IGameObjectState
    {
        new int Width { get; set; }
        new int Height { get; set; }
        void Static();
        void Left();
        void Right();
        void Up();
        void Down();
        void Death();
        void SpecialAttack();
    }
}
