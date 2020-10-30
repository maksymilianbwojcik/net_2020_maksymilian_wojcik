 Bench.dll                                         | Metric   | Unit | Iterations | Average | STDEV.S |     Min |     Max
:------------------------------------------------- |:-------- |:----:|:----------:| -------:| -------:| -------:| -------:
 Bench.DemoBench.Sum                               | Duration | msec |    1000    |   8.100 |   0.807 |   6.993 |  13.572
 Bench.DemoBench.SumForeach                        | Duration | msec |    1000    |   7.210 |   1.371 |   5.664 |  23.333
 Bench.DemoBench.SumLinq                           | Duration | msec |    186     |  53.953 |   3.322 |  50.052 |  76.196
 Bench.DemoBench.SumPoolThreads(threads: 2)        | Duration | msec |    1000    |   4.439 |   0.623 |   3.586 |  11.210
 Bench.DemoBench.SumPoolThreads(threads: 4)        | Duration | msec |    1000    |   3.742 |   1.298 |   1.929 |  14.347
 Bench.DemoBench.SumPoolThreads(threads: 8)        | Duration | msec |    1000    |   3.018 |   0.578 |   1.945 |  10.125
 Bench.DemoBench.SumThreads(threads: 2)            | Duration | msec |    1000    |   6.396 |   1.719 |   4.090 |  14.105
 Bench.DemoBench.SumThreads(threads: 4)            | Duration | msec |    1000    |   6.331 |   1.297 |   4.297 |  12.025
 Bench.DemoBench.SumThreads(threads: 8)            | Duration | msec |    1000    |   8.737 |  19.091 |   4.804 | 507.625
 Bench.DemoBench.SumThreadsInterlocked(threads: 2) | Duration | msec |     36     | 281.588 |  47.491 | 152.958 | 341.242
 Bench.DemoBench.SumThreadsInterlocked(threads: 4) | Duration | msec |     31     | 324.115 |  38.478 | 204.522 | 361.361
 Bench.DemoBench.SumThreadsInterlocked(threads: 8) | Duration | msec |     32     | 314.573 |  35.062 | 204.832 | 340.198
 Bench.DemoBench.SumTpl                            | Duration | msec |    1000    |   4.019 |   1.042 |   2.894 |  10.302

### Wyjaśnienie czasów:
* _Multithreading_
    * [__Tpl > ThreadPool__](https://devblogs.microsoft.com/pfxteam/choosing-between-the-task-parallel-library-and-the-threadpool/);
    * samodzielne tworzenie wątków jest wolniejsze niż kolejkowanie zadań;
    * __SumThreads vs SumThreadInterlocked__ - SumThreads wykonuje dodawanie równolegle, natomiast Interlocked co prawda wykonuje dodawanie, ale robi to sekwencyjnie, dodatkowo wolniej niż standardowe metody sekwencyjne z powodu tworzenia wątków;
    * __SumThreads__ działa wolniej na wielu wątkach, gdyby dataset był większy przypuszczam, że by się to zmieniło;
    * __Linq__ jest wolniejszy niż inne metody 
* _Sequential_
    * __for vs foreach__ 
      pod względem do wydajności są do siebie bardzo podobne, po przeczytaniu kilku wątków ze stacka dowiedziałem się, że `for` z reguły powinien być szybszy, ale nie zawsze, zależy to od typu danych (możliwe, że nie tylko);
      jeśli to możliwe bezpieczniej jest jednak korzystać z `foreach`'a
  