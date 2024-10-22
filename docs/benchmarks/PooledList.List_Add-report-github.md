``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|    Method |  Job | Runtime |      N |         Mean |      Error |     StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|---------- |----- |-------- |------- |-------------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|-----------:|
|   **ListAdd** |  **Clr** |     **Clr** |    **100** |     **2.899 us** |  **0.0557 us** |  **0.0572 us** |  **1.00** |    **0.00** |   **3.9978** |        **-** |        **-** |    **12609 B** |
| PooledAdd |  Clr |     Clr |    100 |     3.554 us |  0.0583 us |  0.0545 us |  1.23 |    0.03 |   0.0153 |        - |        - |       56 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   ListAdd | Core |    Core |    100 |     2.302 us |  0.0316 us |  0.0295 us |  1.00 |    0.00 |   3.9978 |        - |        - |    12552 B |
| PooledAdd | Core |    Core |    100 |     1.656 us |  0.0320 us |  0.0300 us |  0.72 |    0.02 |   0.0172 |        - |        - |       56 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   **ListAdd** |  **Clr** |     **Clr** |   **1000** |    **27.039 us** |  **0.5248 us** |  **0.5615 us** |  **1.00** |    **0.00** |  **39.2151** |        **-** |        **-** |   **124352 B** |
| PooledAdd |  Clr |     Clr |   1000 |    43.290 us |  0.6942 us |  0.6494 us |  1.60 |    0.03 |        - |        - |        - |       56 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   ListAdd | Core |    Core |   1000 |    21.122 us |  0.4102 us |  0.4029 us |  1.00 |    0.00 |  39.2151 |        - |        - |   124152 B |
| PooledAdd | Core |    Core |   1000 |    15.611 us |  0.2949 us |  0.3155 us |  0.74 |    0.02 |   0.0153 |        - |        - |       56 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   **ListAdd** |  **Clr** |     **Clr** |  **10000** |   **708.498 us** |  **5.8813 us** |  **5.5014 us** |  **1.00** |    **0.00** | **333.0078** | **333.0078** | **333.0078** |  **1242896 B** |
| PooledAdd |  Clr |     Clr |  10000 |   364.908 us |  2.5729 us |  2.1485 us |  0.52 |    0.01 |        - |        - |        - |       60 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   ListAdd | Core |    Core |  10000 |   650.370 us |  6.2097 us |  5.8086 us |  1.00 |    0.00 | 333.0078 | 333.0078 | 333.0078 |  1240152 B |
| PooledAdd | Core |    Core |  10000 |   152.081 us |  1.5929 us |  1.4900 us |  0.23 |    0.00 |        - |        - |        - |       56 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   **ListAdd** |  **Clr** |     **Clr** | **100000** | **7,083.557 us** | **33.3270 us** | **31.1741 us** |  **1.00** |    **0.00** | **492.1875** | **492.1875** | **492.1875** | **12401376 B** |
| PooledAdd |  Clr |     Clr | 100000 | 3,328.589 us | 60.1195 us | 56.2358 us |  0.47 |    0.01 |        - |        - |        - |       64 B |
|           |      |         |        |              |            |            |       |         |          |          |          |            |
|   ListAdd | Core |    Core | 100000 | 6,546.263 us | 89.4681 us | 83.6885 us |  1.00 |    0.00 | 492.1875 | 492.1875 | 492.1875 | 12400152 B |
| PooledAdd | Core |    Core | 100000 | 1,591.695 us | 26.9708 us | 25.2285 us |  0.24 |    0.01 |        - |        - |        - |       56 B |
