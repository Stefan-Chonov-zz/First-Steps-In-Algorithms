using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ColonelChip
{
    interface IUserControllersSettings
    {
        Keys MoveLeftKey { get; set; }
        Keys MoveRightKey { get; set; }
        Keys JumpKey { get; set; }
        Keys ShootKey { get; set; }
        Keys ExitKey { get; set; }
        Keys PauseKey { get; set; }
    }
}
