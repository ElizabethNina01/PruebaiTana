using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace BackendData.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            static IEnumerable<char> Convert(CharEnumerator e)
            {
                if(!e.MoveNext()) yield break;

                if (char.IsUpper(e.Current))
                    yield return char.ToLower(e.Current);
                while (e.MoveNext())
                {
                    if (char.IsUpper(e.Current))
                    {
                        yield return '_';
                        yield return char.ToLower(e.Current);
                    }
                    else
                    {
                        yield return e.Current;
                    }
                }
            }
            return new string(Convert(str.GetEnumerator()).ToArray());
        }
    }
}
