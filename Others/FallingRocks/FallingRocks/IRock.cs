using System;
using System.Drawing;

interface IRock
{
    char Shape { get; set; }
    ConsoleColor Color { get; set; }
    Point Position { get; set; }
}
