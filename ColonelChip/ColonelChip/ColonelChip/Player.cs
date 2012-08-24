using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ColonelChip
{
    class Player : IPlayer
    {
        private KeyboardState keyboardState;
        private MouseState mouseState;

        private Texture2D texture;
        private Vector2 position;
        private Rectangle boundingBox;
        private Color[] textureData;

        //private Texture2D bulletTexture;
        //private Vector2 bulletPosition;
        //private Bullet bullet;

        //private float jumpingVelocity;
        //private float jumpingVelocityTemporary;
        //private float bulletVelocity;
        //private float oldBulletVelocity;

        private float velocity;
        private float health;

        private bool isMoveLeft;
        private bool isMovingRight;
        private bool isTurnedLeft;
        private bool isTurnedRight;
        //private bool isJumping;
        //private bool isShootingLeft;
        //private bool isShootingRight;
        private bool isAlive;

        public Player(Texture2D texture, Vector2 position)
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

            this.isTurnedRight = true;
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                this.boundingBox = new Rectangle(
                    (int)value.X,
                    (int)value.Y,
                    this.texture.Width,
                    this.texture.Height);
            }
        }

        public float XPosition
        {
            get
            {
                return this.position.X;
            }
            set
            {
                this.position.X = value;
                this.boundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.Width,
                    this.Height);
            }
        }

        public float YPosition
        {
            get
            {
                return this.position.Y;
            }
            set
            {
                this.position.Y = value;
                this.boundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.Width,
                    this.Height);
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
            set
            {
                this.boundingBox = value;
            }
        }

        public Texture2D ChangeTexture
        {
            set
            {
                this.texture = value;
            }
        }

        public Color[] TextureData
        {
            get
            {
                return this.textureData;
            }
            set
            {
                this.textureData = value;
            }
        }

        public int Width
        {
            get
            {
                return this.texture.Width;
            }
        }

        public int Height
        {
            get 
            { 
                return this.texture.Height; 
            }
        }

        //public float JumpingVelocity
        //{
        //    get
        //    {
        //        return this.jumpingVelocity;
        //    }
        //    set
        //    {
        //        this.jumpingVelocity = value;
        //    }
        //}

        //public Texture2D BulletTexture
        //{
        //    get
        //    {
        //        return this.bulletTexture;
        //    }
        //    set
        //    {
        //        this.bulletTexture = value;
        //    }
        //}

        //public Vector2 BulletPosition
        //{
        //    get
        //    {
        //        return this.bulletPosition;
        //    }
        //    set
        //    {
        //        this.bulletPosition = value;
        //    }
        //}

        //public float BulletVelocity
        //{
        //    get
        //    {
        //        return this.bulletVelocity;
        //    }
        //    set
        //    {
        //        this.bulletVelocity = value;
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

        public float Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public bool IsMovingLeft
        {
            get
            {
                return this.isMoveLeft;
            }
            set
            {
                this.isMoveLeft = value;
            }
        }

        public bool IsMovingRight
        {
            get
            {
                return this.isMovingRight;
            }
            set
            {
                this.isMovingRight = value;
            }
        }

        public bool IsTurnedLeft
        {
            get
            {
                return this.isTurnedLeft;
            }
        }

        public bool IsTurnedRight
        {
            get
            {
                return this.isTurnedRight;
            }
        }

        //public bool IsJumping
        //{
        //    get
        //    {
        //        return this.isJumping;
        //    }
        //    set
        //    {
        //        this.isJumping = value;
        //    }
        //}

        //public bool IsShootingLeft
        //{
        //    get
        //    {
        //        return this.isShootingLeft;
        //    }
        //    set
        //    {
        //        this.isShootingLeft = value;
        //    }
        //}

        //public bool IsShootingRight
        //{
        //    get
        //    {
        //        return this.isShootingRight;
        //    }
        //    set
        //    {
        //        this.isShootingRight = value;
        //    }
        //}

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            set
            {
                this.isAlive = value;
            }
        }

        public virtual void MoveLeft(GameTime gameTime, Keys key)
        {
            if (this.keyboardState.IsKeyDown(key))
            {
                this.position.X -= this.velocity * (int)gameTime.ElapsedGameTime.TotalSeconds;
                this.isMoveLeft = true;

                this.isTurnedLeft = true;
                this.isTurnedRight = false;                
            }
            else
            {
                this.isMoveLeft = false;
            }
        }

        public virtual void MoveRight(GameTime gameTime, Keys key)
        {
            if (this.keyboardState.IsKeyDown(key))
            {
                this.position.X += this.velocity * (int)gameTime.ElapsedGameTime.TotalSeconds;
                this.isMovingRight = true;

                this.isTurnedLeft = false;
                this.isTurnedRight = true;
            }
            else
            {
                this.isMovingRight = false;
            }
        }

        //public virtual void Jumping(Keys key)
        //{
        //    if (this.isJumping)
        //    {
        //        this.YPosition += this.jumpingVelocityTemporary;
        //        this.jumpingVelocityTemporary++;
        //    }
        //    else
        //    {
        //        if (this.keyboardState.IsKeyDown(key))
        //        {
        //            this.jumpingVelocityTemporary = this.jumpingVelocity;
        //            this.isJumping = true;
        //        }
        //    }
        //}

        //public void ShootingLeft(GameTime gameTime, float distance)
        //{
        //    if (this.isShootingLeft)
        //    {
        //        this.bullet.XPosition -= this.oldBulletVelocity;
        //        this.oldBulletVelocity++;

        //        if (this.bullet.XPosition < distance)
        //        {
        //            this.isShootingLeft = false;
        //        }
        //    }
        //    else
        //    {
        //        if (this.mouseState.LeftButton == ButtonState.Pressed)
        //        {
        //            this.bullet = new Bullet(this.bulletTexture, this.bulletPosition);
        //            this.oldBulletVelocity = this.bulletVelocity;
        //            this.isShootingLeft = true;
        //        }
        //    }
        //}

        //public void ShootingRight(GameTime gameTime, float distance)
        //{
        //    if (this.isShootingRight)
        //    {
        //        this.bullet.XPosition += this.oldBulletVelocity;
        //        this.oldBulletVelocity++;

        //        if (this.bullet.XPosition > distance)
        //        {
        //            this.isShootingRight = false;
        //        }
        //    }
        //    else
        //    {
        //        if (this.mouseState.LeftButton == ButtonState.Pressed)
        //        {
        //            this.bullet = new Bullet(this.bulletTexture, this.bulletPosition);                    
        //            this.oldBulletVelocity = this.bulletVelocity;
        //            this.isShootingRight = true;
        //        }
        //    }
        //}

        public void Update()
        {
            this.keyboardState = Keyboard.GetState();
            this.mouseState = Mouse.GetState();

            this.BoundingBox = new Rectangle(
                (int)this.position.X,
                (int)this.position.Y,
                this.texture.Width,
                this.texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.boundingBox, Color.White);
        }
    }
}
