namespace SuperDavis.Variables
{
    public static class Variable
    {
        public const int Zero = 0;


        //Game1.cs string variables.
        public const string ContentDirectory = "Content";
        public const string LevelOne = "level1-1.xml";

        //Game1.cs reset distances.
        public const int FloorReset = -100;
        public const int CeilingReset = 768;
        public const int RightReset = 4900;

        public const int WindowsEdgeWidth = 1024;
        public const int WindowsEdgeHeight = 668;
        public const int UnitPixelSize = 24;
        public const int level11Width = 4800;
        public const int level11Height = 668;

        public const int InvincibleTimer = 300;
        public const float SpriteScaleFactor = 1.5f;

        // temp for physics param
        public const float JumpVelocity = 75f;
        public const float JumpVelocityDecayRate = 0.8f;
        public const float JumpVelocityMin = 1f;

        public const float FallVelocity = 2f;
        public const float FallVelocityIncreaseRate = 1.4f;
        public const float FallVelocityMax = 30f;

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


    }
}
