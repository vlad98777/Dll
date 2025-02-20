using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TextLibrary
    {
        public static class TextUtils
        {
            public static bool IsPalindrome(string text)
            {
                string reversed = new string(text.Reverse().ToArray());
                return string.Equals(text, reversed, StringComparison.OrdinalIgnoreCase);
            }

            public static int CountSentences(string text)
            {
                return Regex.Matches(text, @"[.!?]").Count;
            }

            public static string ReverseString(string text)
            {
                return new string(text.Reverse().ToArray());
            }
        }
    }