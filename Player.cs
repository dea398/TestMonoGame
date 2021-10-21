using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceWar
{
    /// <summary>
    /// The player, controlled by the keyboard
    /// </summary>
    class Player : Sprite
    {
        /// <summary>
        /// A reference to the game that will contain the player
        /// </summary>
        Game1 root;

        /// <summary>
        /// Represents the number of pixels to move the player in the Y axis
        /// </summary>
        Point velocity;

        List<Projectile> projectiles;

        /// <summary>
        /// To save the previous state of the keyboard to avoid undesired keyboard behavior
        /// </summary>
        KeyboardState previousKeyboardState;

        /// <summary>
        /// Initialize a player
        /// </summary>
        /// <param name="_root">This is the class that manipulates the game loop</param>
        /// <param name="_position">The initial position of the player</param>
        public Player(Game1 _root, Point _position) : base(_position, 150)
        {
            // Initialize values
            this.root = _root;
            velocity = new Point(0, 10);
            imageName = "Spaceship";
            this.LoadContent();
            projectiles = new List<Projectile>();
            previousKeyboardState = Keyboard.GetState();
        }

        /// <summary>
        /// Method to load external content
        /// </summary>
        private void LoadContent()
        {
            spriteImageInMemory = this.root.Content.Load<Texture2D>(imageName);
        }

        /// <summary>
        /// This method will help us to detect what key or keys have been pressed and act accordingly
        /// </summary>
        /// <param name="currentKeyboardState">The current state of the keyboard</param>
        private void HandleInput(KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                if (position.Y > 0)
                {
                    position = position - velocity;
                }
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                if (position.Y < (root.Window.ClientBounds.Height - Size))
                {
                    position = position + velocity;
                }
            }

            if (currentKeyboardState.IsKeyDown(Keys.Space) && !previousKeyboardState.IsKeyDown(Keys.Space))
            {
                projectiles.Add(new Projectile(this.root, this.position));
            }

            //assign the currentState to the previous one so in the next frame call we can detect if there is a new key pressed
            previousKeyboardState = currentKeyboardState;
        }

        public void Update(GameTime gameTime)
        {
            // Handle any movement input
            HandleInput(Keyboard.GetState());

            foreach (var item in projectiles)
            {
                item.Update();
            }
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            base.Draw(gameTime,spriteBatch, _color);
            foreach (var item in projectiles)
            {
                item.Draw(gameTime, spriteBatch, Color.White);
            }
        }

        //Testing code about how to rotate a sprite around its center point as origin
        //public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        //{
           
        //    spriteBatch.Draw(spriteImageInMemory, PositionRectangle,
        //        null,
        //        _color,
        //        45f,
        //        origin: new Vector2(spriteImageInMemory.Width / 2, spriteImageInMemory.Height / 2),
        //        SpriteEffects.None, 0f);
        //}
    }
}
