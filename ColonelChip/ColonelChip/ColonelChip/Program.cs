using System;

namespace ColonelChip
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ColonelChip game = new ColonelChip())
            {
                game.Run();
            }
        }
    }
#endif
}

