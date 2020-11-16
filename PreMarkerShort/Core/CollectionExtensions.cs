﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PreMarkerShort.Core
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}