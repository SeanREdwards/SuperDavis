namespace SuperDavis.Interfaces
{
    interface IDavisSpriteState : IGameObjectSpriteState
    {
        new float Width { get; set; }
        new float Height { get; set; }
        void Static();
        void Left();
        void Right();
        void Up();
        void Down();
        void Death();
        void SpecialAttack();
    }
}
