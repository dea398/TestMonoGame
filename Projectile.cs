using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceWar
{
    class Projectile : Sprite
    {
        /// <summary>
        /// Represents the number of pixels to move the projectile in the X axis
        /// </summary>
        Point velocity;

        /// <summary>
        /// A reference to the game that will contain the enemy
        /// </summary>
        Game1 root;

        public Projectile(Game1 _root, Point _position) : base(_position, 50)
        {
            velocity = new Point(5, 0);
            root = _root;
            this.imageName = "Fireball";
            this.LoadContent();   
        }

        /// <summary>
        /// Method to load external content
        /// </summary>
        private void LoadContent()
        {
            spriteImageInMemory = this.root.Content.Load<Texture2D>(imageName);
        }

        public void Update()
        {
            position += velocity;
        }

    }
}
