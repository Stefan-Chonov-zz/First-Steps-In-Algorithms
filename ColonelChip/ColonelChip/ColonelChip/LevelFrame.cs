using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ColonelChip
{
    class LevelFrame
    {
        // Background
        private Texture2D backgroundTexture;
        private Vector2 backgroundPosition;

        // Level objects
        private List<GameObject> levelObjects;

        public LevelFrame() { }

        public LevelFrame(Texture2D backgroundTexture, Vector2 backgroundPosition)
        {
            this.levelObjects = new List<GameObject>();

            this.backgroundTexture = backgroundTexture;
            this.backgroundPosition = backgroundPosition;
        }

        public void AddObject(Texture2D objectTexture, Vector2 objectPosition)
        {
            GameObject levelObject = new GameObject(objectTexture, objectPosition);
            this.levelObjects.Add(levelObject);
        }

        public void RemoveObjectAt(int index)
        {
            this.levelObjects.RemoveAt(index);
        }

        public void ChangeObjectPosition(int index, Vector2 newPosition)
        {
            this.levelObjects[index].Position = newPosition;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background
            spriteBatch.Draw(this.backgroundTexture, this.backgroundPosition, Color.White);

            // Draw the floors
            foreach (GameObject levelObject in this.levelObjects)
            {
                levelObject.Draw(spriteBatch);
            }
        }

        public Vector2 BackgroundPosition
        {
            get
            {
                return this.backgroundPosition;
            }
            set
            {
                this.backgroundPosition = value;
            }
        }

        public int CountObjects
        {
            get
            {
                return this.levelObjects.Count;
            }
        }
    }
}
