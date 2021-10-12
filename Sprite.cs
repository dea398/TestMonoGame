using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceWar
{
    /// <summary>
    /// Sprite base class, contains basic sprite functionality
    /// </summary>
    class Sprite
    {
        /// <summary>
        /// The current position of the sprite
        /// </summary>
        protected Point position;

        /// <summary>
        /// The name of the sprite image
        /// </summary>
        protected string imageName;

        /// <summary>
        /// An image texture for the sprite
        /// </summary>
        protected Texture2D spriteImageInMemory;

        /// <summary>
        /// This is a variable that indicates the scale size of the sprite.
        /// e.g. a Size of 30 will tell us that 
        /// the height and the width of the sprite is 30
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The properly scaled position rectangle for the sprite
        /// </summary>
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle(position, new Point(Size));
                //return new Rectangle(position.X,position.Y,Size, Size);
            }
        }

        /// <summary>
        /// Initialize a sprite
        /// </summary>
        /// <param name="_position">The initial position of the player.</param>
        /// <param name="_size">This is a variable that indicates the scale size of the sprite.</param>
        public Sprite(Point _position, int _size)
        {
            this.position = _position;
            Size = _size;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            spriteBatch.Draw(spriteImageInMemory, PositionRectangle, _color);
        }
    }
}
