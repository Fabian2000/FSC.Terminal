using System;
using System.Text;

namespace FSC
{
    public static partial class Terminal
    {
        /// <summary>
        /// Reads the next character from the standard input stream
        /// </summary>
        /// <returns>The next character from the input stream, or negative one (-1) if there are currently no more characters to be read</returns>
        public static int Read()
        {
            return Read(string.Empty);
        }

        /// <summary>
        /// Reads the next character from the standard input stream
        /// </summary>
        /// <param name="displayText">Adds an output before the user may input a text</param>
        /// <returns>The next character from the input stream, or negative one (-1) if there are currently no more characters to be read</returns>
        public static int Read<T>(T displayText)
        {
            Write(displayText);
            return Console.Read();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is displayed in the console window
        /// </summary>
        /// <returns>An object that describes the System.ConsoleKey constant and Unicode character, if any, that correspond to the pressed console key. The System.ConsoleKeyInfo object also describes, in a bitwise combination of System.ConsoleModifiers values, whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously with the console key</returns>
        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is displayed in the console window
        /// </summary>
        /// <param name="intercept">Determines whether to display the pressed key in the console window. true to not display the pressed key; otherwise, false</param>
        /// <returns>An object that describes the System.ConsoleKey constant and Unicode character, if any, that correspond to the pressed console key. The System.ConsoleKeyInfo object also describes, in a bitwise combination of System.ConsoleModifiers values, whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously with the console key</returns>
        public static ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available</returns>
        public static string? ReadLine()
        {
            return ReadLine(string.Empty);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream
        /// </summary>
        /// <param name="passwordMode">Decides, if the input will be visible or hidden</param>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available</returns>
        public static string? ReadLine(TerminalPasswordMode passwordMode)
        {
            return ReadLine(string.Empty, passwordMode);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream
        /// </summary>
        /// <param name="displayText">Adds an output before the user may input a text</param>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available</returns>
        public static string? ReadLine<T>(T displayText)
        {
            return ReadLine(displayText, TerminalPasswordMode.None);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="passwordMode">Decides, if the input will be visible or hidden</param>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available</returns>
        public static string? ReadLine<T>(T displayText, TerminalPasswordMode passwordMode)
        {
            Write(displayText);

            if (passwordMode == TerminalPasswordMode.None)
            {
                return Console.ReadLine();
            }

            var password = new StringBuilder();

            while (true)
            {
                var key = ReadKey(true);

                if (key.Key.Equals(ConsoleKey.Enter))
                {
                    break;
                }
                else if (key.Key.Equals(ConsoleKey.Backspace))
                {
                    if (password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        if (passwordMode == TerminalPasswordMode.HideByChar)
                        {
                            Backspace();
                        }
                    }
                }
                else
                {
                    password.Append(key.KeyChar.ToString());
                    if (passwordMode == TerminalPasswordMode.HideByChar)
                    {
                        Write(PasswordChar);
                    }
                }
            }

            WriteLine();
            return password.ToString();
        }
    }
}