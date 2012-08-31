using System;
using System.Drawing;

interface IPlayer
{
    string Shape { get; set; }
    ConsoleColor Color { get; set; }
    Point Position { get; set; }
}
