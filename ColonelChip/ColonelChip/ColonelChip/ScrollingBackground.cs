using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColonelChip
{
    class ScrollingBackground
    {
        private Vector2 screenPosition;
        private Vector2 origin;
        private Vector2 textureSize;
        private Texture2D texture;
        private int screenHeight;

        public void Load(GraphicsDevice device, Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.screenHeight = device.Viewport.Height;
            int screenWidth = device.Viewport.Width;
            this.origin = new Vector2(texture.Width / 2, 0);
            this.screenPosition = new Vector2(screenWidth / 2, screenHeight / 2);
            this.textureSize = new Vector2(0, texture.Height);
        }

        public void Update(float deltaY)
        {
            this.screenPosition.Y += deltaY;
            this.screenPosition.Y %= this.texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (screenPosition.Y < screenHeight)
            {
                spriteBatch.Draw(
                    this.texture,
                    this.screenPosition,
                    null, Color.White, 
                    0, this.origin, 1, SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(
                this.texture,
                this.screenPosition - this.textureSize,
                null,
                Color.White,
                0, this.origin, 1,
                SpriteEffects.None, 0f);
        }
    }
}
