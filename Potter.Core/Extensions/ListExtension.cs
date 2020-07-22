using System.Collections.Generic;
using System.Linq;

namespace Potter.Core.Extentions
{
    public static class ListExtension
    {
        public static List<List<int>> DistinctSplit(this IEnumerable<int> list)
        {
            var listSets = new List<List<int>>() { new List<int>() };

            foreach (var item in list)
            {
                var set = listSets.FirstOrDefault(x => !x.Contains(item));

                if (set != null)
                {
                    set.Add(item);
                }
                else
                {
                    listSets.Add(new List<int>() { item });
                }
            }

            return listSets;
        }
    }
}
