using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Timers;

namespace ColonelChip
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ColonelChip : Microsoft.Xna.Framework.Game
    {
        private const float JUMPING_VELOCITY = -15.0f;
        private const float BULLET_VELOCITY = 30.0f;
        private const float BACKGROUND_SLIDING_VELOCITY = 200.0f;
        private const float SLIDING_FLOOR_VELOCITY = 400.0f;
        private const byte MUZZLE_OF_GUN_POSITION = 54;

        private InitializeFirstLevel initializeFirstLevel;
        private UserControllersSettings controllersSettings;
        private Player player;
        private PlayerAbilities playerAbilities;

        private List<List<GameObject>> levelObjectsPerFrame;

        private GameObject floor;

        // Bullet
        private Bullet bullet;

        private bool isPlayerShooting;

        private bool hasLeftCollision = false;
        private bool hasTopCollision = false;
        private bool hasRightCollision = false;
        private bool hasBottomCollision = false;
        //private bool isPlayerOnGround = true;
        private bool oldHasBottomCollision = false;
        private bool isPlayerJumping = false;
        private bool isGravityOn = false;
        private bool isPlayerOnGround = true;

        private float jumpingVelocity = 0.0f;
        private float oldJumpingVelocity = 0.0f;
        private float timer = 0.0f;
        //private bool isPlayerMoveLeft;
        //private bool isPlayerMoveRight;

        //private int oldWalkingTime;
        //private AudioEngine audioEngine;
        //private SoundBank soundBank;
        //private WaveBank waveBank;
        //private AudioCategory audioCategory;
        //private Cue currentSound;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardState keyboardState;
        private MouseState mouseState;

        private int windowWidth;
        private int windowHeight;
        private int windowCenter;

        //private GameObject playerObject;
        private Collisions collisions;

        private const float GRAVITY = 1500.0f;

        //private float heightOfJumpingObject = 0.0f;

        //// Background texture
        //private Texture2D backgroundTexture;
        //private Vector2 backgroundPosition;
        //private GameObject backgroundObject;

        //private Texture2D backgroundTexture2;
        //private Vector2 backgroundPosition2;
        //private GameObject backgroundObject2;

        //private Texture2D backgroundTexture3;
        //private Vector2 backgroundPosition3;
        //private GameObject backgroundObject3;
        //// End background 

        //// Add floor to background
        //private Texture2D floorTexture;
        //private Vector2 floorPosition;
        //private GameObject floorObject;
        //private Color[] floorTextureData;
        //// End

        //// Floor 2
        //private Texture2D floorTexture2;
        //private Vector2 floorPosition2;
        //private GameObject floorObject2;
        //private Color[] floorTextureData2;
        //// End

        //// Floor 3
        //private Texture2D floorTexture3;
        //private Vector2 floorPosition3;
        //private GameObject floorObject3;
        //private Color[] floorTextureData3;
        //// End

        //// Player 
        //private Texture2D playerTexture;
        //private Vector2 playerPosition;
        //private float playerVelocity;

        //private bool isPlayerTurnedRight = true;
        //private bool isPlayerHit = false;
        //private bool isPlayerJump = false;

        //private float playerJumpingHeight = 0.0f;
        //private Color[] playerTextureData;
        //// End player

        //// Bullet
        //private Texture2D bulletTexture;
        //private Vector2 bulletPosition;

        //private const float BULLET_VELOCITY = 20.0f;
        //private float bulletVelocity;

        //private GameObject bulletObject;

        //private bool isShooting = false;
        //private SoundEffect shootingSound;
        //private Color[] bulletTextureData;
        //// End bullet

        //// Bug bullet
        //private Texture2D bugBulletTexture;
        //private Vector2 bugBulletPosition;
        //private Color[] bugBulletTextureData;
        //private float bugBulletVelocity = 0.0f;
        //private GameObject bugBulletObject;

        //private bool isBugShooting = false;

        //private const float BUG_BULLET_VELOCITY = 9;
        //private SoundEffect bugShootingSound;
        //// End bug bullet

        //// Enemy
        //private Texture2D enemyTexture;
        //private Vector2 enemyPosition;
        //private GameObject enemyObject;

        //private SoundEffect enemyDyingSound;

        //private bool isEnemyDead = false;
        //private bool isEnemyJump = false;

        //private Color[] enemyTextureData;
        //// End enemy

        //// Stepper
        //private Texture2D stepperTexture;
        //private Vector2 stepperPosition;
        //private GameObject stepperObject;

        //private Color[] stepperTextureData;
        // End stepper

        public ColonelChip()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";

            this.collisions = new Collisions();
            //this.graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            InitializeUserControllers();

            //this.playerVelocity = 250.0f;
            //this.bulletVelocity = 20;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.windowWidth = this.graphics.GraphicsDevice.Viewport.Width;
            this.windowHeight = this.graphics.GraphicsDevice.Viewport.Height;
            this.windowCenter = this.windowWidth / 2;

            // Load first level
            this.initializeFirstLevel = new InitializeFirstLevel(this.Content, this.graphics);

            this.levelObjectsPerFrame = this.initializeFirstLevel.ObjectsPerFrame;

            List<GameObject> firstFrameObjects = this.levelObjectsPerFrame[0];
            this.floor = firstFrameObjects[0];

            // Load player
            Texture2D playerTexture = Content.Load<Texture2D>("Player/PlayerTurnedRight");
            Vector2 playerPosition = new Vector2(
                this.windowCenter - (playerTexture.Width / 2),
                (this.floor.BoundingBox.Top - playerTexture.Height) + 1);
            this.player = new Player(playerTexture, playerPosition);

            this.playerAbilities = new PlayerAbilities(this.player);
            this.playerAbilities.JumpingVelocity = JUMPING_VELOCITY;
            this.playerAbilities.BulletVelocity = BULLET_VELOCITY;

            // Jumping
            this.jumpingVelocity = JUMPING_VELOCITY;
            //// Bullet
            //Texture2D bulletTexture = Content.Load<Texture2D>("Bullets/bullet_right");
            //Vector2 bulletPosition = new Vector2(
            //    this.player.XPosition + this.player.Width, 
            //    this.player.YPosition + MUZZLE_OF_GUN_POSITION);
            //this.bullet = new Bullet(bulletTexture, bulletPosition);

            //// Shooting sound
            //this.shootingSound = Content.Load<SoundEffect>("Sounds/ShootingSilencer");
            ////this.bugShootingSound = Content.Load<SoundEffect>("Sounds/shootingBugSound");

            //// Enemy
            //this.enemyTexture = Content.Load<Texture2D>("Enemys/enemyTurnedLeft");
            //this.enemyPosition = new Vector2(this.windowWidth - this.enemyTexture.Width - 100, this.windowHeight - this.enemyTexture.Height - this.floorTexture.Height);
            //this.enemyObject = new GameObject(this.enemyTexture, this.enemyPosition);
            //this.enemyTextureData = new Color[this.enemyTexture.Width * this.enemyTexture.Height];
            //this.enemyTexture.GetData(this.enemyTextureData);

            //// Enemy dying sound
            //this.enemyDyingSound = Content.Load<SoundEffect>("Sounds/EnemyDyingSound");

            //// Bug bullet
            //this.bugBulletTexture = Content.Load<Texture2D>("Bullets/bugBullet");
            //this.bugBulletPosition = new Vector2(this.enemyObject.XPosition, this.enemyObject.YPosition + (this.enemyTexture.Height / 2));
            //this.bugBulletObject = new GameObject(this.bugBulletTexture, this.bugBulletPosition);
            //this.bugBulletTextureData = new Color[this.bugBulletTexture.Width * this.bugBulletTexture.Height];
            //this.bugBulletTexture.GetData(this.bugBulletTextureData);

            //// Stepper
            //this.stepperTexture = Content.Load<Texture2D>("Others/Stepper");
            //this.stepperPosition = new Vector2(300.0f, this.windowHeight - this.floorTexture.Height - 200);
            //this.stepperObject = new GameObject(this.stepperTexture, this.stepperPosition);
            //this.stepperTextureData = new Color[this.stepperTexture.Width * this.stepperTexture.Height];
            //this.stepperTexture.GetData(this.stepperTextureData);
        }

        private void InitializeUserControllers()
        {
            this.controllersSettings = new UserControllersSettings();

            this.controllersSettings.MoveLeftKey = Keys.A;
            this.controllersSettings.MoveRightKey = Keys.D;
            this.controllersSettings.JumpKey = Keys.Space;
            this.controllersSettings.PauseKey = Keys.Pause;
            this.controllersSettings.ExitKey = Keys.Escape;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.keyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (this.keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            this.player.Update();
            this.playerAbilities.Update();

            // Move left
            this.player.MoveLeft(gameTime, this.controllersSettings.MoveLeftKey);
            if (this.player.IsMovingLeft)
            {
                // Load new texture depending on the direction of player
                Texture2D newPlayerTexture = this.Content.Load<Texture2D>("Player/PlayerTurnedLeft");
                this.player.ChangeTexture = newPlayerTexture;

                MoveBakgroundRight(gameTime);
                MoveObjectRight(this.initializeFirstLevel.BackgroundObjects, gameTime, BACKGROUND_SLIDING_VELOCITY);
            }

            // Move right
            this.player.MoveRight(gameTime, this.controllersSettings.MoveRightKey);
            if (this.player.IsMovingRight)
            {
                // Load new texture depending on the direction of player
                Texture2D newPlayerTexture = this.Content.Load<Texture2D>("Player/PlayerTurnedRight");
                this.player.ChangeTexture = newPlayerTexture;

                MoveBakgroundLeft(gameTime);
                MoveObjectsLeft(this.initializeFirstLevel.BackgroundObjects, gameTime, BACKGROUND_SLIDING_VELOCITY);
            }

            // Shooting   
            if ((this.player.IsTurnedRight) &&
                (!this.isPlayerShooting))
            {
                Texture2D bulletTexture = Content.Load<Texture2D>("Bullets/bullet_right");
                Vector2 bulletPosition = new Vector2(this.player.XPosition + this.player.Width - 87, this.player.YPosition + MUZZLE_OF_GUN_POSITION);
                this.bullet = new Bullet(bulletTexture, bulletPosition);
            }
            else if (!this.isPlayerShooting)
            {
                Texture2D bulletTexture = Content.Load<Texture2D>("Bullets/bullet_left");
                Vector2 bulletPosition = new Vector2(this.player.XPosition, this.player.YPosition + MUZZLE_OF_GUN_POSITION);
                this.bullet = new Bullet(bulletTexture, bulletPosition);
            }

            if (this.bullet != null)
            {
                this.playerAbilities.Shooting(bullet, gameTime, this.player.IsTurnedRight, 0, this.windowWidth);
                this.isPlayerShooting = this.playerAbilities.IsShooting;
            }

            // Jumping       
            this.isPlayerJumping = IsPlayerJumping(gameTime, this.controllersSettings.JumpKey);
            
            //this.playerAbilities.Jumping(gameTime, this.controllersSettings.JumpKey);
            //if (this.playerAbilities.IsJumping)
            if (this.isPlayerJumping)
            {
                this.jumpingVelocity = JUMPING_VELOCITY;
                this.isGravityOn = true;
                this.isPlayerOnGround = false;
                this.timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
                //    if (this.player.BoundingBox.Bottom > this.floor.BoundingBox.Top)
                //    {
                //        this.player.Position = new Vector2(
                //            this.windowCenter - (this.player.Width / 2), 
                //            this.floor.BoundingBox.Top - this.player.Height);
                //        this.playerAbilities.IsJumping = false;
                //    }
            }

            CollisionDetectionPerPixel(gameTime);

            if ((float)gameTime.ElapsedGameTime.TotalSeconds > this.timer + 1)
            {
                if (!this.isPlayerJumping)
                {
                    if (this.hasBottomCollision)
                    {
                        this.isPlayerOnGround = true;
                        this.isGravityOn = false;
                        //this.isPlayerJumping = false;
                        this.oldJumpingVelocity = this.jumpingVelocity;
                    }
                }
            }

            if (!this.hasBottomCollision)
            {
                this.isPlayerOnGround = false;
                this.isGravityOn = true;
            }

            if((this.isGravityOn && !isPlayerOnGround) || this.isPlayerJumping)
            {
                    this.player.YPosition += this.jumpingVelocity;
                    this.jumpingVelocity++;

                    if (this.jumpingVelocity == 0)
                    {
                        this.isPlayerJumping = false;
                    }

                    if (this.player.YPosition + this.player.Height > this.floor.YPosition)
                    {
                        this.isGravityOn = false;
                        this.isPlayerJumping = false;
                        this.isPlayerOnGround = true;
                    }
            }

            base.Update(gameTime);
        }


        public bool IsPlayerJumping(GameTime gameTime, Keys jumpKey)
        {
            bool isPlayerJump = false;

            if (this.keyboardState.IsKeyDown(jumpKey))
                {                    
                    isPlayerJump = true;
                }
           
                return isPlayerJump;
        }
        

        private void Gravity(GameTime gameTime)
        {
            if ((!this.isPlayerOnGround) && (!this.hasBottomCollision))
            {
                this.player.YPosition += this.playerAbilities.JumpingVelocity * ((float)gameTime.ElapsedGameTime.TotalSeconds * 50);
                this.playerAbilities.JumpingVelocity++;
            }

            if (this.player.BoundingBox.Bottom > this.floor.BoundingBox.Top)
            {
                this.playerAbilities.IsJumping = false;
                this.playerAbilities.JumpingVelocity = JUMPING_VELOCITY;
                this.isPlayerOnGround = true;
            }
        }

        private void CollisionDetectionPerPixel(GameTime gameTime)
        {
            foreach (List<GameObject> childLevelObjects in this.levelObjectsPerFrame)
            {
                foreach (GameObject levelObject in childLevelObjects)
                {
                        this.hasBottomCollision = this.collisions.IntersectPerPixelBottom(
                            this.player.BoundingBox, this.player.TextureData,
                            levelObject.BoundingBox, levelObject.TextureData);
                        
                        this.hasTopCollision = this.collisions.IntersectPerPixelTop(
                           this.player.BoundingBox, this.player.TextureData,
                           levelObject.BoundingBox, levelObject.TextureData);
                        
                        this.hasLeftCollision = this.collisions.IntersectPerPixelLeft(
                            this.player.BoundingBox, this.player.TextureData,
                            levelObject.BoundingBox, levelObject.TextureData);

                        this.hasRightCollision = this.collisions.IntersectPerPixelRight(
                            this.player.BoundingBox, this.player.TextureData,
                            levelObject.BoundingBox, levelObject.TextureData);


                        if (this.hasBottomCollision)
                        {
                            this.playerAbilities.IsJumping = false;
                            return;
                        }
                        
                        if (this.hasTopCollision)
                        {
                            this.playerAbilities.JumpingVelocity = Math.Abs(this.playerAbilities.JumpingVelocity) - 2;

                            return;
                        }
                        
                        if (this.hasLeftCollision)
                        {
                            this.player.XPosition = levelObject.BoundingBox.Right;
                            return;
                        }
                        
                        if (this.hasRightCollision)
                        {
                            this.player.XPosition = levelObject.BoundingBox.Left;
                            return;
                        }

                    //}
                }
            }
        }
        
        private void MoveObjectsLeft(List<GameObject> levelObjects, GameTime gametime, float velocity)
        {
            foreach (GameObject levelObject in levelObjects)
            {
                levelObject.XPosition -= (int)(velocity * (float)gametime.ElapsedGameTime.TotalSeconds);
            }
        }

        private void MoveObjectRight(List<GameObject> levelObjects, GameTime gametime, float velocity)
        {
            foreach (GameObject levelObject in levelObjects)
            {
                levelObject.XPosition += (int)(velocity * (float)gametime.ElapsedGameTime.TotalSeconds);
            }
        }

        private void MoveBakgroundLeft(GameTime gametime)
        {
            foreach (List<GameObject> childLevelObjects in this.levelObjectsPerFrame)
            {
                foreach (GameObject levelObject in childLevelObjects)
                {
                    levelObject.XPosition -= (int)(SLIDING_FLOOR_VELOCITY * (float)gametime.ElapsedGameTime.TotalSeconds);
                }
            }
        }

        private void MoveBakgroundRight(GameTime gametime)
        {
            foreach (List<GameObject> childLevelObjects in this.levelObjectsPerFrame)
            {
                foreach (GameObject levelObject in childLevelObjects)
                {
                    levelObject.XPosition += (int)(SLIDING_FLOOR_VELOCITY * (float)gametime.ElapsedGameTime.TotalSeconds);
                }
            }
        }

        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            this.initializeFirstLevel.Draw(spriteBatch);
            
            this.playerAbilities.Draw(spriteBatch);

            // Draw player
            this.player.Draw(spriteBatch);
            
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
