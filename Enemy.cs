using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceWar
{
    /// <summary>
    /// A little evil thing that is looking to conquer planet Earth
    /// </summary>
    class Enemy : Sprite
    {
        /// <summary>
        /// A reference to the game that will contain the enemy
        /// </summary>
        Game1 root;

        /// <summary>
        /// Represents the number of pixels to move the enemy in the X axis
        /// </summary>
        Point velocity;

        /// <summary>
        /// Initialize an enemy
        /// Please be aware that this constructor is in invoking the base constructor with its respective parameters
        /// </summary>
        /// <param name="_root">This is the class that manipulates the game loop</param>
        /// <param name="_position">The initial position of the player</param>
        public Enemy(Game1 _root, Point _position) : base(_position, 150)
        {
            this.root = _root;
            this.velocity = new Point(5, 0);
            this.imageName = "Enemy";
            this.LoadContent();
        }

        /// <summary>
        /// Method to load external content
        /// </summary>
        private void LoadContent()
        {
            spriteImageInMemory = this.root.Content.Load<Texture2D>(imageName);
        }

        public void Update(GameTime gameTime)
        {
            if (this.position.X>0)
            {
                position = position - velocity;
            }
            else
            {
                position.X = this.root.Window.ClientBounds.Width - Size;
            }
        }

    }
}
