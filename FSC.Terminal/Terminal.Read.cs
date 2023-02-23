using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        #if NET6_0_OR_GREATER
        /// <summary>
        /// Reads the next line of characters as a license ____-____-____-____ (AD63-8DT3F-MV8F5-99RS)
        /// </summary>
        /// <param name="license">The license, if input was successful</param>
        /// <param name="sections">Define, how many sections should exist. Sections are splitted by a hyphen</param>
        /// <param name="charsPerSection">Defines, how many chars may be in a section</param>
        /// <returns>True, if the entered license is valid and False if not</returns>
        public static bool ReadLicense(out string license, int sections = 4, int charsPerSection = 4)
        {
            return ReadLicense(string.Empty, out license, sections, charsPerSection);
        }

        /// <summary>
        /// Reads the next line of characters as a license ____-____-____-____ (AD63-8DT3F-MV8F5-99RS)
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="license">The license, if input was successful</param>
        /// <param name="sections">Define, how many sections should exist. Sections are splitted by a hyphen</param>
        /// <param name="charsPerSection">Defines, how many chars may be in a section</param>
        /// <returns>True, if the entered license is valid and False if not</returns>
        public static bool ReadLicense<T>(T displayText, out string license, int sections = 4, int charsPerSection = 4)
        {
            license = string.Empty;

            Write(displayText);

            var maxChars = charsPerSection * sections + sections - 1;
            var chars = new List<char>();

            for (var i = 0; i < sections; i++)
            {
                for (var j = 0; j < charsPerSection; j++)
                {
                    chars.Add('_');
                }
                chars.Add('-');
            }
            chars.RemoveAt(chars.Count - 1);

            Write(string.Concat(chars));

            var textLen = displayText?.ToString()?.Length ?? 0;
            SetCursorPosition(textLen, GetCursorPosition().Top);

            var cursor = GetCursorPosition().Left;

            while (true)
            {
                var key = Console.ReadKey(true);

                if (Regex.IsMatch(key.KeyChar.ToString(), "^[A-Za-z0-9]$") && cursor - textLen != chars.Count)
                {
                    var c = key.KeyChar.ToString().ToUpper();
                    Write(c);
                    chars[cursor - textLen] = c[0];

                    if (chars.Count - 1 > cursor - textLen && chars[cursor - textLen + 1] == '-')
                    {
                        Write("-");
                        cursor++;
                    }

                    cursor++;
                }
                else if (key.Key.Equals(ConsoleKey.Backspace) && cursor - textLen > 0)
                {
                    if (chars[cursor - textLen - 1] == '-')
                    {
                        cursor--;
                    }
                    chars[cursor - textLen - 1] = '_';
                    SetCursorPosition(--cursor, GetCursorPosition().Top);
                    Write("_");
                    SetCursorPosition(cursor, GetCursorPosition().Top);
                }
                else if (key.Key.Equals(ConsoleKey.Enter))
                {
                    WriteLine();
                    break;
                }
                else if (key.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (cursor > textLen)
                    {
                        cursor--;

                        if (chars[cursor - textLen] == '-')
                        {
                            cursor--;
                        }

                        SetCursorPosition(cursor, GetCursorPosition().Top);
                    }
                }
                else if (key.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (cursor < textLen + chars.Count - 1)
                    {
                        cursor++;

                        if (chars[cursor - textLen] == '-')
                        {
                            cursor++;
                        }

                        SetCursorPosition(cursor, GetCursorPosition().Top);
                    }
                }
            }
            
            if (chars.Contains('_'))
            {
                return false;
            }

            license = string.Concat(chars);
            return true;
        }
#endif

        /// <summary>
        /// Reads if the user agree or not
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="yesChar">The char, that is used to agree</param>
        /// <param name="noChar">The char, that is used to disagree</param>
        /// <returns>True, if the user used the yesChar, otherwise False</returns>
        public static bool ReadYesNo<T>(T displayText, char yesChar, char noChar)
        {
            Write(displayText);
            Write($"[{yesChar}|{noChar}] ");
            var ret = false;
            var charLock = false;

            while (true)
            {
                var key = ReadKey(true);

                if (key.KeyChar.Equals(noChar) && !charLock)
                {
                    Write(noChar);
                    ret = false;
                    charLock = true;
                }
                else if (key.KeyChar.Equals(yesChar) && !charLock)
                {
                    Write(yesChar);
                    ret = true;
                    charLock = true;
                }
                else if (key.Key.Equals(ConsoleKey.Enter) && charLock)
                {
                    break;
                }
                else if (key.Key.Equals(ConsoleKey.Backspace) && charLock)
                {
                    charLock = false;
                    Backspace();
                }
            }

            WriteLine();
            return ret;
        }
#if NET6_0_OR_GREATER
        /// <summary>
        /// Reads the selection of an array
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="options">The array of available options</param>
        /// <returns>The index of the selected item</returns>
        public static int ReadSelection<T>(T displayText, params string[] options)
        {
            return ReadSelection<T>(displayText, options.ToList());
        }

        /// <summary>
        /// Reads the selection of an array
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="allowCancel">If true, the user can cancel the selection process</param>
        /// <param name="options">The array of available options</param>
        /// <returns>The index of the selected item (if canceled: -1)</returns>
        public static int ReadSelection<T>(T displayText, bool allowCancel, params string[] options)
        {
            return ReadSelection<T>(displayText, allowCancel, options.ToList());
        }

        /// <summary>
        /// Reads the selection of a list
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="options">The list of available options</param>
        /// <returns>The index of the selected item</returns>
        public static int ReadSelection<T>(T displayText, List<string> options)
        {
            return ReadSelection<T>(displayText, false, options);
        }

        /// <summary>
        /// Reads the selection of a list
        /// </summary>
        /// <param name="displayText">Adds a text before the user may input a text</param>
        /// <param name="allowCancel">If true, the user can cancel the selection process</param>
        /// <param name="options">The list of available options</param>
        /// <returns>The index of the selected item (if canceled: -1)</returns>
        public static int ReadSelection<T>(T displayText, bool allowCancel, List<string> options)
        {
            WriteLine(displayText);

            var selection = 0;
            var minSelection = 0;
            var maxSelection = options.Count - 1;
            var maxWord = options.Max(word => word.Length);
            var emptyChars = Regex.Replace(options.First(word => word.Length == maxWord), ".", " ") + "  ";

            while (true)
            {
                for (var i = 0; i < options.Count; i++)
                {
                    Write(emptyChars);
                    CursorLeft = 0;

                    if (i == selection)
                    {
                        Write("> ");
                    }
                    WriteLine(options[i].ReplaceLineEndings());
                }

                var key = ReadKey(true);

                if (key.Key.Equals(ConsoleKey.Enter))
                {
                    break;
                }
                else if (key.Key.Equals(ConsoleKey.Escape) && allowCancel)
                {
                    selection = -1;
                    break;
                }
                else if (key.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (selection == minSelection)
                    {
                        selection = maxSelection + 1;
                    }
                    selection--;
                }
                else if (key.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (selection == maxSelection)
                    {
                        selection = minSelection - 1;
                    }
                    selection++;
                }

                SetCursorPosition(0, GetCursorPosition().Top - options.Count);
            }

            for (var i = options.Count - 1; i >= 0; i--)
            {
                Write(emptyChars);
                CursorLeft = 0;
                SetCursorPosition(0, GetCursorPosition().Top - 1);
            }
            Write(emptyChars);
            SetCursorPosition(0, GetCursorPosition().Top);

            
            WriteLine(selection == -1 ? "..." : options[selection]);
            return selection;
        }
#endif
    }
}