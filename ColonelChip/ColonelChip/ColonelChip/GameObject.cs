using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ColonelChip
{
    class GameObject
    {
        private Texture2D texture;
        private Rectangle textureRectangle;
        private Vector2 position;
        private Vector2 velocity;
        private Color[] textureData;

        public GameObject() { }

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.BoundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.texture.Width,
                    this.texture.Height);

            this.textureData = new Color[texture.Width * texture.Height];
            this.texture.GetData(this.textureData);
        }

        public GameObject(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;

            this.BoundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.texture.Width,
                    this.texture.Height);

            this.textureData = new Color[texture.Width * texture.Height];
            this.texture.GetData(this.textureData);
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
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

                BoundingBox = new Rectangle(
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

                BoundingBox = new Rectangle(
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

                BoundingBox = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.texture.Width,
                    this.texture.Height);
            }
        }

        public Vector2 Velocity
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

        public Rectangle BoundingBox
        {
            get
            {
                return this.textureRectangle;
            }
            private set
            {
                this.textureRectangle = new Rectangle(
                    (int)this.position.X,
                    (int)this.position.Y,
                    this.texture.Width,
                    this.texture.Height);
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
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }
    }
}
