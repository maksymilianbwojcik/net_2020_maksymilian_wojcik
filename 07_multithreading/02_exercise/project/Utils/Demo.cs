using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class Demo
    {
        private readonly int[] _data;

        public Demo(int[] data)
        {
            _data = data;
        }

        public int Sum()
        {
            // TODO: Use for loop to calculate sum

            var sum = 0;
            
            for (int i = 0; i < _data.Length; i++)
            {
                sum += _data[i];
            }
            return sum;
        }

        public int SumForeach()
        {
            // TODO: Use foreach loop to calculate sum

            var sum = 0;

            foreach (var element in _data)
            {
                sum += element;
            }
            return sum;
        }

        public int SumLinq()
        {
            // TODO: Use for LINQ to calculate sum
            
            return _data.Sum();
        }

        private delegate void ThreadAction(int start, int stop);

        private void RunStandaloneThreads(int count, ThreadAction action)
        {
            // TODO: Run 'count' threads and execute 'action' in every one with appropriate range of data

            Thread[] threads = new Thread[count];

            for (int i = 0; i < count; i++)
            {
                var IDontUnderstandCSharp = i;
                threads[i] = new Thread(() => action(IDontUnderstandCSharp * _data.Length / count, (IDontUnderstandCSharp + 1) * _data.Length / count));
                threads[i].Start();
            }

            for (int i = 0; i < count; i++)
            {
                threads[i].Join();
            }

        }

        public int SumThreadsInterlocked(int count)
        {
            // TODO: Use 'Interlocked.Add' to calculate total sum
            // TODO: Use 'RunStandaloneThreads' to run threads
            // TODO: Use lambda to pass 'action' to 'RunStandaloneThreads'

            int sum = 0;
            
            RunStandaloneThreads(count, (start, stop) =>
            {
                for (int i = start; i < stop; i++)
                {
                    Interlocked.Add(ref sum, _data[i]);
                }
            });
            
            return sum;
        }

        
        public int SumThreads(int count)
        {
            // TODO: Use 'Interlocked.Add' to calculate total sum
            // TODO: Use partial sum in threads to avoid excessive use of 'Interlocked.Add'
            // TODO: Use 'RunStandaloneThreads' to run threads
            // TODO: Use lambda to pass 'action' to 'RunStandaloneThreads'

            var sum = 0;
            
            RunStandaloneThreads(count, (start, stop) =>
            {
                var partial = 0;
                for (int i = start; i < stop; i++)
                {
                    partial += _data[i];
                }
                Interlocked.Add(ref sum, partial);
            });
            
            return sum;

            // return count;
            // return 0;
        }

        private void RunPoolThreads(int count, ThreadAction action)
        {
            // TODO: Run 'count' pool threads and execute 'action' in every one with appropriate range of data
            // TODO: Use 'ManualResetEvent' to synchronize operations

            var events = new List<ManualResetEvent>();
            
            for (int i = 0; i < count; i++)
            {
                var IDontUnderstandCSharp = i;
                var resetEvent = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    action(IDontUnderstandCSharp * _data.Length / count,
                        (IDontUnderstandCSharp + 1) * _data.Length / count);
                    resetEvent.Set();
                });
                events.Add(resetEvent);
            }
            
            WaitHandle.WaitAll(events.ToArray<WaitHandle>());
        }

        public int SumPoolThreads(int count)
        {
            // TODO: Use 'RunPoolThreads' to run threads
            // TODO: Use 'Interlocked.Add' to aggregate data
            // TODO: Ue lambda to poss 'action' to 'RunPoolThreads'

            int sum = 0;
            
            RunPoolThreads(count, (start, stop) =>
            {
                var partial = 0;
                for (int i = start; i < stop; i++)
                {
                    partial += _data[i];
                }
                Interlocked.Add(ref sum, partial);
            });
            
            return sum;
        }

        public int SumTpl()
        {
            // TODO: Use 'Parallel.For' to calculate sum
            // TODO: Ue lambdas to poss operations

            var sum = 0;
            
//            Parallel.For(0, _data.Length, value =>  Interlocked.Add(ref sum, _data[value]));
            Parallel.For(0, 8, value =>
            {
                var partial = 0;
                for (int i = value * _data.Length / 8; i < (value + 1) * _data.Length / 8; i++)
                {
                    partial += _data[i];
                }
                Interlocked.Add(ref sum, partial);
            });
                
            return sum;
        }
    }
}