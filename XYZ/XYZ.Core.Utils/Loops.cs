#define OPTIMIZED

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XYZ
{
    public class Loops
    {
#if !OPTIMIZED
        private static int tempTake = 1;
#endif
        public static void Loop<TParam>(IEnumerable<TParam> collection, Action<TParam> action)
        {
#if OPTIMIZED
            Parallel.ForEach(collection, item =>
#else
            //var col = collection.Take(tempTake);
            foreach (var item in collection)
#endif
            {
                action(item);
            }
#if OPTIMIZED
            );
#endif
        }
        public static void Loop(int from, int to, Action<int> action)
        {
#if OPTIMIZED
            Parallel.For(from, to, i =>
#else
            for (int i = from; i < to/* (from + tempTake)*/; i++)
#endif
            {
                action(i);
            }
#if OPTIMIZED
            );
#endif

        }
    }
}
