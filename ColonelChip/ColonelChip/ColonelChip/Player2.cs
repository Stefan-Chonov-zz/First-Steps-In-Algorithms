using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ColonelChip
{
    class Player2
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle boundingBox;
        private Color[] textureData;

        private float jumpingHeight;
        private float velocity;        

        //private bool isTurnedRight;
        //private bool isJumping;
        //private bool isShooting;

        public Player2(Texture2D texture, Vector2 position)
        {
            InitializePlayer(texture, position);
        }

        private void InitializePlayer(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.boundingBox = new Rectangle(
                (int)this.position.X,
                (int)this.position.Y,
                this.texture.Width,
                this.texture.Height);

            this.textureData = new Color[this.texture.Width * this.texture.Height];
            this.texture.GetData(this.textureData);

            this.jumpingHeight = 0;
            this.velocity = 0;

            //this.isTurnedRight = true;
            //this.isJumping = false;
            //this.isShooting = false;
        }

        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
        }

        public Color[] TextureData
        {
            get
            {
                return this.textureData;
            }
        }

        //public float JumpingHeight
        //{
        //    get
        //    {
        //        return this.jumpingHeight;
        //    }
        //    set
        //    {
        //        this.jumpingHeight = value;
        //    }
        //}

        public float Velocity
        {
            get
            {
                return this.velocity;
            }
            set
            {
                this.velocity = value;
            }
        }

        //private void PlayerControls(GameTime gameTime)
        //{
        //    KeyboardState keyboardState = Keyboard.GetState();

        //    // Move left
        //    if (keyboardState.IsKeyDown(Keys.A))
        //    {
        //        MoveBakgroundRight(gameTime);

        //        if (!this.isShooting)
        //        {
        //            this.isTurnedRight = false;
        //        }
        //    }
        //    else if ((keyboardState.IsKeyDown(Keys.D)) && (!this.hasRightCollision))
        //    {
        //        if (this.position.X >= this.windowWidth / 2)
        //        {
        //            MoveBakgroundLeft(gameTime);
        //        }
        //        else
        //        {
        //            this.position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * this.velocity;
        //        }

        //        if (!this.isShooting)
        //        {
        //            this.isTurnedRight = true;
        //        }
        //    }
        //}

        //public void PlayerJumping(GameTime gameTime)
        //{
        //    KeyboardState keyboardState = Keyboard.GetState();

        //    if (this.isJumping)
        //    {
        //        this.position.Y += this.jumpingHeight;
        //        this.jumpingHeight++;
        //    }
        //    else
        //    {
        //        if (keyboardState.IsKeyDown(Keys.Space))
        //        {
        //            this.jumpingHeight = -21f;
        //            this.isJumping = true;
        //        }
        //    }
        //}
    }
}
