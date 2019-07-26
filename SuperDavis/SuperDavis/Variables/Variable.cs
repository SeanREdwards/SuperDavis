namespace SuperDavis.Variables
{

    /*Class to hold variables to eliminate magic numbers, will data drive in the refactor from JSON file.*/
    public static class Variable
    {
        public const int Zero = 0;
        public const int One = 1;

        //Game1.cs string variables.
        public const string ContentDirectory = "Content";
        //public const string LevelOne = "demo-level.xml";
        public const string LevelOne = "boss-level.xml";
        //public const string UnderworldLevelOne = "underworld1-1.xml";
        //public const string DemoLevel = "demo-level.xml";
        public const string DemoLevel = "boss-level.xml";

        //Game1.cs reset distances.
        public const int FloorReset = -100;
        public const int CeilingReset = 620;
        public const int RightReset = 3600;

        public const int WindowsEdgeWidth = 1200;
        public const int WindowsEdgeHeight = 720;

        public const float SpriteScaleFactor = 1.5f;
        public const float UnitPixelSize = 24;

        public const int level11Width = 2400;
        public const int level11Height = 720;

        public const int InvincibleTimer = 10;

        //Physics
        public const float JumpVelocity = 85f;
        public const float JumpVelocityDecayRate = 0.8f;
        public const float JumpVelocityMin = 1f;

        public const float FallVelocity = 2f;
        public const float FallVelocityIncreaseRate = 1.3f;
        public const float FallVelocityMax = 30f;

        public const int PhysicsDivisor = 50;

        /*Camera variables.*/
        public const int CameraDivisor = 2;
        public const int CameraWorldWidthMultiplier = 4;
        public const float CameraModifier = 0.5f;


        /*Block Collision Variables.*/
        public const int BlockOffsetTen = 10;
        public const int BlockOffsetForty = 40;

        //Block/Brick Bump time.
        public const int BumpTime = 10;
        public const int BumpTimeHalf = 5;
        public const float BumpShiftUp = 1f;
        public const float BumpShiftDown = -1f;

        //Coin Brick
        public const int CoinBrickCounter = 5;

        //Davis
        public const int LeftDistance = -3;
        public const int RightDistance = 3;

        public const float XMaxVelocity = 10f;
        public const float YMaxVeloctiy = 40f;

        public const float GRAVITY = 5f;
        public const float FRICTION = 5f;
        public const float DavisMass = 1f;
        public const float DavisJumpForce = 20f;
        public const int DavisDeathTimer = 150;
        // for collision detection
        public const int offsetRange = 2;

        //Enemies
        public const float EnemyVectorUpdateLeft = -1f;
        public const float EnemyVectorUpdateRight = 1f;
        public const int EnemyRemoveInt = 100;

        public const int GroundLevelKoopa = 600;
        public const int GroundLeveGoomba = 610;

        //Items
        public const int CoinTimer = 20;
        public const float CoinOffsetUp = 3f;
        public const float CoinOffsetDown = -3f;

        public const int KeyTimer = 20;
        public const float KeyOffsetUp = 3f;
        public const float KeyOffsetDown = -3f;

        public const int FlowerTimer = 40;
        public const float FlowerOffsetDown = -0.35f;

        public const int MushroomTimer = 40;
        public const float MushroomOffsetDown = -0.35f;

        public const int StarTimer = 35;
        public const float StarOffsetDown = -0.35f;

        //Projectiles
        public const float BatProjLeftMovement = -8f;
        public const float BatProjRightMovement = 8f;

        //Remove State Variables
        public const int RemovalTimerCeiling = 70;
        public const float RemovalOffsetDown = -0.5f;
        public const int RemovalOffsetUp = 3;

        //World Creator String Dict Accesors
        public const string Character = "Character";
        public const string Item = "Item";
        public const string Block = "Block";
        public const string Enemy = "Enemy";
        public const string Scenery = "Scenery";

        //HUD varables
        public static int score = 0;
        public static int coins = 0;
        public static int lives = 3;
        public static string worldText = "1-1";
        public static double time = 400;

        //Variables.Variable.

        //SpecialAttackTimer
        public static int DavisSpecialAttackTimer = 25;
        public static int WoodySpecialAttackTimer = 25;
        public static int BatSpecialAttackTimer = 16;
        //ShootBulletTimer

        public static int DavisShootBulletTimer = 25;
        public static int WoodyShootBulletTimer = 33;
        public static int BatShootBulletTimer = 20;
    }
}
