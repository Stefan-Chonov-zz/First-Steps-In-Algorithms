using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ColonelChip
{
    class UserControllersSettings : IUserControllersSettings
    {
        private Keys moveLeftKey;
        private Keys moveRightKey;
        private Keys jumpKey;
        private Keys shootKey;
        private Keys exitKey;
        private Keys pauseKey;

        public Keys MoveLeftKey
        {
            get
            {
                return this.moveLeftKey;
            }
            set
            {
                this.moveLeftKey = value;
            }
        }

        public Keys MoveRightKey
        {
            get
            {
                return this.moveRightKey;
            }
            set
            {
                this.moveRightKey = value;
            }
        }

        public Keys JumpKey
        {
            get
            {
                return this.jumpKey;
            }
            set
            {
                this.jumpKey = value;
            }
        }

        public Keys ShootKey
        {
            get
            {
                return this.shootKey;
            }
            set
            {
                this.shootKey = value;
            }
        }

        public Keys ExitKey
        {
            get
            {
                return this.exitKey;
            }
            set
            {
                this.exitKey = value;
            }
        }

        public Keys PauseKey
        {
            get
            {
                return this.pauseKey;
            }
            set
            {
                this.pauseKey = value;
            }
        }
    }
}
