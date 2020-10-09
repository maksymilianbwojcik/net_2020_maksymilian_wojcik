using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;

namespace Utils
{
    public class Fibonacci
    {
        public virtual IEnumerable<int> Numbers()
        {
            // TODO: ...    

            var prev = -1;
            var res = 1;
            for (int i = 0; i<44; i++)
            {
                int sum = res + prev;
                prev = res;
                res = sum;
                yield return sum;
            }

            throw new IndexOutOfRangeException();
        }
    }
}