using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ColonelChip
{
    class InitializeFirstLevel
    {
        private const byte NUMBER_OF_FRAMES = 20;

        ContentManager gameContent;
        private int windowWidth;
        private int windowHeight;
        private int xPosition;

        //private List<Texture2D> backgroundTextures;
        //private List<Vector2> backgroundPositions;
        private List<GameObject> backgroundObjects;
        private List<List<GameObject>> parentLevelObjects;

        public InitializeFirstLevel(ContentManager content, GraphicsDeviceManager graphics)
        {
            this.gameContent = content;
            this.windowWidth = graphics.GraphicsDevice.Viewport.Width;
            this.windowHeight = graphics.GraphicsDevice.Viewport.Height;
            this.xPosition = 0;
            this.backgroundObjects = new List<GameObject>();
            this.parentLevelObjects = new List<List<GameObject>>();

            // Load frames of level
            FirstFrameLevelObject(this.windowHeight);
            SecondFrameLevelObject(this.windowHeight);
            ThirdFrameLevelObjects(this.windowHeight);

            if (this.parentLevelObjects.Count < NUMBER_OF_FRAMES)
            {
                for (int i = this.parentLevelObjects.Count; i < NUMBER_OF_FRAMES; i++)
                {
                    List<GameObject> childLevelObjects = new List<GameObject>();
                    this.parentLevelObjects.Add(childLevelObjects);
                }                
            }            
        }

        private void FirstFrameLevelObject(int windowHeight)
        {
            List<GameObject> childLevelObjects = new List<GameObject>();

            Texture2D backgroundTexture = this.gameContent.Load<Texture2D>("Backgrounds/Background");
            Vector2 backgroundPosition = new Vector2(xPosition, windowHeight - backgroundTexture.Height);
            GameObject backgroundObject = new GameObject(backgroundTexture, backgroundPosition);
            this.backgroundObjects.Add(backgroundObject);

            Texture2D floorTexture = this.gameContent.Load<Texture2D>("Backgrounds/Floor");
            Vector2 floorPosition = new Vector2(xPosition, windowHeight - floorTexture.Height);
            GameObject floorObject = new GameObject(floorTexture, floorPosition);
            childLevelObjects.Add(floorObject);

            Texture2D stepperTexture = this.gameContent.Load<Texture2D>("Others/Stepper");
            Vector2 stepperPosition = new Vector2(xPosition + 300.0f, windowHeight - floorTexture.Height - 200);
            GameObject stepperObject = new GameObject(stepperTexture, stepperPosition);
            childLevelObjects.Add(stepperObject);

            this.parentLevelObjects.Add(childLevelObjects);

            xPosition += backgroundTexture.Width;
        }

        private void SecondFrameLevelObject(int windowHeight)
        {
            List<GameObject> childLevelObjects = new List<GameObject>();

            Texture2D backgroundTexture = this.gameContent.Load<Texture2D>("Backgrounds/Background");
            Vector2 backgroundPosition = new Vector2(xPosition, windowHeight - backgroundTexture.Height);
            GameObject backgroundObject = new GameObject(backgroundTexture, backgroundPosition);
            backgroundObjects.Add(backgroundObject);

            Texture2D floorTexture = this.gameContent.Load<Texture2D>("Backgrounds/Floor");
            Vector2 floorPosition = new Vector2(xPosition, windowHeight - floorTexture.Height);
            GameObject floorObject = new GameObject(floorTexture, floorPosition);
            childLevelObjects.Add(floorObject);

            Texture2D stepperTexture = this.gameContent.Load<Texture2D>("Others/Stepper");
            Vector2 stepperPosition = new Vector2(xPosition + 350.0f, windowHeight - floorTexture.Height - 200);
            GameObject stepperObject = new GameObject(stepperTexture, stepperPosition);
            childLevelObjects.Add(stepperObject);

            stepperTexture = this.gameContent.Load<Texture2D>("Others/Stepper");
            stepperPosition = new Vector2(xPosition + 500.0f, windowHeight - floorTexture.Height - 400);
            stepperObject = new GameObject(stepperTexture, stepperPosition);
            childLevelObjects.Add(stepperObject);

            this.parentLevelObjects.Add(childLevelObjects);

            xPosition += backgroundTexture.Width;
        }

        private void ThirdFrameLevelObjects(int windowHeight)
        {
            List<GameObject> childLevelObjects = new List<GameObject>();

            Texture2D backgroundTexture = this.gameContent.Load<Texture2D>("Backgrounds/Background");
            Vector2 backgroundPosition = new Vector2(xPosition, windowHeight - backgroundTexture.Height);
            GameObject backgroundObject = new GameObject(backgroundTexture, backgroundPosition);
            backgroundObjects.Add(backgroundObject);

            Texture2D floorTexture = this.gameContent.Load<Texture2D>("Backgrounds/Floor");
            Vector2 floorPosition = new Vector2(xPosition, windowHeight - floorTexture.Height);
            GameObject floorObject = new GameObject(floorTexture, floorPosition);
            childLevelObjects.Add(floorObject);

            this.parentLevelObjects.Add(childLevelObjects);

            xPosition += backgroundTexture.Width;
        }

        public List<List<GameObject>> ObjectsPerFrame
        {
            get
            {
                return this.parentLevelObjects;
            }
        }

        public List<GameObject> BackgroundObjects
        {
            get
            {
                return this.backgroundObjects;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject backgroundObject in this.backgroundObjects)
            {
                backgroundObject.Draw(spriteBatch);
            }

            foreach (List<GameObject> childLevelObjects in this.parentLevelObjects)
            {
                foreach (GameObject levelObject in childLevelObjects)
                {
                    levelObject.Draw(spriteBatch);
                }
            }
        }
    }
}
