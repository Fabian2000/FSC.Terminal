using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FSC
{
    public static partial class Terminal
    {
        /// <summary>
        /// Plays the sound of a beep through the console speaker
        /// </summary>
        public static void Beep()
        {
            Console.Beep();
        }

        /// <summary>
        /// Plays the sound of a beep of a specified frequency and duration through the console speaker
        /// </summary>
        /// <param name="frequency">The frequency of the beep, ranging from 37 to 32767 hertz</param>
        /// <param name="duration">The duration of the beep measured in milliseconds</param>
        public static void Beep(int frequency, int duration)
        {
            try
            {
                Console.Beep(frequency, duration);
            }
            catch { throw; }
        }

        /// <summary>
        /// Clears the console buffer and corresponding console window of display information
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Works like pressing backspace and goes one char back in the console
        /// </summary>
        public static void Back()
        {
            Console.WriteLine("\b \b");
        }

        /// <summary>
        /// Works like pressing backspace and goes one char back in the console
        /// </summary>
        public static void Backspace()
        {
            Back();
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Gets the position of the cursor
        /// </summary>
        /// <returns>The column and row position of the cursor</returns>
        public static (int Left, int Top) GetCursorPosition()
        {
            return Console.GetCursorPosition();
        }
#endif
        /// <summary>
        /// Sets the position of the cursor
        /// </summary>
        /// <param name="left">The column position of the cursor. Columns are numbered from left to right starting at 0</param>
        /// <param name="top">The row position of the cursor. Rows are numbered from top to bottom starting at 0</param>
        public static void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination area
        /// </summary>
        /// <param name="sourceLeft">The leftmost column of the source area</param>
        /// <param name="sourceTop">The topmost row of the source area</param>
        /// <param name="sourceWidth">The number of columns in the source area</param>
        /// <param name="sourceHeight">The number of rows in the source area</param>
        /// <param name="targetLeft">The leftmost column of the destination area</param>
        /// <param name="targetTop">The topmost row of the destination area</param>
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
        {
            try
            {
                Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
            }
            catch { throw; }
        }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination area
        /// </summary>
        /// <param name="sourceLeft">The leftmost column of the source area</param>
        /// <param name="sourceTop">The topmost row of the source area</param>
        /// <param name="sourceWidth">The number of columns in the source area</param>
        /// <param name="sourceHeight">The number of rows in the source area</param>
        /// <param name="targetLeft">The leftmost column of the destination area</param>
        /// <param name="targetTop">The topmost row of the destination area</param>
        /// <param name="sourceChar">The character used to fill the source area</param>
        /// <param name="sourceForeColor">The foreground color used to fill the source area</param>
        /// <param name="sourceBackColor">The background color used to fill the source area</param>
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
        {
            try
            {
                Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
            }
            catch { throw; }
        }

        /// <summary>
        /// Sets the height and width of the screen buffer area to the specified values
        /// </summary>
        /// <param name="width">The width of the buffer area measured in columns</param>
        /// <param name="height">The height of the buffer area measured in rows</param>
        public static void SetBufferSize(int width, int height)
        {
            try
            {
                Console.SetBufferSize(width, height);
            }
            catch { throw; }
        }

        /// <summary>
        /// Acquires the standard error stream
        /// </summary>
        /// <returns>The standard error stream</returns>
        public static Stream OpenStandardError()
        {
            return Console.OpenStandardError();
        }

        /// <summary>
        /// Acquires the standard error stream, which is set to a specified buffer size
        /// </summary>
        /// <param name="bufferSize">This parameter has no effect, but its value must be greater than or equal to zero</param>
        /// <returns>The standard error stream</returns>
        public static Stream OpenStandardError(int bufferSize)
        {
            return Console.OpenStandardError(bufferSize);
        }

        /// <summary>
        /// Acquires the standard input stream
        /// </summary>
        /// <returns>The standard input stream</returns>
        public static Stream OpenStandardInput()
        {
            return Console.OpenStandardInput();
        }

        /// <summary>
        /// Acquires the standard input stream, which is set to a specified buffer size
        /// </summary>
        /// <param name="bufferSize">This parameter has no effect, but its value must be greater than or equal to zero</param>
        /// <returns>The standard input stream</returns>
        public static Stream OpenStandardInput(int bufferSize)
        {
            return Console.OpenStandardInput(bufferSize);
        }

        /// <summary>
        /// Acquires the standard output stream
        /// </summary>
        /// <returns>The standard output stream</returns>
        public static Stream OpenStandardOutput()
        {
            return Console.OpenStandardOutput();
        }

        /// <summary>
        /// Acquires the standard output stream, which is set to a specified buffer size
        /// </summary>
        /// <param name="bufferSize">This parameter has no effect, but its value must be greater than or equal to zero</param>
        /// <returns>The standard output stream</returns>
        public static Stream OpenStandardOutput(int bufferSize)
        {
            return Console.OpenStandardOutput(bufferSize);
        }

        /// <summary>
        /// Sets the foreground and background console colors to their defaults
        /// </summary>
        public static void ResetColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// Sets the System.Console.Error property to the specified System.IO.TextWriter object
        /// </summary>
        /// <param name="newError">A stream that is the new standard error output</param>
        public static void SetError(TextWriter newError)
        {
            Console.SetError(newError);
        }

        /// <summary>
        /// Sets the System.Console.In property to the specified System.IO.TextReader object
        /// </summary>
        /// <param name="newIn">A stream that is the new standard input</param>
        public static void SetIn(TextReader newIn)
        {
            Console.SetIn(newIn);
        }

        /// <summary>
        /// Sets the System.Console.Out property to target the System.IO.TextWriter object
        /// </summary>
        /// <param name="newOut">A text writer to be used as the new standard output</param>
        public static void SetOut(TextWriter newOut)
        {
            Console.SetOut(newOut);
        }

        /// <summary>
        /// Sets the position of the console window relative to the screen buffer
        /// </summary>
        /// <param name="left">The column position of the upper left corner of the console window</param>
        /// <param name="top">The row position of the upper left corner of the console window</param>
        public static void SetWindowPosition(int left, int top)
        {
            try
            {
                Console.SetWindowPosition(left, top);
            }
            catch { throw; }
        }

        /// <summary>
        /// Sets the height and width of the console window to the specified values
        /// </summary>
        /// <param name="width">The width of the console window measured in columns</param>
        /// <param name="height">The height of the console window measured in rows</param>
        public static void SetWindowSize(int width, int height)
        {
            try
            {
                Console.SetWindowSize(width, height);
            }
            catch { throw; }
        }
    }
}