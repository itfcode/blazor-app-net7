namespace ITFCode.Core.Static
{
    public static class AppConsole
    {
        #region Public Methods

        public static void Info(string text) => WriteLine(text, ConsoleColor.DarkCyan);
        public static void Warn(string text) => WriteLine(text, ConsoleColor.DarkYellow);
        public static void Error(string text) => WriteLine(text, ConsoleColor.DarkRed);

        #endregion

        #region Private Methods 

        private static void WriteLine(string text, ConsoleColor color)
        {
            var foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = foregroundColor;
        }

        #endregion
    }
}