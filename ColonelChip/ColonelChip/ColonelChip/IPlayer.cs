using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ColonelChip
{
    interface IPlayer
    {
        Vector2 Position { get; set; }
        Rectangle BoundingBox { get; set; }
        Color[] TextureData { get; set; }

        int Width { get; }
        int Height { get; }        

        //float JumpingVelocity { get; set; }
        //float BulletVelocity { get; set; }
        float Velocity { get; set; }
        float Health { get; set; }

        //Texture2D BulletTexture { get; set; }
        //Vector2 BulletPosition { get; set; }

        void MoveLeft(GameTime gameTime, Keys key);
        void MoveRight(GameTime gameTime, Keys key);
        //void Jumping(Keys key);
        //void ShootingLeft(GameTime gameTime, float distance);
        //void ShootingRight(GameTime gameTime, float distance);
        //void Exiting(GameTime gameTime, Keys key);
        //void Pausing(GameTime gameTime, Keys key);

        bool IsMovingLeft { get; set; }
        bool IsMovingRight { get; set; }
        bool IsTurnedLeft { get; }
        bool IsTurnedRight { get; }
        //bool IsJumping { get; set; }
        //bool IsShootingLeft { get; set; }
        //bool IsShootingRight { get; set; }
        bool IsAlive { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
