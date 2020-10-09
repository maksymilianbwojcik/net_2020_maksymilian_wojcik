using System.Collections.Generic;

namespace Utils
{
    public class RangeFibonacci : Fibonacci
    {
        // TODO: Fields....

        private readonly int _start;
        private readonly int _step;
        private readonly int _till;

        // TODO: Constructor....

        public RangeFibonacci()
        {
            _start = 0;
            _step = 1;
            _till = 1;
        }

        public RangeFibonacci(int a = 0, int b = 1, int stop = 1)
        {
            _start = a;
            _step = b;
            _till = stop;
        }
        
        public override IEnumerable<int> Numbers()
        {
            // TODO: Implement using version from base class....

            var prev = -1;
            var res = 1;
            for (var i = 0; i<=44; i++)
            {
                var sum = res + prev;
                prev = res;
                res = sum;
                if (i <= _till && i >= _start && (i-_start)%_step==0 )
                    yield return sum;
            }
        }
    }
}