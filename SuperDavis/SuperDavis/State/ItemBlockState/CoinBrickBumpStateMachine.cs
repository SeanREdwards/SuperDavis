namespace SuperDavis.State.ItemStateMachine
{
    /*class CoinBrickBumpStateMachine : IGameObjectState
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public ISprite Sprite { get; set; }
        private int bumpTimer = Variables.Variable.BumpTime;
        private readonly CoinBrick brick;
        public CoinBrickBumpStateMachine(bool isBroken, CoinBrick brick)
        {
            if (!isBroken)
            {
                Sprite = ItemSpriteFactory.Instance.CreateBrickBlock();
            }
            else
            {
                Sprite = ItemSpriteFactory.Instance.CreateEmptyBlock();
            }
            this.brick = brick;
            Width = Sprite.Width;
            Height = Sprite.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (bumpTimer > Variables.Variable.BumpTimeHalf)
                brick.Location += new Vector2(0, Variables.Variable.BumpShiftDown);
            else if (bumpTimer > 0)
                brick.Location += new Vector2(0, Variables.Variable.BumpShiftUp);
            else
            {
                bumpTimer = Variables.Variable.BumpTime;
                brick.BrickStateMachine = new BrickStateMachine(false);
            }
            bumpTimer--;
        }
    }*/
}
