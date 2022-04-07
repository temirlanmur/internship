namespace TextEditorLogic
{
    public static class StringExtensions
    {
        public static string AddWhiteSpaceCharsFront(this string str, int numberOfChars)
            => new string(' ', numberOfChars) + str;
    }
}
