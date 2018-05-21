using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text.Constants
{
    public static class Separators
    {
        public static string[] SentenceSeparators { get; } =  { "?", "!", ".", "...", "?!" };

        public static string[] InnerSentenceSeparators { get; } = { ",", ";", ":" };

        public static string[] WordSeparators { get; } = { " ", " - " };
    }
}
