using System.Collections.Generic;

namespace Utils
{
    public static class FilterExtension
    {
        // TODO: Even...

//        public static List<int> Even(this List<int> list)
//        {
//            var output = new List<int>();
//            if (list == null) throw new ArgumentNullException(nameof(list));
//            foreach (var element in list)
//            {
//                if (element % 2 == 0) output.Add(element);
//            }
//
//            return output;
//        }

        public static IEnumerable<int> Even(this IEnumerable<int>? enumerable)
        {

            if (enumerable == null) yield break;
            // if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            // (enumerable ??= new enumerable.GetType()<int>);
            
            
            foreach (var element in enumerable)
            {
                if (element % 2 == 0) yield return element;
            }
        }


        // TODO: Odd...

//        public static List<int> Odd(this List<int> list)
//        {
//            var output = new List<int>();
//            if (list == null) throw new ArgumentNullException(nameof(list));
//            foreach (var element in list)
//            {
//                if (element % 2 == 1) output.Add(element);
//            }
//
//            return output;
//        }
        
        public static IEnumerable<int> Odd(this IEnumerable<int>? enumerable)
        {

            if (enumerable == null) yield break;
            // if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            
            foreach (var element in enumerable)
            {
                if (element % 2 != 0) yield return element;
            }
        }
        
        // TODO: Only...

        public static IEnumerable<int> Only(this IEnumerable<int>? enumerable, int lastIndex)
        {
            if (enumerable == null) yield break;
            // if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            IEnumerator<int> iterator = enumerable.GetEnumerator();
            var index = 0;
            
            do
            {
                index++;
                iterator.MoveNext();
                yield return iterator.Current;
            } while (   
                index < lastIndex
            );
            iterator.Dispose();
            
        }
    }
}