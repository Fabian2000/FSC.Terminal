using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FSC
{
    /// <summary>
    /// Terminal is a copy from the console class with the same or similar + advanced features. Don't use Console, use Terminal
    /// </summary>
    public static partial class Terminal
    {
        /// <summary>
        /// Gets or sets the background color of the console
        /// </summary>
        public static ConsoleColor BackgroundColor
        {
            get => Console.BackgroundColor;
            set => Console.BackgroundColor = value;
        }

        /// <summary>
        /// Gets or sets the foreground color of the console.
        /// </summary>
        public static ConsoleColor ForegroundColor
        {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }

        /// <summary>
        /// Gets or sets the height of the buffer area
        /// </summary>
        public static int BufferHeight
        {
            get => Console.BufferHeight;
            set
            {
                try
                {
                    Console.BufferHeight = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets or sets the width of the buffer area
        /// </summary>
        public static int BufferWidth
        {
            get => Console.BufferWidth;
            set
            {
                try
                {
                    Console.BufferWidth = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the CAPS LOCK keyboard toggle is turned on or turned off
        /// </summary>
        public static bool CapsLock
        {
            get
            {
                try
                {
                    return Console.CapsLock;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets a value indicating whether a key press is available in the input stream
        /// </summary>
        public static bool KeyAvailable
        {
            get => Console.KeyAvailable;
        }

        /// <summary>
        /// Gets a value indicating whether the NUM LOCK keyboard toggle is turned on or turned off
        /// </summary>
        public static bool NumberLock
        {
            get
            {
                try
                {
                    return Console.NumberLock;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the combination of the System.ConsoleModifiers.Control modifier key and System.ConsoleKey.C console key (Ctrl+C) is treated as ordinary input or as an interruption that is handled by the operating system
        /// </summary>
        public static bool TreatControlCAsInput
        {
            get => Console.TreatControlCAsInput;
            set => Console.TreatControlCAsInput = value;
        }

        /// <summary>
        /// Gets or sets the column position of the cursor within the buffer area
        /// </summary>
        public static int CursorLeft
        {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }

        /// <summary>
        /// Gets or sets the height of the cursor within a character cell
        /// </summary>
        public static int CursorSize
        {
            get => Console.CursorSize;
            set
            {
                try
                {
                    Console.CursorSize = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets or sets the row position of the cursor within the buffer area
        /// </summary>
        public static int CursorTop
        {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the cursor is visible
        /// </summary>
        public static bool CursorVisible
        {
            get
            {
                try
                {
                    return Console.CursorVisible;
                }
                catch { throw; }
            }
            set
            {
                try
                {
                    Console.CursorVisible = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets the standard error output stream
        /// </summary>
        public static TextWriter Error
        {
            get => Console.Error;
        }

        /// <summary>
        /// Gets the standard input stream
        /// </summary>
        public static TextReader In
        {
            get => Console.In;
        }

        /// <summary>
        /// Gets the standard output stream
        /// </summary>
        public static TextWriter Out
        {
            get => Console.Out;
        }

        /// <summary>
        /// Gets or sets the encoding the console uses to read input
        /// </summary>
        public static Encoding InputEncoding
        {
            get => Console.InputEncoding;
            set => Console.InputEncoding = value;
        }

        /// <summary>
        /// Gets or sets the encoding the console uses to write output
        /// </summary>
        public static Encoding OutputEncoding
        {
            get => Console.OutputEncoding;
            set => Console.OutputEncoding = value;
        }

        /// <summary>
        /// Gets a value that indicates whether the error output stream has been redirected from the standard error stream
        /// </summary>
        public static bool IsErrorRedirected
        {
            get => Console.IsErrorRedirected;
        }

        /// <summary>
        /// Gets a value that indicates whether input has been redirected from the standard input stream
        /// </summary>
        public static bool IsInputRedirected
        {
            get => Console.IsInputRedirected;
        }

        /// <summary>
        /// Gets a value that indicates whether output has been redirected from the standard output stream
        /// </summary>
        public static bool IsOutputRedirected
        {
            get => Console.IsOutputRedirected;
        }

        /// <summary>
        /// Gets the largest possible number of console window rows, based on the current font and screen resolution
        /// </summary>
        public static int LargestWindowHeight
        {
            get => Console.LargestWindowHeight;
        }

        /// <summary>
        /// Gets the largest possible number of console window columns, based on the current font and screen resolution
        /// </summary>
        public static int LargestWindowWidth
        {
            get => Console.LargestWindowWidth;
        }

        /// <summary>
        /// Gets or sets the title to display in the console title bar
        /// </summary>
        public static string Title
        {
            get
            {
                try
                {
                    return Console.Title;
                }
                catch { throw; }
            }
            set
            {
                Console.Title = value;

#if NET5_0_OR_GREATER
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Write($"\x1b]2;{value}\x1b\\");
                }
#endif
            }
        }

        /// <summary>
        /// Gets or sets the height of the console window area
        /// </summary>
        public static int WindowHeight
        {
            get => Console.WindowHeight;
            set
            {
                try
                { 
                    Console.WindowHeight = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets or sets the width of the console window area
        /// </summary>
        public static int WindowWidth
        {
            get => Console.WindowWidth;
            set
            {
                try
                {
                    Console.WindowWidth = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets or sets the leftmost position of the console window area relative to the screen buffer
        /// </summary>
        public static int WindowLeft
        {
            get => Console.WindowLeft;
            set
            {
                try
                {
                    Console.WindowLeft = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Gets or sets the top position of the console window area relative to the screen buffer
        /// </summary>
        public static int WindowTop
        {
            get => Console.WindowTop;
            set
            {
                try
                {
                    Console.WindowTop = value;
                }
                catch { throw; }
            }
        }

        /// <summary>
        /// Sets the password char for readline methods with password enabled
        /// </summary>
        public static char PasswordChar { get; set; } = '*';
    }
}