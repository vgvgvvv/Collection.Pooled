``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT

Jit=RyuJit  Platform=X64  InvocationCount=1  
UnrollFactor=1  

```
| Method |  Job | Runtime |       N |   Type |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |----- |-------- |-------- |------- |-------------:|-----------:|-----------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|  **Queue** |  **Clr** |     **Clr** |   **10000** |    **Int** |    **11.431 us** |  **0.1789 us** |  **0.1494 us** |    **11.400 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| Pooled |  Clr |     Clr |   10000 |    Int |     8.000 us |  0.1400 us |  0.1309 us |     7.900 us |  0.70 |    0.02 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  Queue | Core |    Core |   10000 |    Int |     8.183 us |  0.3972 us |  0.7840 us |     8.000 us |  1.00 |    0.00 |     - |     - |     - |         - |
| Pooled | Core |    Core |   10000 |    Int |     8.021 us |  0.1265 us |  0.1122 us |     8.000 us |  0.97 |    0.10 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  **Queue** |  **Clr** |     **Clr** |   **10000** | **String** |     **9.421 us** |  **0.1724 us** |  **0.1528 us** |     **9.400 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| Pooled |  Clr |     Clr |   10000 | String |     6.435 us |  0.1269 us |  0.1461 us |     6.400 us |  0.69 |    0.02 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  Queue | Core |    Core |   10000 | String |     6.320 us |  0.1084 us |  0.1014 us |     6.300 us |  1.00 |    0.00 |     - |     - |     - |         - |
| Pooled | Core |    Core |   10000 | String |     6.277 us |  0.1280 us |  0.1572 us |     6.300 us |  0.99 |    0.03 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  **Queue** |  **Clr** |     **Clr** |  **100000** |    **Int** |   **110.042 us** |  **2.0642 us** |  **1.6116 us** |   **109.200 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| Pooled |  Clr |     Clr |  100000 |    Int |    76.042 us |  0.0856 us |  0.0669 us |    76.000 us |  0.69 |    0.01 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  Queue | Core |    Core |  100000 |    Int |    82.486 us |  5.5086 us |  4.8832 us |    81.000 us |  1.00 |    0.00 |     - |     - |     - |         - |
| Pooled | Core |    Core |  100000 |    Int |    86.249 us |  4.4149 us | 12.4522 us |    80.900 us |  1.12 |    0.16 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  **Queue** |  **Clr** |     **Clr** |  **100000** | **String** |    **92.353 us** |  **1.8395 us** |  **2.0446 us** |    **93.200 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| Pooled |  Clr |     Clr |  100000 | String |    60.785 us |  1.1495 us |  0.9599 us |    61.000 us |  0.66 |    0.02 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  Queue | Core |    Core |  100000 | String |    86.935 us |  8.8923 us | 25.9392 us |    88.500 us |  1.00 |    0.00 |     - |     - |     - |         - |
| Pooled | Core |    Core |  100000 | String |    89.848 us | 10.0665 us | 29.6813 us |    94.350 us |  1.13 |    0.49 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  **Queue** |  **Clr** |     **Clr** | **1000000** |    **Int** | **1,118.971 us** | **23.7725 us** | **67.4386 us** | **1,098.000 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| Pooled |  Clr |     Clr | 1000000 |    Int |   810.291 us | 22.1672 us | 63.9576 us |   792.800 us |  0.73 |    0.07 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  Queue | Core |    Core | 1000000 |    Int |   830.119 us | 20.3735 us | 56.7932 us |   820.800 us |  1.00 |    0.00 |     - |     - |     - |         - |
| Pooled | Core |    Core | 1000000 |    Int |   822.220 us | 17.5690 us | 50.1252 us |   811.150 us |  1.00 |    0.08 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  **Queue** |  **Clr** |     **Clr** | **1000000** | **String** |   **928.178 us** | **18.0984 us** | **30.2383 us** |   **916.750 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| Pooled |  Clr |     Clr | 1000000 | String |   607.931 us | 12.0991 us | 27.5557 us |   611.750 us |  0.66 |    0.04 |     - |     - |     - |         - |
|        |      |         |         |        |              |            |            |              |       |         |       |       |       |           |
|  Queue | Core |    Core | 1000000 | String |   634.741 us | 12.6329 us | 27.1937 us |   623.900 us |  1.00 |    0.00 |     - |     - |     - |         - |
| Pooled | Core |    Core | 1000000 | String |   635.873 us | 12.6555 us | 33.7800 us |   623.900 us |  1.01 |    0.07 |     - |     - |     - |         - |
