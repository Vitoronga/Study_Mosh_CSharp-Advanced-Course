using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static string Shorten(this String str, int wordCount)
        {
            if (wordCount < 0) throw new ArgumentOutOfRangeException("wordCount", "wordCount has to be equal or greater than 0");
            if (wordCount == 0) return "";

            string[] words = str.Split(' ');

            if (words.Length <= wordCount) return str;

            return string.Join(' ', words.Take(wordCount)) + "...";
        }
    }
}
