using System.Collections.Generic;
using System.Linq;

namespace PaperEnigma.Utils
{
    public static class ListExtensions
    {
        public static List<T> Rotate<T>(this List<T> list, int offset)
        {
            return list.Skip(offset).Concat(list.Take(offset)).ToList();
        }
    }
}