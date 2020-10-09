using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Utils
{
    public class RangeFibonacci : Fibonacci
    {
        // TODO: Fields....

        private int start;
        private int step;
        private int till;

        // TODO: Constructor....

        public RangeFibonacci()
        {
            start = 0;
            step = 1;
            till = 1;
        }

        public RangeFibonacci(int a = 0, int b = 1, int stop = 1)
        {
            start = a;
            step = b;
            till = stop;
        }
        
        public override IEnumerable<int> Numbers()
        {
            // TODO: Implement using version from base class....

            var prev = -1;
            var res = 1;
            for (int i = 0; i<=44; i++)
            {
                int sum = res + prev;
                prev = res;
                res = sum;
                if (i <= till && i >= start && (i-start)%step==0 )
                    yield return sum;
            }
        }
    }
}