using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColonelChip
{
    class PlayerAbilities
    {
        private const float DEFAULT_BULLET_VELOCITY = 20.0f;
        private const float DEFAULT_BULLET_X_OFFSET = 54.0f;

        private Player player;
        private Bullet bullet;

        private bool isJumping;
        private bool isShooting;
        private bool isBulletDirectionRight;

        private float jumpingVelocity;
        private float jumpingVelocityTween;
        private float bulletVelocity;

        private float bulletOffset_X;
        private float bulletOffset_Y;

        KeyboardState keyboardState;
        MouseState mouseState;

        public PlayerAbilities(Player player)
        {
            this.player = player;
            this.bulletVelocity = DEFAULT_BULLET_VELOCITY;
            this.bulletOffset_Y = DEFAULT_BULLET_X_OFFSET;
        }

        public bool IsJumping
        {
            get
            {
                return this.isJumping;
            }
            set
            {
                this.isJumping = false;
            }
        }

        public bool IsShooting
        {
            get
            {
                return this.isShooting;
            }
        }

        public float JumpingVelocity
        {
            get
            {
                return this.jumpingVelocity;
            }
            set
            {
                this.jumpingVelocity = value;
            }
        }

        public float BulletVelocity
        {
            get
            {
                return this.bulletVelocity;
            }
            set
            {
                this.bulletVelocity = value;
            }
        }

        public float BulletOffset_X
        {
            get
            {
                return this.bulletOffset_X;
            }
            set
            {
                this.bulletOffset_X = value;
            }
        }

        public float BulletOffset_Y
        {
            get
            {
                return this.bulletOffset_Y;
            }
            set
            {
                this.bulletOffset_Y = value;
            }
        }

        public Vector2 BulletPosition
        {
            get
            {
                return this.bullet.Position;
            }
        }

        public virtual void Jumping(GameTime gameTime, Keys key)
        {
            if (this.isJumping)
            {
                this.player.YPosition += this.jumpingVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //this.jumpingVelocity++;

                if (this.jumpingVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds == 0)
                {
                    this.isJumping = false;
                }
            }
            else
            {
                if (this.keyboardState.IsKeyDown(key))
                {
                    this.isJumping = true;
                }
            }
        }

        public void Shooting(
            Bullet bullet, GameTime gameTime, bool isPlayerTurnedRight, 
            int leftBound, int rightBound)
        {
            this.mouseState = Mouse.GetState();            

            if (this.isShooting)
            {
                if (this.isBulletDirectionRight)
                {
                    bullet.XPosition += this.bulletVelocity;                    
                }
                else
                {
                    bullet.XPosition -= this.bulletVelocity;
                }
                
                if ((bullet.XPosition > rightBound) ||
                    (bullet.XPosition < leftBound))
                {                    
                    this.isShooting = false;
                }
            }
            else
            {
                if (this.mouseState.LeftButton == ButtonState.Pressed)
                {
                    this.isShooting = true;

                    if (isPlayerTurnedRight)
                    {
                        this.isBulletDirectionRight = true;
                    }
                    else
                    {
                        this.isBulletDirectionRight = false;
                    }
                }
            }

            this.bullet = bullet;
        }

        public void Update()
        {
            this.keyboardState = Keyboard.GetState();
            this.mouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if ((this.bullet != null) && (this.IsShooting))
            {
                this.bullet.Draw(spriteBatch);
            }
        }
    }
}
