namespace Text.Constants
{
    public static class Separators
    {
        public static string[] SentenceSeparators { get; } =  { "?", "!", ".", "...", "?!" };

        public static string[] InnerSentenceSeparators { get; } = { ",", ";", ":", " ", "    ", "-", "\'", "\"", "(", ")", "\r" };

        public static string[] WordSeparators { get; } = { " ", " - " };
    }
}
