﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.State.ItemStateMachine;
using System;

namespace SuperDavis.Object.Item
{
    class Coin : IItem
    {
        public bool IsAnimated { get; set; }
        public bool FacingLeft { get; set; }
        public Rectangle HitBox { get; set; }
        private readonly ISprite item;
        private readonly CoinStateMachine coinStateMachine;
        public IGameObjectPhysics PhysicsState { get; set; }
        private int timer = Variables.Variable.CoinTimer;

        public event EventHandler<Tuple<Vector2, Vector2>> OnPositionChanged;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                OnPositionChanged?.Invoke(this, Tuple.Create(location, value));
                location = value;
            }
        }

        public Coin(Vector2 location)
        {
            // initial state

            IsAnimated = false;
            Location = location;
            coinStateMachine = new CoinStateMachine();
            item = coinStateMachine.Sprite;
            HitBox = new Rectangle((int)Location.X, (int)Location.Y, (int)item.Width, (int)item.Height);
        }

        public void Update(GameTime gameTime)
        {

            coinStateMachine.Update(gameTime);
            if (!IsAnimated)
            {
                if (timer > 10)
                {
                    Location += new Vector2(0, Variables.Variable.CoinOffsetDown);
                    timer--;
                }
                else if (timer > 0)
                {
                    Location += new Vector2(0, Variables.Variable.CoinOffsetUp);
                    timer--;
                }
                else
                {
                    timer = Variables.Variable.CoinTimer;
                    IsAnimated = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            coinStateMachine.Draw(spriteBatch, Location);
        }
    }


}

