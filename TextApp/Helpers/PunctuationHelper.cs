using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Helpers
{
    class PunctuationHelper
    {
        public static string[] RepeatSymbols { get; } = {"\"","'" };
        public static string[] EndSymsols { get; } = { "!", ".", "?", "...", "?!", "!?" };

        public static string[] InnerSymbols { get; } = { ",", ";", ":" };

        public static string[] OpenSymbols { get; } = { "<", "(", "[", "{", "„", "«", "‘" };

        public static string[] CloseSymbols { get; } = { ")", ">", "]", "}", "“", "»", "’" };

        public static string[] AllSymbols { get; } = {
            ",", ".", "!", "?", "—", "-", "\"", "'", "(", ")",
            "<", ">", ":", ";", "[", "]", "{", "}", "‒", "–", "—",
            "―", "„", "“", "«", "»", "‘", "’", "...", "?!", "!?", "*", "/", "=", "==", "!=", ">=", "=<", "+"
        };

        public static string[] OperationSymbols { get; } = { "*", "/", "+", "=", "==", "!=", ">=", "=<" };
    }
}
