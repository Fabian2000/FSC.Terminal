using System;

namespace FSC
{
    public static partial class Terminal
    {
        /// <summary>
        /// Occurs when the System.ConsoleModifiers.Control modifier key (Ctrl) and either the System.ConsoleKey.C console key (C) or the Break key are pressed simultaneously (Ctrl+C or Ctrl+Break)
        /// </summary>
        public static event ConsoleCancelEventHandler? CancelKeyPress
        {
            add => Console.CancelKeyPress += value;
            remove => Console.CancelKeyPress -= value;
        }
    }
}