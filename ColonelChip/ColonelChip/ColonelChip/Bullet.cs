using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace ColonelChip
{
    class Bullet
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle boundingBox;
        private Color[] textureData;

        private float bulletVelocity;
        private float bulletDamage;

        public Bullet(Texture2D bulletTexture, Vector2 bulletPosition)
        {       
            this.texture = bulletTexture;            
            this.position = bulletPosition;
            this.boundingBox = new Rectangle(
                (int)this.position.X,
                (int)this.position.Y,
                this.texture.Width,
                this.texture.Height);

            this.textureData = new Color[this.texture.Width * this.texture.Height];
            this.texture.GetData(this.textureData);
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

                // Actualization of rectangle of the bullet
                this.boundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
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

                // Actualization of rectangle of the bullet
                this.boundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.texture.Width,
                    this.texture.Height);
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

                // Actualization of rectangle of the bullet
                this.boundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.texture.Width,
                    this.texture.Height);
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
        }

        public float Velocity
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

        public float Damage
        {
            get
            {
                return this.bulletDamage;
            }
            set
            {
                this.bulletDamage = value;
            }
        }

        public Color[] TextureData
        {
            get
            {
                return this.textureData;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.boundingBox, Color.White);
        }
    }
}
