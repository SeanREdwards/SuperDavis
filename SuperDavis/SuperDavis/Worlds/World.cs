﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Collision;
using SuperDavis.Interfaces;
using System.Collections.Generic;

namespace SuperDavis.Worlds
{
    class World : IWorld
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public IList<IDavis> Characters { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IBlock> Blocks { get; set; }
        public IList<IEnemy> Enemies { get; set; }
        public IList<IProjectile> Projectiles { get; set; }
        public IList<IBackground> Backgrounds { get; set; }

        public IList<IGameObject> ObjectToRemove { get; set; }
        private readonly Game1 game;

        public World(float width, float height, Game1 game)
        {
            Width = width;
            Height = height;
            this.game = game;
            Characters = new List<IDavis>();
            Items = new List<IItem>();
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemy>();
            Projectiles = new List<IProjectile>();
            Backgrounds = new List<IBackground>();
            ObjectToRemove = new List<IGameObject>();
        }
        
        public void Update(GameTime gameTime)
        {

            foreach (IBackground background in Backgrounds)
            {
                background.Update(gameTime);
            }
            foreach (IDavis character in Characters)
            {
                character.Update(gameTime);
                character.HitBox = new Rectangle((int)character.Location.X, (int)character.Location.Y, (int)character.Sprite.Width, (int)character.Sprite.Height);
            }
            foreach (IItem item in Items)
            {
                item.Update(gameTime);
            }
            foreach (IBlock block in Blocks)
            {
                block.Update(gameTime);
            }
            foreach (IProjectile projectile in Projectiles)
            {
                projectile.Update(gameTime);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
            if (ObjectToRemove.Count != 0)
                RemoveObject();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBackground background in Backgrounds)
            {
                background.Draw(spriteBatch);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IProjectile projectile in Projectiles)
            {
                projectile.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IDavis character in Characters)
            {
                character.Draw(spriteBatch);
            }

        }

        public void RemoveObject()
        {
            foreach(IGameObject removeObject in ObjectToRemove)
            {
                if(removeObject is IDavis)
                {
                    Characters.Remove((IDavis)removeObject);
                }
                else if (removeObject is IItem)
                {
                    Items.Remove((IItem)removeObject);
                }
                else if (removeObject is IBlock)
                {
                    Blocks.Remove((IBlock)removeObject);
                }
                else if (removeObject is IEnemy)
                {
                    Enemies.Remove((IEnemy)removeObject);
                }
                else if (removeObject is IProjectile)
                {
                    Projectiles.Remove((IProjectile)removeObject);
                }
            }
            ObjectToRemove.Clear();
        }

        public void ResetGame()
        {
            Characters.Clear();
            Blocks.Clear();
            Enemies.Clear();
            Items.Clear();
            Projectiles.Clear();
            Backgrounds.Clear();
            ObjectToRemove.Clear();
            WorldCreator worldCreator = new WorldCreator();
            game.World = worldCreator.CreateWorld("level1-1.xml", Variables.Variable.WindowsEdgeWidth, Variables.Variable.WindowsEdgeHeight, game);
            game.collisionDetection = new CollisionDetection(game.World);
            game.InitializeController();
        }
    }
}
