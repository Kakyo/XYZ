using System;
using System.Collections.Generic;
using System.Linq;

namespace Tw
{
    public static class DictionaryExtensions
    {
        public static TKey MinBy<TKey, TValue>(this Dictionary<TKey, TValue> dictionary
            , Func<KeyValuePair<TKey,TValue>,KeyValuePair<TKey,TValue>,KeyValuePair<TKey,TValue>>  valueSelector)
        {
            if (!dictionary.Any())
                return default(TKey);

            return dictionary.Aggregate(dictionary.First(), valueSelector).Key;
        }
    }
}
