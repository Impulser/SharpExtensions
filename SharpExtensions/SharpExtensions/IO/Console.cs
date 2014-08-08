using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

using SharpExtensions.Annotations;
using SharpExtensions.Extensions.String;
using SharpExtensions.Windows;

using SystemConsole = System.Console;

namespace SharpExtensions.IO
{
    public static partial class Console
    {
        const int SWP_NOSIZE = 0x0001;


        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        private static Dictionary<char, ConsoleColor> _colours = new Dictionary<char, ConsoleColor>
        {
            {
                'E',
                ConsoleColor.Black
            },
            {
                'B',
                ConsoleColor.Blue
            },
            {
                'G',
                ConsoleColor.Green
            },
            {
                'C',
                ConsoleColor.Cyan
            },
            {
                'R',
                ConsoleColor.Red
            },
            {
                'M',
                ConsoleColor.Magenta
            },
            {
                'Y',
                ConsoleColor.Yellow
            },
            {
                'W',
                ConsoleColor.White
            }
        };

        private static object lockObject = new object();

        private static char[] formatTokens = { '^' };

        public static RECT ConsoleRectangle
        {
            get
            {
                RECT rect;
                return GetWindowRect(GetConsoleWindow(), out rect) ? rect : default(RECT);
            }
        }

        [StringFormatMethod("format")]
        private static void CustomWrite(string format, params object[] arguments)
        {
            CustomWrite(format.Build(arguments));
        }

        private static void CustomWrite(string format)
        {
            var fragments = format.Split(formatTokens, StringSplitOptions.RemoveEmptyEntries);
            lock (lockObject)
            {
                foreach (var fragment in fragments)
                {
                    var text = fragment;
                    var key = text[0];
                    ConsoleColor value;
                    if (_colours.TryGetValue(char.ToUpper(key), out value))
                    {
                        text = text.Substring(1);
                        ForegroundColor = value;
                    }
                    else
                    {
                        SystemConsole.ResetColor();
                    }
                    SystemConsole.Write(text);
                }
            }
            SystemConsole.ResetColor();
        }

        [StringFormatMethod("format")]
        public static void WriteLine(string format, params object[] args)
        {
            CustomWrite(format, args);
            Out.WriteLine();
        }

        [StringFormatMethod("format")]
        public static void Write(string format, params object[] args)
        {
            CustomWrite(format, args);
        }

        private static void SystemWrite(string text)
        {
            SystemConsole.Write(text);
        }

        private static void SystemWriteLine(string text)
        {
            SystemConsole.WriteLine(text);
        }

        public static void Write<TValue>(TValue value)
        {
            CustomWrite("{0}", value);
        }

        public static void WriteLine<TValue>(TValue value)
        {
            CustomWrite("{0}", value);
            Out.WriteLine();
        }

        #region System.Consple Implementations

        public static TextWriter Error
        {
            get { return SystemConsole.Error; }
        }

        public static TextReader In
        {
            get { return SystemConsole.In; }
        }

        public static TextWriter Out
        {
            get { return SystemConsole.Out; }
        }

        public static Encoding InputEncoding
        {
            get { return SystemConsole.InputEncoding; }
        }

        public static Encoding OutputEncoding
        {
            get { return SystemConsole.OutputEncoding; }
        }

        public static ConsoleColor BackgroundColor
        {
            get { return SystemConsole.BackgroundColor; }
            set { SystemConsole.BackgroundColor = value; }
        }

        public static ConsoleColor ForegroundColor
        {
            get { return SystemConsole.ForegroundColor; }
            set { SystemConsole.ForegroundColor = value; }
        }

        public static int BufferHeight
        {
            get { return SystemConsole.BufferHeight; }
            set { SystemConsole.BufferHeight = value; }
        }

        public static int BufferWidth
        {
            get { return SystemConsole.BufferWidth; }
            set { SystemConsole.BufferWidth = value; }
        }

        public static int WindowHeight
        {
            get { return SystemConsole.WindowHeight; }
            set { SystemConsole.WindowHeight = value; }
        }

        public static int WindowWidth
        {
            get { return SystemConsole.WindowWidth; }
            set { SystemConsole.WindowWidth = value; }
        }

        public static int LargestWindowWidth
        {
            get { return SystemConsole.LargestWindowWidth; }
        }

        public static int LargestWindowHeight
        {
            get { return SystemConsole.LargestWindowHeight; }
        }

        public static int WindowLeft
        {
            get { return SystemConsole.WindowLeft; }
            set { SystemConsole.WindowLeft = value; }
        }

        public static int WindowTop
        {
            get { return SystemConsole.WindowTop; }
            set { SystemConsole.WindowTop = value; }
        }

        public static int CursorLeft
        {
            get { return SystemConsole.CursorLeft; }
            set { SystemConsole.CursorLeft = value; }
        }

        public static int CursorTop
        {
            get { return SystemConsole.CursorTop; }
            set { SystemConsole.CursorTop = value; }
        }

        public static int CursorSize
        {
            get { return SystemConsole.CursorSize; }
            set { SystemConsole.CursorSize = value; }
        }

        public static bool CursorVisible
        {
            get { return SystemConsole.CursorVisible; }
            set { SystemConsole.CursorVisible = value; }
        }

        public static string Title
        {
            get { return SystemConsole.Title; }
            set { SystemConsole.Title = value; }
        }

        public static bool KeyAvailable
        {
            get { return SystemConsole.KeyAvailable; }
        }

        public static bool NumberLock
        {
            get { return SystemConsole.NumberLock; }
        }

        public static bool CapsLock
        {
            get { return SystemConsole.CapsLock; }
        }

        public static bool TreatControlCAsInput
        {
            get { return SystemConsole.TreatControlCAsInput; }
            set { SystemConsole.TreatControlCAsInput = value; }
        }

        public static void Beep()
        {
            SystemConsole.Beep();
        }

        public static void Beep(int frequency, int duration)
        {
            SystemConsole.Beep(frequency, duration);
        }

        public static void Clear()
        {
            SystemConsole.Clear();
        }

        public static void ResetColor()
        {
            SystemConsole.ResetColor();
        }

        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
        {
            SystemConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        }

        public static void MoveBufferArea(int sourceLeft,
                                          int sourceTop,
                                          int sourceWidth,
                                          int sourceHeight,
                                          int targetLeft,
                                          int targetTop,
                                          char sourceChar,
                                          ConsoleColor sourceForeColor,
                                          ConsoleColor sourceBackColor)
        {
            SystemConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
        }

        public static void Clear(int x, int y, int width, int height)
        {
            Clear(new Rectangle(x, y, width, height));
        }

        public static void Clear(Rectangle rectangle)
        {
            MoveBufferArea(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, Console.WindowWidth, Console.WindowHeight, ' ', ForegroundColor, BackgroundColor);
        }

        public static void SetBufferSize(int width, int height)
        {
            SystemConsole.SetBufferSize(width, height);
        }

        public static void SetWindowSize(int width, int height)
        {
            SystemConsole.SetWindowSize(width, height);
        }

        public static void SetWindowPosition(int left, int top)
        {
            SystemConsole.SetWindowPosition(left, top);
        }

        public static void SetCursorPosition(int left, int top)
        {
            SystemConsole.SetCursorPosition(left, top);
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return SystemConsole.ReadKey();
        }

        public static ConsoleKeyInfo ReadKey(bool intercept)
        {
            return SystemConsole.ReadKey(intercept);
        }

        public static event ConsoleCancelEventHandler CancelKeyPress
        {
            add { SystemConsole.CancelKeyPress += value; }
            remove { SystemConsole.CancelKeyPress -= value; }
        }

        public static Stream OpenStandardError()
        {
            return SystemConsole.OpenStandardError();
        }

        public static Stream OpenStandardError(int bufferSize)
        {
            return SystemConsole.OpenStandardError(bufferSize);
        }

        public static Stream OpenStandardInput()
        {
            return SystemConsole.OpenStandardInput();
        }

        public static Stream OpenStandardInput(int bufferSize)
        {
            return SystemConsole.OpenStandardInput(bufferSize);
        }

        public static Stream OpenStandardOutput()
        {
            return SystemConsole.OpenStandardOutput();
        }

        public static Stream OpenStandardOutput(int bufferSize)
        {
            return SystemConsole.OpenStandardOutput(bufferSize);
        }

        public static void SetIn(TextReader newIn)
        {
            SystemConsole.SetIn(newIn);
        }

        public static void SetOut(TextWriter newOut)
        {
            SystemConsole.SetOut(newOut);
        }

        public static void SetError(TextWriter newError)
        {
            SystemConsole.SetError(newError);
        }

        public static int Read()
        {
            return In.Read();
        }

        public static string ReadLine()
        {
            return In.ReadLine();
        }

        #endregion

    }
}
