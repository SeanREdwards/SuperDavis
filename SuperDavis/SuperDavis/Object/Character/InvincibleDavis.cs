namespace SuperDavis.Object.Character
{
    // We haven't use this class, comment out for future use
    /*class InvincibleDavis : IDavis
    {
        IDavis decoratedDavis;
        int timer = 100;

        public bool Remove { get; set; }
        public IDavisState DavisState { get; set; }
        public Vector2 Location { get; set; }
        public DavisStatus DavisStatus { get; set; }
        public Rectangle HitBox { get; set; }
        public DavisStatus PrevDavisStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int InvincibleTimer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public InvincibleDavis(IDavis decoratedDavis)
        {
            // initial state
            DavisStatus = DavisStatus.Bat;
            this.decoratedDavis = decoratedDavis;
        }

        void TakeDamage()
        {
            // StarMario does not take damage
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar();
            }
            decoratedDavis.Update(gameTime);
        }

        void RemoveStar()
        {
            //Game1.Instance.davis = decoratedDavis;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DavisState.Draw(spriteBatch, Location);
        }

        // Davis State Change Helper Method
        public void DavisTurnLeft()
        {
            this.Location += new Vector2(-2, 0);
            this.DavisState.SpecialAttack();
        }

        public void DavisTurnRight()
        {
            this.Location += new Vector2(2, 0);
            this.DavisState.SpecialAttack();
        }

        public void DavisJump()
        {
            this.Location += new Vector2(0, -2);
        }

        public void DavisCrouch()
        {
            this.Location += new Vector2(0, 2);
        }

        public void DavisToDavis()
        {
            //Do nothing
        }

        public void DavisToWoody()
        {
            //Do nothing
        }

        public void DavisToBat()
        {
            //do nothing
        }

        public void DavisDeath()
        {
            //do nothing
        }

        public void DavisSpecialAttack()
        {
            //do nothing
        }
        public void DavisToInvincible()
        {
            //do nothing, already invincible.
        }

        public void Reset()
        { }
    }
*/
}