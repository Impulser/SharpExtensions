using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using SharpExtensions.Extensions.Collection;
using SharpExtensions.Extensions.String;
using SharpExtensions.Windows;

using Console = SharpExtensions.IO.Console;

namespace SharpExtensions.Tests
{
    internal class Program
    {
        enum SnakeDirection
        {
            Up,
            Right,
            Down,
            Left
        }

        private static void Main(string[] args)
        {
            var dir = SnakeDirection.Up;
            Console.StartRenderingLoop(() =>
            {
                var r = new Rectangle(10, 10, 2, 2);
                while (true)
                {
                    switch(dir)
                    {
                        case SnakeDirection.Up:
                            r.Y--;
                            break;
                        case SnakeDirection.Right:
                            r.X++;
                            break;
                        case SnakeDirection.Down:
                            r.Y++;
                            break;
                        case SnakeDirection.Left:
                            r.X--;
                            break;
                    }
                    var consoleRectangle = Console.ConsoleRectangle;
                    var consoleX = consoleRectangle.X;
                    var consoleY = consoleRectangle.Y - consoleRectangle.Height / 2;
                    var dX = Math.Abs(Cursor.Position.X - consoleX);
                    var dY = Math.Abs(Cursor.Position.Y - consoleY);
                    var xIndex = Math.Max(dX / 8, 0);
                    var yIndex = Math.Max((dY / 12) - 20, 0);
                    Console.FillRectangle(r, ConsoleColor.White);
                    Console.DrawText(xIndex, yIndex, "^WMouse Position - X: {0}, Y: {1}", xIndex, yIndex);
                    Thread.Sleep(100);
                    Console.ClearRendered();
                }
            });
           
 
            ConsoleKeyInfo keyInfo;
            var index = 2;
            while ((keyInfo = Console.ReadKey(false)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        dir  = SnakeDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        dir = SnakeDirection.Right;
                        break;
                    case ConsoleKey.DownArrow:
                        dir = SnakeDirection.Down;
                        break;
                    case ConsoleKey.UpArrow:
                        dir = SnakeDirection.Up;
                        break;
                }
            }
        }
    }
}
