using System;

namespace FSC
{
    public static partial class Terminal
    {
        /// <summary>
        /// Writes the text representation of the specified generic type value to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        public static void Write<T>(T value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the current line terminator to the standard output stream
        /// </summary>
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified generic type value, followed by the current line terminator, to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        public static void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
}