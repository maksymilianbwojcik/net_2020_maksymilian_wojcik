using System;
using System.Collections.Generic;

namespace Utils
{
    public class Fibonacci
    {
        public virtual IEnumerable<int> Numbers()
        {
            // TODO: ...    

            var prev = -1;
            var res = 1;
            for (var i = 0; i<44; i++)
            {
                var sum = res + prev;
                prev = res;
                res = sum;
                yield return sum;
            }

            throw new IndexOutOfRangeException();
        }
    }
}