using System;
using System.Collections;
using System.Linq;

namespace TestExtensions
{
    public static class StringExtensions
    {
        public static string TrimIndentation(this string str)
        {

            return String.Join("\n", 
                str
                    .Replace(Environment.NewLine, "\n")
                    .Split("\n")
                    .Select (el => el.Trim() )
                    .ToList() );
        }
    }
}