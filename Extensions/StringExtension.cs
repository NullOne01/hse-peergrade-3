namespace Peergrade3.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        ///     Default format methods but with no FormatException if no arguments.
        /// </summary>
        /// <param name="str"> String to format. </param>
        /// <param name="args"> Arguments for formatting. </param>
        /// <returns> Formatted string. </returns>
        public static string BetterFormat(this string str, params object[] args)
        {
            if (args.Length == 0)
                return str;
            return string.Format(str, args);
        }
    }
}