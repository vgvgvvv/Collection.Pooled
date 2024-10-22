``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|             Method |  Job | Runtime |      N |           Mean |          Error |         StdDev | Ratio | RatioSD |        Gen 0 |        Gen 1 |        Gen 2 |     Allocated |
|------------------- |----- |-------- |------- |---------------:|---------------:|---------------:|------:|--------:|-------------:|-------------:|-------------:|--------------:|
|   **List_ICollection** |  **Clr** |     **Clr** |   **1000** |     **3,096.9 us** |      **59.244 us** |      **72.757 us** |  **1.00** |    **0.00** |   **12882.8125** |            **-** |            **-** |   **39638.58 KB** |
| Pooled_ICollection |  Clr |     Clr |   1000 |     5,483.7 us |      93.926 us |      87.859 us |  1.77 |    0.05 |      85.9375 |            - |            - |     274.26 KB |
|   List_IEnumerable |  Clr |     Clr |   1000 |    52,250.5 us |   1,032.679 us |     862.333 us | 16.86 |    0.55 |   13444.4444 |            - |            - |   41499.35 KB |
| Pooled_IEnumerable |  Clr |     Clr |   1000 |    53,442.5 us |     990.560 us |     972.862 us | 17.25 |    0.48 |     100.0000 |            - |            - |     470.41 KB |
|                    |      |         |        |                |                |                |       |         |              |              |              |               |
|   List_ICollection | Core |    Core |   1000 |     1,363.1 us |      26.054 us |      25.589 us |  1.00 |    0.00 |    6458.9844 |            - |            - |   19804.69 KB |
| Pooled_ICollection | Core |    Core |   1000 |       698.9 us |       9.328 us |       8.726 us |  0.51 |    0.01 |      88.8672 |            - |            - |     273.44 KB |
|   List_IEnumerable | Core |    Core |   1000 |    43,970.7 us |     851.456 us |     874.382 us | 32.28 |    0.97 |   13416.6667 |            - |            - |   41328.13 KB |
| Pooled_IEnumerable | Core |    Core |   1000 |    43,702.1 us |     769.308 us |     719.612 us | 32.08 |    0.86 |      83.3333 |            - |            - |     468.75 KB |
|                    |      |         |        |                |                |                |       |         |              |              |              |               |
|   **List_ICollection** |  **Clr** |     **Clr** |  **10000** |    **29,538.2 us** |     **585.731 us** |     **626.726 us** |  **1.00** |    **0.00** |  **126562.5000** |            **-** |            **-** |   **392106.5 KB** |
| Pooled_ICollection |  Clr |     Clr |  10000 |    76,666.4 us |   1,315.476 us |   1,230.497 us |  2.59 |    0.08 |            - |            - |            - |     274.29 KB |
|   List_IEnumerable |  Clr |     Clr |  10000 |   508,764.2 us |  10,084.570 us |  11,613.405 us | 17.25 |    0.52 |  208000.0000 |            - |            - |   642609.5 KB |
| Pooled_IEnumerable |  Clr |     Clr |  10000 |   555,109.4 us |  10,926.796 us |  13,818.899 us | 18.88 |    0.56 |            - |            - |            - |        472 KB |
|                    |      |         |        |                |                |                |       |         |              |              |              |               |
|   List_ICollection | Core |    Core |  10000 |    13,986.6 us |     264.036 us |     259.318 us |  1.00 |    0.00 |   63281.2500 |            - |            - |  195585.94 KB |
| Pooled_ICollection | Core |    Core |  10000 |     5,860.3 us |      94.591 us |      88.480 us |  0.42 |    0.01 |      85.9375 |            - |            - |     273.44 KB |
|   List_IEnumerable | Core |    Core |  10000 |   403,339.7 us |   7,914.410 us |   8,468.330 us | 28.90 |    0.91 |  208000.0000 |            - |            - |  641796.88 KB |
| Pooled_IEnumerable | Core |    Core |  10000 |   417,066.1 us |   8,101.958 us |   9,005.305 us | 29.91 |    0.98 |            - |            - |            - |     468.75 KB |
|                    |      |         |        |                |                |                |       |         |              |              |              |               |
|   **List_ICollection** |  **Clr** |     **Clr** | **100000** | **2,246,863.0 us** |  **25,442.955 us** |  **23,799.356 us** |  **1.00** |    **0.00** | **1249000.0000** | **1249000.0000** | **1249000.0000** | **3916484.38 KB** |
| Pooled_ICollection |  Clr |     Clr | 100000 |   639,324.0 us |  11,088.427 us |  10,372.121 us |  0.28 |    0.01 |            - |            - |            - |        280 KB |
|   List_IEnumerable |  Clr |     Clr | 100000 | 6,747,822.7 us | 129,583.440 us | 138,652.829 us |  3.00 |    0.07 | 1428000.0000 | 1428000.0000 | 1428000.0000 | 5132721.06 KB |
| Pooled_IEnumerable |  Clr |     Clr | 100000 | 5,270,673.9 us |  63,499.982 us |  56,291.080 us |  2.34 |    0.04 |            - |            - |            - |        472 KB |
|                    |      |         |        |                |                |                |       |         |              |              |              |               |
|   List_ICollection | Core |    Core | 100000 | 1,127,271.0 us |  18,963.254 us |  17,738.240 us |  1.00 |    0.00 |  624000.0000 |  624000.0000 |  624000.0000 | 1953398.44 KB |
| Pooled_ICollection | Core |    Core | 100000 |    74,456.7 us |   1,419.383 us |   1,634.564 us |  0.07 |    0.00 |            - |            - |            - |     273.44 KB |
|   List_IEnumerable | Core |    Core | 100000 | 5,665,477.7 us |  79,476.175 us |  74,342.063 us |  5.03 |    0.06 | 1428000.0000 | 1428000.0000 | 1428000.0000 | 5122148.44 KB |
| Pooled_IEnumerable | Core |    Core | 100000 | 4,138,303.4 us |  57,571.914 us |  53,852.804 us |  3.67 |    0.07 |            - |            - |            - |     468.75 KB |
